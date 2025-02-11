using GALib.Core;
using GALib.Core.GAModel;

using System.Diagnostics;

namespace GALib.Search
{
	public class GASearchTask
	{
		private IGAModel _gaModel;

		private GASearchResult _searchResult = null!;

		private GASearchState _searchState = null!;

		private GASearchParam _searchParam = null!;

		//究極個体出現によるキャンセル
		private CancellationTokenSource _ultimateCancelToken = new CancellationTokenSource();

		//複数のキャンセルトークンを結合
		private CancellationTokenSource _mainCancelToken = null!;


		public GASearchTask(IGAModel gaModel, GASearchParam searchParam)
		{
			this._gaModel = gaModel;
			this._searchParam = searchParam;

			this._searchResult = new GASearchResult();
			this._searchState = new GASearchState();

		}

		public async Task<GASearchResult> SearchAsync(CancellationToken cancellationToken = default)
		{
			return await Task.Run<GASearchResult>(() => this.Search(cancellationToken));
		}


		public GASearchResult Search(CancellationToken cancellationToken = default)
		{
			//複数のキャンセルトークンを結合
			this._mainCancelToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _ultimateCancelToken.Token);

			_searchResult.StartTime = DateTime.Now;
			_searchState.SuperiorIndividuals.Clear();

			_searchState.GenerationCount = 0;
			try
			{
				CheckCancel();

				//第一世代の生成
				IIndividualGroup group = this.CreateInitGeneration();
				CheckCancel();

				//第一世代の評価
				this.EvaluateGeneration(group);
				CheckCancel();

				//候補を設定
				_searchState.SuperiorIndividuals.AddIndividual(group.GetBestIndividual());

				//最大世代交代数まで繰り返す 
				for (; _searchState.GenerationCount < _searchParam.MaxGenerationCount; _searchState.GenerationCount++)
				{
					//次世代を生成
					group = this.CreateNextGeneration(group);
					CheckCancel();

					//次世代の評価
					this.EvaluateGeneration(group);
					CheckCancel();

					//候補を設定
					_searchState.SuperiorIndividuals.AddIndividual(group.GetBestIndividual());
					CheckCancel();
				}

				// 最大世代交代数が終わっても究極の個体が見つからなかったのでその中で一番個体を返す
			}
			catch (OperationCanceledException ex) when (ex.CancellationToken == _ultimateCancelToken.Token)
			{
				Debug.WriteLine("究極の個体が出現しました。検索を終了します");
				_searchResult.IsCanceled = true;
			}
			catch (OperationCanceledException ex)
			{
				Debug.WriteLine("検索中断が要求されました");
				_searchResult.IsCanceled = true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
				throw;
			}
			finally
			{
				_searchResult.BestIndividual = _searchState.BestIndividual;
				_searchResult.GenerationCount = _searchState.GenerationCount;
				_searchResult.SearchParam = _searchParam;
				_searchResult.LastSearchState = _searchState;
				_searchResult.EndTime = DateTime.Now;
			}

			return _searchResult;
		}


		/// <summary>
		/// 第一世代の生成
		/// </summary>
		/// <param name="searchParam"></param>
		private IIndividualGroup CreateInitGeneration()
		{
			IIndividualGroup initGeneration = IndividualGroup.CreateInstance(_gaModel.OrderType);

			//並列で初期個体を生成
			Parallel.For(0, _searchParam.IndividualCount, index =>
			{
				try
				{
					//キャンセル済をチェック
					_mainCancelToken.Token.ThrowIfCancellationRequested();

					initGeneration.Individuals.Add(_gaModel.IndividualFactory.CreateNewIndividual());
				}
				catch (OperationCanceledException) { } // キャンセルされた
				catch (AggregateException)
				{
					// 他の例外
					throw;
				}
			});

			return initGeneration;
		}

		/// <summary>
		/// 指定された世代内の個体を評価します
		/// </summary>
		/// <param name="generation"></param>
		private void EvaluateGeneration(IIndividualGroup generation)
		{
			generation
				.AsParallel()
				.WithCancellation(_mainCancelToken.Token)
				.ForAll(individual =>
				{
					try
					{
						//キャンセル済をチェック
						_mainCancelToken.Token.ThrowIfCancellationRequested();

						//適応度を算出
						individual.FitnessValue = _gaModel.FitnessAlgorithm.GetFitnessValue(individual);

						//究極の個体が現れたらキャンセル
						if (individual.FitnessValue == _gaModel.FitnessAlgorithm.BestFitnessValue)
						{
							_ultimateCancelToken.Cancel();
						}
					}
					catch (OperationCanceledException) { } // キャンセルされた
					catch (AggregateException)
					{
						// 他の例外
						throw;
					}
				});
		}


		private IIndividualGroup CreateNextGeneration(IIndividualGroup currentGeneration)
		{

			//生存を行う。優秀な親は次世代集団に残る
			List<Individual> survivors = _gaModel.SurviveAlgorithm.Survive(currentGeneration.Individuals);

			//淘汰を行う。優秀な個体が多く残る
			List<Individual> selections = _gaModel.SelectionAlgorithm.Selection(currentGeneration.Individuals) ?? currentGeneration.Individuals;

			//交叉を行う。生存しなかった親は全て入れ替える
			List<Individual> children = _gaModel.CrossoverAlgorithm.Crossover(_gaModel.IndividualFactory, selections, selections.Count - survivors.Count);

			//突然変異を子集団の各塩基に対して行う。突然変異率が0.0の場合は行わない
			if (_gaModel.MutationProbability != 0.0)
			{
				_gaModel.MutationAlgorithm.Mutation(children, _gaModel.MutationProbability);
			}

			//逆位を子集団の各個人に対して行う。逆位率が0.0の場合は行わない
			if (_gaModel.InverseProbability != 0.0)
			{
				_gaModel.InverseAlgorithm.Inverse(children, _gaModel.InverseProbability);
			}

			//次世代の生成
			IIndividualGroup nextGeneration = IndividualGroup.CreateInstance(_gaModel.OrderType);
			nextGeneration.AddIndividuals(children);

			return nextGeneration;
		}

		private void CheckCancel()
		{
			_mainCancelToken.Token.ThrowIfCancellationRequested();
		}

	}
}

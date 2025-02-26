using GALib.Core.GAModel;
using GALib.Core.IndividualModel;

using System.Diagnostics;
using System.Security.Cryptography;

namespace GALib.Search
{
	public class GASearchTask<TBase>
	{
		private IGAModel _gaModel;
		private IIndividualModel<TBase> _individualModel;

		private GASearchResult<TBase> _searchResult = null!;

		private GASearchState<TBase> _searchState = null!;

		private GASearchParam _searchParam = null!;

		//複数のキャンセルトークンを結合
		private CancellationTokenSource _mainCancelToken = null!;


		public GASearchTask(IGAModel gaModel, IIndividualModel<TBase> individualModel)
		{
			this._gaModel = gaModel;
			this._individualModel = individualModel;

			this._searchResult = new GASearchResult<TBase>();
			this._searchState = new GASearchState<TBase>();
		}

		public IGASearchObservable<TBase>? Observable { get; set; } = null;


		public async Task<GASearchResult<TBase>> SearchAsync(GASearchParam searchParam, CancellationToken cancellationToken = default)
		{
			return await Task.Run<GASearchResult<TBase>>(() => this.Search(searchParam, cancellationToken));
		}


		public GASearchResult<TBase> Search(GASearchParam searchParam, CancellationToken cancellationToken = default)
		{
			this._searchParam = searchParam;

			//複数のキャンセルトークンを結合
			this._mainCancelToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _individualModel.UltimateCancelToken.Token);

			_searchResult.StartTime = DateTime.Now;
			if (_searchState.SuperiorIndividuals == null)
			{
				_searchState.SuperiorIndividuals = IndividualGroup<TBase>.CreateInstance(_gaModel.OrderType);
			}
			else
			{
				_searchState.SuperiorIndividuals.Clear();
			}


			_searchState.GenerationCount = 0;

			this.Observable?.SendNext(GASearchEventTypes.SearchStart, _searchState);//イベント発火
			try
			{
				CheckCancel();

				//第一世代の生成
				IIndividualGroup<TBase> group = IndividualGroup<TBase>.CreateInstance(_gaModel.OrderType);
				group.AddIndividuals(_individualModel.CreateInitIndividuals(searchParam.IndividualCount, _mainCancelToken));

				CheckCancel();

				//世代の評価
				this.EvaluateIndividuals(group);
				CheckCancel();

				//イベント発火
				this.Observable?.SendNext(GASearchEventTypes.GenerationChanged, _searchState);

				//最大世代交代数まで繰り返す 
				for (; _searchState.GenerationCount < _searchParam.MaxGenerationCount; _searchState.GenerationCount++)
				{
					//次世代を生成
					group = this.CreateNextindividualGroup(group);
					CheckCancel();

					//世代の評価
					this.EvaluateIndividuals(group);
					CheckCancel();

					//イベント発火
					this.Observable?.SendNext(GASearchEventTypes.GenerationChanged, _searchState);

				}

				// 最大世代交代数が終わっても究極の個体が見つからなかったのでその中で一番個体を返す
				//イベント発火
				this.Observable?.SendNext(GASearchEventTypes.SearchEnd, _searchState);

			}
			catch (OperationCanceledException ex) when (ex.CancellationToken == _mainCancelToken.Token)
			{
				if (this._individualModel.UltimateCancelToken.IsCancellationRequested)
				{
					Debug.WriteLine("究極の個体が出現しました。検索を終了します");
					_searchResult.IsCanceled = true;
					//イベント発火
					this.Observable?.SendNext(GASearchEventTypes.UltimateSearched, _searchState);
				}
				else
				{
					Debug.WriteLine("ユーザによって検索中断が要求されました");
					_searchResult.IsCanceled = true;
					//イベント発火
					this.Observable?.SendNext(GASearchEventTypes.UserCancel, _searchState);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);

				//イベント発火
				this.Observable?.SendError(ex);
				throw;
			}
			finally
			{
				_searchResult.BestIndividual = _searchState.BestIndividual;
				_searchResult.GenerationCount = _searchState.GenerationCount;
				_searchResult.SearchParam = _searchParam;
				_searchResult.LastSearchState = _searchState;
				_searchResult.EndTime = DateTime.Now;

				//イベント発火
				this.Observable?.SendCompleted();
			}

			return _searchResult;
		}


		/// <summary>
		/// 指定された世代内の個体を評価します
		/// </summary>
		/// <param name="individualGroup"></param>
		private void EvaluateIndividuals(IIndividualGroup<TBase> individualGroup)
		{
			try
			{
				_individualModel.EvaluateIndividuals(individualGroup.Individuals, _mainCancelToken);
			}
			finally
			{
				//候補を設定
				_searchState.SuperiorIndividuals.AddIndividual(individualGroup.GetBestIndividual());
			}
		}


		private IIndividualGroup<TBase> CreateNextindividualGroup(IIndividualGroup<TBase> currentGeneration)
		{

			//生存を行う。優秀な親は次世代集団に残る
			List<Individual<TBase>> survivors = _gaModel.SurviveAlgorithm?.Survive(currentGeneration.Individuals) ?? new();

			//淘汰を行う。優秀な個体が多く残る
			List<Individual<TBase>> selections = _gaModel.SelectionAlgorithm?.Selection(currentGeneration.Individuals) ?? currentGeneration.Individuals;

			//交叉を行う。生存しなかった親は全て入れ替える
			List<Individual<TBase>> children = _gaModel.CrossoverAlgorithm.Crossover(_individualModel.IndividualFactory, selections, selections.Count - survivors.Count);

			//突然変異を子集団の各塩基に対して行う。突然変異率が0.0の場合は行わない
			if (_gaModel.MutationAlgorithm != null && _gaModel.MutationProbability != 0.0)
			{
				_gaModel.MutationAlgorithm.Mutation(children, _gaModel.MutationProbability);
			}

			//逆位を子集団の各個人に対して行う。逆位率が0.0の場合は行わない
			if (_gaModel.InverseAlgorithm != null && _gaModel.InverseProbability != 0.0)
			{
				_gaModel.InverseAlgorithm.Inverse(children, _gaModel.InverseProbability);
			}

			//次世代の生成
			IIndividualGroup<TBase> nextGeneration = IndividualGroup<TBase>.CreateInstance(_gaModel.OrderType);
			nextGeneration.AddIndividuals(children);

			return nextGeneration;
		}

		private void CheckCancel()
		{
			_mainCancelToken.Token.ThrowIfCancellationRequested();
		}

	}
}

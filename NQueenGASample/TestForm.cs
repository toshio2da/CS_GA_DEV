using GALib;
using GALib.Core.GAModel;
using GALib.Search;
using GALib.GAModel;
using GALib.Forms;
using GALib.Plugins;
using System.Runtime.CompilerServices;

namespace jp.co.tmdgroup.nqueengasample
{
	public partial class TestForm : Form
	{
		private UIGASearchObserver gaSearchObserver = null!;
		private NQueenGAParam gaParam = new NQueenGAParam();

		public TestForm()
		{
			InitializeComponent();
			gaSearchObserver = new UIGASearchObserver(this);
		}


		private async void TestForm_Load(object sender, EventArgs e)
		{
			await this.InitializeAsync();
			this.ToForm(this.gaParam);

			this.InitEvents();
		}

		#region 進捗イベント表示

		private void InitEvents()
		{
			gaSearchObserver.SearchStart += GaSearchObserver_SearchStart;
			gaSearchObserver.GenerationChanged += GaSearchObserver_GenerationChanged;
			gaSearchObserver.UltimateSearched += GaSearchObserver_UltimateSearched;
			gaSearchObserver.SearchEnd += GaSearchObserver_SearchEnd;
			gaSearchObserver.Error += GaSearchObserver_Error;
			gaSearchObserver.Completed += GaSearchObserver_Completed;
		}

		private void GaSearchObserver_SearchStart(object? arg1, GASearchState arg2)
		{
			this.btnSearch.Enabled = false;

			this.lblSearchMessage.ForeColor = Color.Black;
			this.lblSearchMessage.Text = "検索を開始しました";

			this.searchProgressBar.Minimum = 0;
			this.searchProgressBar.Maximum = gaParam.MaxGenerationCnt;
			this.searchProgressBar.Value = 0;

		}

		private void GaSearchObserver_GenerationChanged(object? arg1, GASearchState arg2)
		{
			this.searchProgressBar.Value = arg2.GenerationCount;
			this.searchProgressBar.Refresh();
		}

		private void GaSearchObserver_UltimateSearched(object? arg1, GASearchState arg2)
		{
			this.lblSearchMessage.ForeColor = Color.Blue;
			this.lblSearchMessage.Text = "ハイスコアが検出されました";
		}

		private void GaSearchObserver_SearchEnd(object? arg1, GASearchState arg2)
		{
			this.lblSearchMessage.ForeColor = Color.Green;
			this.lblSearchMessage.Text = "検索が終了しました";
		}

		private void GaSearchObserver_Error(object? arg1, Exception arg2)
		{
			this.lblSearchMessage.ForeColor = Color.Red;
			this.lblSearchMessage.Text = $"検索中にエラーが発生しました\r\n{arg2.Message}";
		}


		private void GaSearchObserver_Completed(object? obj)
		{
			this.btnSearch.Enabled = true;
		}

		async Task InitializeAsync()
		{
			await webView.EnsureCoreWebView2Async(null);
		}

		#endregion

		/// <summary>
		/// 検索処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void btnSearch_Click(object sender, EventArgs e)
		{
			//GA検索パラメータを画面から取得
			this.FromForm(this.gaParam);

			#region GAModelBuilder を使用した場合
			//GAModelをビルド
			IGAModel gaModel = GAModelBuilder.GetBuilder(
				new LimitedNumberIndividualFactory(this.gaParam.QueenCnt, this.gaParam.QueenCnt),
				new NQueenFitnessAlgorithm()
				)
			.SetSelectionAlgorithm(new TournamentSelection(this.gaParam.TournamentSize))  // トーナメント方式。トーナメントサイズはデフォルトの2.
			.SetSurviveAlgorithm(new EliteStrategySurvive(this.gaParam.GenerationGap))   // エリート戦略による生存方式を採用
			.SetCrossoverAlgorithm(new OnePointCrossover())

			.SetMutationAlgorithm(new DefaultMutation())
			.SetMutationProbability(this.gaParam.MutationProbability) //1.0 / this.gaParam.IndividualCnt)

			.SetInverseAlgorithm(new DefaultInverse())
			.SetInverseProbability(0)

			.BuildWithDefault();
			#endregion

			#region GAModelをクラスで定義した場合
			//IGAModel gaModel = new NQueenGAModel();
			#endregion


			//GA検索パラメータを設定
			GASearchParam searchParam = new GASearchParam();
			searchParam.IndividualCount = this.gaParam.QueenCnt;
			searchParam.MaxGenerationCount = this.gaParam.MaxGenerationCnt;

			//GA検索タスクを生成
			GASearchTask task = new GASearchTask(gaModel, searchParam);

			//GA検索の進捗をしる為の設定
			task.Observable = new GASearchObservable();//イベント通知側（オブザーバブル）を設定
			task.Observable.Subscribe(gaSearchObserver);//イベント受取側（オブザーバー）を設定

			//検索開始
			var gaSearchResult = await task.SearchAsync();

			//結果をHTML表示
			this.ShowHtml(gaSearchResult);
		}


		private void ShowHtml(GASearchResult gaSearchResult)
		{
			string html = new NQueenToHtmlConverter(gaSearchResult).ToHtml(this.webView.Size);
			this.webView.NavigateToString(html);
		}


		private void ToForm(NQueenGAParam gaParam)
		{
			//GA検索パラメータを画面へ設定
			numQueenCnt.Value = gaParam.QueenCnt;
			numGenerationCnt.Value = gaParam.MaxGenerationCnt;
			numIndividualCnt.Value = gaParam.IndividualCnt;
			numMutationProbability.Value = Convert.ToDecimal(gaParam.MutationProbability);
			numGenerationGap.Value = Convert.ToDecimal(gaParam.GenerationGap);
		}

		private void FromForm(NQueenGAParam gaParam)
		{
			//GA検索パラメータを画面から取得
			gaParam.QueenCnt = Convert.ToInt32(numQueenCnt.Value);
			gaParam.MaxGenerationCnt = Convert.ToInt32(numGenerationCnt.Value);
			gaParam.IndividualCnt = Convert.ToInt32(numIndividualCnt.Value);
			gaParam.MutationProbability = Convert.ToDouble(numMutationProbability.Value);
			gaParam.GenerationGap = Convert.ToDouble(numGenerationGap.Value);
		}



		internal class NQueenGAParam
		{
			/// <summary>
			/// Queenの数
			/// </summary>
			public int QueenCnt { get; set; } = 10;

			/// <summary>
			/// 最大世代交代数
			/// </summary>
			public int MaxGenerationCnt { get; set; } = 500;

			/// <summary>
			/// 個体数
			/// </summary>
			public int IndividualCnt { get; set; } = 100;

			/// <summary>
			/// 突然変異確立
			/// </summary>
			public double MutationProbability { get; set; } = 0.05;

			/// <summary>
			/// トーナメントサイズ
			/// </summary>
			public int TournamentSize { get; set; } = 2;

			/// <summary>
			/// 世代間ギャップ（EliteStrategySurviveで使用
			/// </summary>
			public double GenerationGap { get; set; } = 0.95;




		}

	}
}
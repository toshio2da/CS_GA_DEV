using GALib;
using GALib.Core.GAModel;
using GALib.Search;
using GALib.GAModel;

namespace jp.co.tmdgroup.nqueengasample
{
	public partial class TestForm : Form
	{
		//NQueenGAObserver.NQueenGAParam param = new();

		public TestForm()
		{
			InitializeComponent();
		}

		private async void TestForm_Load(object sender, EventArgs e)
		{
			//this.test();

			await this.InitializeAsync();

			//numQueenCnt.Value = Convert.ToDecimal(param.QueenCnt);
			//numGenerationChangeCnt.Value = Convert.ToDecimal(param.MaxGenerationCnt);
			//numIndividualCnt.Value = Convert.ToDecimal(param.IndividualCnt);
			//numMutationRate.Value = Convert.ToDecimal(param.MutationRate);
		}


		//private void test()
		//{
		//	object[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		//	int[] indexes = { 2, 4, 8 };
		//	var result = DataTools.ArraySplits(array, indexes);
		//}


		async Task InitializeAsync()
		{
			await webView.EnsureCoreWebView2Async(null);
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			//param.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
			//param.MaxGenerationCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
			//param.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
			//param.MutationRate = Convert.ToDouble(this.numMutationRate.Value);

			//NQueenGAObserver ga = new(param);
			//GASearchResult gaSearchResult = ga.SearchQueeen();
			//this.ShowHtml(gaSearchResult);
		}

		private void ShowHtml(GASearchResult gaSearchResult)
		{
			string html = new NQueenToHtmlConverter(gaSearchResult).ToHtml(this.webView.Width - 100);
			this.webView.NavigateToString(html);
		}

		private async void btnSearch2_Click(object sender, EventArgs e)
		{

			int QueenCnt = Convert.ToInt32(numQueenCnt.Value);

			IGAModel gaModel = GAModelBuilder.GetBuilder(
				new LimitedNumberIndividualFactory(QueenCnt, QueenCnt), 
				new NQueenFitnessAlgorithm())
			.BuildWithDefault();

			GASearchParam searchParam = new GASearchParam();


			GASearchTask task = new GASearchTask(gaModel, searchParam);

			var searchResult =  await task.SearchAsync();

		}
	}
}
namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.tmdtools;

using System.Text;

public partial class TestForm : Form
{
	public TestForm()
	{
		InitializeComponent();
	}

	private async void TestForm_Load(object sender, EventArgs e)
	{
		await this.InitializeAsync();
	}


	private async Task InitializeAsync()
	{
		try
		{
			await webView.EnsureCoreWebView2Async(null);
		}
		catch (Exception)
		{
			MessageBox.Show("WebView2ランタイムがインストールされていない可能性があります。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			this.Close();
		}
	}


	private void btnSearch_Click(object sender, EventArgs e)
	{
		NQueenGA.NQueenGAContext context = new();

		context.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
		context.GenerationChangeCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
		context.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
		context.MutationRate = Convert.ToDouble(this.numMutationRate.Value);

		NQueenGA nQueenGA = new(context);

		Individual bestIndividual = nQueenGA.SearchQueeen();

		//int[] bestIndividualArray = DataTools.CreateUniqElementArray((int[])(bestIndividual.Gene.GetBase()));
		int[] bestIndividualArray = (int[])(bestIndividual.Gene.GetBase());

		

		StringBuilder dataOutput = new();
		dataOutput.AppendLine("<html><head></head><body>");
		dataOutput.AppendLine("<h3>スコア:");
		dataOutput.AppendLine(Convert.ToString(bestIndividual.FitnessValue));
		dataOutput.AppendLine("</h3>");
		dataOutput.AppendLine(NQueenToHtml.ToHtml(bestIndividualArray, this.webView.Width - 20));
		dataOutput.AppendLine("</body></html>");

		this.webView.NavigateToString(dataOutput.ToString());
	}

}


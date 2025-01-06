namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using System.Reflection;
using static jp.co.tmdgroup.nqueengasample.NQueenGAObserver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;
using jp.co.tmdgroup.common.GeneticAlgorithm;

public partial class TestForm : Form
{
	NQueenGAObserver.NQueenGAParam param = new();

	public TestForm()
	{
		InitializeComponent();
	}

	private async void TestForm_Load(object sender, EventArgs e)
	{
		await this.InitializeAsync();

		numQueenCnt.Value = Convert.ToDecimal(param.QueenCnt);
		numGenerationChangeCnt.Value = Convert.ToDecimal(param.MaxGenerationCnt);
		numIndividualCnt.Value = Convert.ToDecimal(param.IndividualCnt);
		numMutationRate.Value = Convert.ToDecimal(param.MutationRate);
	}

	async Task InitializeAsync()
	{
		await webView.EnsureCoreWebView2Async(null);
	}

	private async void btnSearch_Click(object sender, EventArgs e)
	{
		param.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
		param.MaxGenerationCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
		param.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
		param.MutationRate = Convert.ToDouble(this.numMutationRate.Value);

		NQueenGAObserver ga = new(param);
		GASearchResult gaSearchResult = ga.SearchQueeen();
		this.ShowHtml(gaSearchResult);
	}

	private void ShowHtml(GASearchResult gaSearchResult)
	{
		string html = new NQueenToHtmlConverter(gaSearchResult).ToHtml(this.webView.Width - 100);
		this.webView.NavigateToString(html);
	}
}


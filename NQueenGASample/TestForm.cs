namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.tmdtools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using jp.co.tmdgroup.common.geneticalgorithm;
using System.Net.NetworkInformation;
using System.Reflection;

public partial class TestForm : Form
{
	public TestForm()
	{
		InitializeComponent();
	}

	private void btnSearch_Click(object sender, EventArgs e)
	{
		NQueenGA.NQueenGAContext context = new();

		context.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
		context.GenerationChangeCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
		context.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
		context.MutationRate = Convert.ToDouble(this.numMutationRate.Value);

		NQueenGA ga = new(context);

		ga.SearchQueeen();
	}
}


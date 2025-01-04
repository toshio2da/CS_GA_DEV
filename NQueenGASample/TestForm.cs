namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.tmdtools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using jp.co.tmdgroup.common.geneticalgorithm;
using System.Net.NetworkInformation;
using System.Reflection;
using static jp.co.tmdgroup.nqueengasample.NQueenGA;

public partial class TestForm : Form
{
    NQueenGA.NQueenGAContext context = new();

    public TestForm()
    {
        InitializeComponent();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        txtPoint.Text = "";

        context.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
        context.GenerationChangeCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
        context.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
        context.MutationRate = Convert.ToDouble(this.numMutationRate.Value);

        NQueenGA ga = new(context);

        ga.SearchQueeen(Report);
    }

    private void Report(Individual surperior)
    {
        List<int> results = new List<int>();
        List<int> lists = new List<int>(((int[])(((LimitedNumberGene)surperior.Gene).GetBase())));

        int point = (int)surperior.FitnessValue;
        txtPoint.Text = point.ToString();

        this.boardCtrl1.SetResult(lists);
    }

    private void numQueenCnt_ValueChanged(object sender, EventArgs e)
    {
        this.boardCtrl1.SetNQueenCount(Convert.ToInt32(this.numQueenCnt.Value));
    }

    private void TestForm_Load(object sender, EventArgs e)
    {
        numQueenCnt.Value = Convert.ToDecimal(context.QueenCnt);
        numGenerationChangeCnt.Value = Convert.ToDecimal(context.GenerationChangeCnt);
        numIndividualCnt.Value = Convert.ToDecimal(context.IndividualCnt);
        numMutationRate.Value = Convert.ToDecimal(context.MutationRate);

        this.boardCtrl1.SetNQueenCount(Convert.ToInt32(this.numQueenCnt.Value));
    }
}


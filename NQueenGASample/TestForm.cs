namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using System.Reflection;
using static jp.co.tmdgroup.nqueengasample.NQueenGA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

public partial class TestForm : Form
{
    NQueenGA.NQueenGAParam context = new();

    public TestForm()
    {
        InitializeComponent();
    }

    private void TestForm_Load(object sender, EventArgs e)
    {
        numQueenCnt.Value = Convert.ToDecimal(context.QueenCnt);
        numGenerationChangeCnt.Value = Convert.ToDecimal(context.MaxGenerationCnt);
        numIndividualCnt.Value = Convert.ToDecimal(context.IndividualCnt);
        numMutationRate.Value = Convert.ToDecimal(context.MutationRate);

        this.boardCtrl1.SetNQueenCount(Convert.ToInt32(this.numQueenCnt.Value));
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        txtPoint.Text = "";

        context.QueenCnt = Convert.ToInt32(this.numQueenCnt.Value);
        context.MaxGenerationCnt = Convert.ToInt32(this.numGenerationChangeCnt.Value);
        context.IndividualCnt = Convert.ToInt32(this.numIndividualCnt.Value);
        context.MutationRate = Convert.ToDouble(this.numMutationRate.Value);
        NQueenGA ga = new(context);

        timer1.Interval = 100;
        timer1.Start();
        lastPoint = 0;
        btnSearch.Enabled = false;

        await Task.Run(() =>
        {
            ga.SearchQueeen();
        });
        timer1.Stop();
        btnSearch.Enabled = true;

        //int[] bextPattern = DataTools.CreateUniqElementArray(context.BestPattern);
        //int point = context.Point;

        //Report(bextPattern, point);
    }

    private int lastPoint = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (lastPoint < context.Point)
        {
            this.Report(context.BestPattern, context.Point);
            lastPoint = context.Point;
        }
    }

    private void Report(int[] bestPattern, int point)
    {
        txtPoint.Text = point.ToString();

        this.boardCtrl1.SetResult(bestPattern.ToList());
    }

    private void numQueenCnt_ValueChanged(object sender, EventArgs e)
    {
        this.boardCtrl1.SetNQueenCount(Convert.ToInt32(this.numQueenCnt.Value));
    }
}


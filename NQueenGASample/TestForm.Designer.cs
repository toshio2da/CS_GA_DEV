namespace jp.co.tmdgroup.nqueengasample;
partial class TestForm
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        txtPoint = new TextBox();
        label5 = new Label();
        btnSearch = new Button();
        numMutationRate = new NumericUpDown();
        label4 = new Label();
        numIndividualCnt = new NumericUpDown();
        label3 = new Label();
        numGenerationChangeCnt = new NumericUpDown();
        label2 = new Label();
        numQueenCnt = new NumericUpDown();
        label1 = new Label();
        panel2 = new Panel();
        boardCtrl1 = new NQueen.View.BoardCtrl();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numMutationRate).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numIndividualCnt).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numGenerationChangeCnt).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numQueenCnt).BeginInit();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(txtPoint);
        panel1.Controls.Add(label5);
        panel1.Controls.Add(btnSearch);
        panel1.Controls.Add(numMutationRate);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(numIndividualCnt);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(numGenerationChangeCnt);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(numQueenCnt);
        panel1.Controls.Add(label1);
        panel1.Dock = DockStyle.Left;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(275, 637);
        panel1.TabIndex = 0;
        // 
        // txtPoint
        // 
        txtPoint.Location = new Point(135, 176);
        txtPoint.Name = "txtPoint";
        txtPoint.Size = new Size(89, 23);
        txtPoint.TabIndex = 9;
        txtPoint.TextAlign = HorizontalAlignment.Right;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(135, 158);
        label5.Name = "label5";
        label5.Size = new Size(43, 15);
        label5.TabIndex = 8;
        label5.Text = "ポイント";
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(21, 154);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(75, 23);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "検索";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // numMutationRate
        // 
        numMutationRate.DecimalPlaces = 2;
        numMutationRate.Location = new Point(135, 109);
        numMutationRate.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
        numMutationRate.Name = "numMutationRate";
        numMutationRate.Size = new Size(89, 23);
        numMutationRate.TabIndex = 7;
        numMutationRate.TextAlign = HorizontalAlignment.Right;
        numMutationRate.Value = new decimal(new int[] { 95, 0, 0, 131072 });
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(21, 111);
        label4.Name = "label4";
        label4.Size = new Size(103, 15);
        label4.TabIndex = 6;
        label4.Text = "突然変異発生確率";
        // 
        // numIndividualCnt
        // 
        numIndividualCnt.Location = new Point(135, 80);
        numIndividualCnt.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numIndividualCnt.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        numIndividualCnt.Name = "numIndividualCnt";
        numIndividualCnt.Size = new Size(89, 23);
        numIndividualCnt.TabIndex = 5;
        numIndividualCnt.TextAlign = HorizontalAlignment.Right;
        numIndividualCnt.Value = new decimal(new int[] { 100, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(21, 82);
        label3.Name = "label3";
        label3.Size = new Size(43, 15);
        label3.TabIndex = 4;
        label3.Text = "個体数";
        // 
        // numGenerationChangeCnt
        // 
        numGenerationChangeCnt.Location = new Point(135, 51);
        numGenerationChangeCnt.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        numGenerationChangeCnt.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
        numGenerationChangeCnt.Name = "numGenerationChangeCnt";
        numGenerationChangeCnt.Size = new Size(89, 23);
        numGenerationChangeCnt.TabIndex = 3;
        numGenerationChangeCnt.TextAlign = HorizontalAlignment.Right;
        numGenerationChangeCnt.Value = new decimal(new int[] { 500, 0, 0, 0 });
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(21, 53);
        label2.Name = "label2";
        label2.Size = new Size(43, 15);
        label2.TabIndex = 2;
        label2.Text = "世代数";
        // 
        // numQueenCnt
        // 
        numQueenCnt.Location = new Point(135, 22);
        numQueenCnt.Name = "numQueenCnt";
        numQueenCnt.Size = new Size(89, 23);
        numQueenCnt.TabIndex = 1;
        numQueenCnt.TextAlign = HorizontalAlignment.Right;
        numQueenCnt.Value = new decimal(new int[] { 5, 0, 0, 0 });
        numQueenCnt.ValueChanged += numQueenCnt_ValueChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(21, 24);
        label1.Name = "label1";
        label1.Size = new Size(67, 15);
        label1.TabIndex = 0;
        label1.Text = "QUEENの数";
        // 
        // panel2
        // 
        panel2.Controls.Add(boardCtrl1);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(275, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(496, 637);
        panel2.TabIndex = 1;
        // 
        // boardCtrl1
        // 
        boardCtrl1.Dock = DockStyle.Fill;
        boardCtrl1.Location = new Point(0, 0);
        boardCtrl1.Margin = new Padding(4, 4, 4, 4);
        boardCtrl1.Name = "boardCtrl1";
        boardCtrl1.Size = new Size(496, 637);
        boardCtrl1.TabIndex = 0;
        // 
        // TestForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(771, 637);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Name = "TestForm";
        Text = "Form1";
        Load += TestForm_Load;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numMutationRate).EndInit();
        ((System.ComponentModel.ISupportInitialize)numIndividualCnt).EndInit();
        ((System.ComponentModel.ISupportInitialize)numGenerationChangeCnt).EndInit();
        ((System.ComponentModel.ISupportInitialize)numQueenCnt).EndInit();
        panel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
	private NumericUpDown numQueenCnt;
	private Label label1;
	private NumericUpDown numMutationRate;
	private Label label4;
	private NumericUpDown numIndividualCnt;
	private Label label3;
	private NumericUpDown numGenerationChangeCnt;
	private Label label2;
	private Button btnSearch;
    private Panel panel2;
    private NQueen.View.BoardCtrl boardCtrl1;
    private TextBox txtPoint;
    private Label label5;
}

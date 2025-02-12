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
		pnlProgress = new Panel();
		lblSearchMessage = new Label();
		searchProgressBar = new ProgressBar();
		numTournamentSize = new NumericUpDown();
		label6 = new Label();
		numGenerationGap = new NumericUpDown();
		label5 = new Label();
		btnSearch = new Button();
		numMutationProbability = new NumericUpDown();
		label4 = new Label();
		numIndividualCnt = new NumericUpDown();
		label3 = new Label();
		numGenerationCnt = new NumericUpDown();
		label2 = new Label();
		numQueenCnt = new NumericUpDown();
		label1 = new Label();
		panel2 = new Panel();
		webView = new Microsoft.Web.WebView2.WinForms.WebView2();
		panel1.SuspendLayout();
		pnlProgress.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numTournamentSize).BeginInit();
		((System.ComponentModel.ISupportInitialize)numGenerationGap).BeginInit();
		((System.ComponentModel.ISupportInitialize)numMutationProbability).BeginInit();
		((System.ComponentModel.ISupportInitialize)numIndividualCnt).BeginInit();
		((System.ComponentModel.ISupportInitialize)numGenerationCnt).BeginInit();
		((System.ComponentModel.ISupportInitialize)numQueenCnt).BeginInit();
		panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)webView).BeginInit();
		SuspendLayout();
		// 
		// panel1
		// 
		panel1.Controls.Add(pnlProgress);
		panel1.Controls.Add(numTournamentSize);
		panel1.Controls.Add(label6);
		panel1.Controls.Add(numGenerationGap);
		panel1.Controls.Add(label5);
		panel1.Controls.Add(btnSearch);
		panel1.Controls.Add(numMutationProbability);
		panel1.Controls.Add(label4);
		panel1.Controls.Add(numIndividualCnt);
		panel1.Controls.Add(label3);
		panel1.Controls.Add(numGenerationCnt);
		panel1.Controls.Add(label2);
		panel1.Controls.Add(numQueenCnt);
		panel1.Controls.Add(label1);
		panel1.Dock = DockStyle.Left;
		panel1.Location = new Point(0, 0);
		panel1.Name = "panel1";
		panel1.Size = new Size(275, 437);
		panel1.TabIndex = 0;
		// 
		// pnlProgress
		// 
		pnlProgress.Controls.Add(lblSearchMessage);
		pnlProgress.Controls.Add(searchProgressBar);
		pnlProgress.Dock = DockStyle.Bottom;
		pnlProgress.Location = new Point(0, 316);
		pnlProgress.Name = "pnlProgress";
		pnlProgress.Size = new Size(275, 121);
		pnlProgress.TabIndex = 13;
		// 
		// lblSearchMessage
		// 
		lblSearchMessage.AutoSize = true;
		lblSearchMessage.Location = new Point(3, 40);
		lblSearchMessage.Name = "lblSearchMessage";
		lblSearchMessage.Size = new Size(7, 15);
		lblSearchMessage.TabIndex = 1;
		lblSearchMessage.Text = "\r\n";
		// 
		// searchProgressBar
		// 
		searchProgressBar.Dock = DockStyle.Top;
		searchProgressBar.Location = new Point(0, 0);
		searchProgressBar.Name = "searchProgressBar";
		searchProgressBar.Size = new Size(275, 23);
		searchProgressBar.TabIndex = 0;
		// 
		// numTournamentSize
		// 
		numTournamentSize.Location = new Point(135, 149);
		numTournamentSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
		numTournamentSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
		numTournamentSize.Name = "numTournamentSize";
		numTournamentSize.Size = new Size(89, 23);
		numTournamentSize.TabIndex = 12;
		numTournamentSize.TextAlign = HorizontalAlignment.Right;
		numTournamentSize.Value = new decimal(new int[] { 2, 0, 0, 0 });
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new Point(21, 151);
		label6.Name = "label6";
		label6.Size = new Size(85, 15);
		label6.TabIndex = 11;
		label6.Text = "トーナメントサイズ";
		// 
		// numGenerationGap
		// 
		numGenerationGap.DecimalPlaces = 2;
		numGenerationGap.Location = new Point(135, 178);
		numGenerationGap.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
		numGenerationGap.Name = "numGenerationGap";
		numGenerationGap.Size = new Size(89, 23);
		numGenerationGap.TabIndex = 10;
		numGenerationGap.TextAlign = HorizontalAlignment.Right;
		numGenerationGap.Value = new decimal(new int[] { 95, 0, 0, 131072 });
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new Point(21, 180);
		label5.Name = "label5";
		label5.Size = new Size(78, 15);
		label5.TabIndex = 9;
		label5.Text = "世代間ギャップ";
		// 
		// btnSearch
		// 
		btnSearch.Location = new Point(21, 236);
		btnSearch.Name = "btnSearch";
		btnSearch.Size = new Size(75, 23);
		btnSearch.TabIndex = 8;
		btnSearch.Text = "検索";
		btnSearch.UseVisualStyleBackColor = true;
		btnSearch.Click += btnSearch_Click;
		// 
		// numMutationProbability
		// 
		numMutationProbability.DecimalPlaces = 2;
		numMutationProbability.Location = new Point(135, 109);
		numMutationProbability.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
		numMutationProbability.Name = "numMutationProbability";
		numMutationProbability.Size = new Size(89, 23);
		numMutationProbability.TabIndex = 7;
		numMutationProbability.TextAlign = HorizontalAlignment.Right;
		numMutationProbability.Value = new decimal(new int[] { 95, 0, 0, 131072 });
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
		// numGenerationCnt
		// 
		numGenerationCnt.Location = new Point(135, 51);
		numGenerationCnt.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
		numGenerationCnt.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
		numGenerationCnt.Name = "numGenerationCnt";
		numGenerationCnt.Size = new Size(89, 23);
		numGenerationCnt.TabIndex = 3;
		numGenerationCnt.TextAlign = HorizontalAlignment.Right;
		numGenerationCnt.Value = new decimal(new int[] { 500, 0, 0, 0 });
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
		panel2.Controls.Add(webView);
		panel2.Dock = DockStyle.Fill;
		panel2.Location = new Point(275, 0);
		panel2.Name = "panel2";
		panel2.Size = new Size(438, 437);
		panel2.TabIndex = 1;
		// 
		// webView
		// 
		webView.AllowExternalDrop = true;
		webView.CreationProperties = null;
		webView.DefaultBackgroundColor = Color.White;
		webView.Dock = DockStyle.Fill;
		webView.Location = new Point(0, 0);
		webView.Name = "webView";
		webView.Size = new Size(438, 437);
		webView.TabIndex = 0;
		webView.ZoomFactor = 1D;
		// 
		// TestForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(713, 437);
		Controls.Add(panel2);
		Controls.Add(panel1);
		Name = "TestForm";
		Text = "Form1";
		Load += TestForm_Load;
		panel1.ResumeLayout(false);
		panel1.PerformLayout();
		pnlProgress.ResumeLayout(false);
		pnlProgress.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numTournamentSize).EndInit();
		((System.ComponentModel.ISupportInitialize)numGenerationGap).EndInit();
		((System.ComponentModel.ISupportInitialize)numMutationProbability).EndInit();
		((System.ComponentModel.ISupportInitialize)numIndividualCnt).EndInit();
		((System.ComponentModel.ISupportInitialize)numGenerationCnt).EndInit();
		((System.ComponentModel.ISupportInitialize)numQueenCnt).EndInit();
		panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)webView).EndInit();
		ResumeLayout(false);
	}

	#endregion

	private Panel panel1;
	private NumericUpDown numQueenCnt;
	private Label label1;
	private NumericUpDown numMutationProbability;
	private Label label4;
	private NumericUpDown numIndividualCnt;
	private Label label3;
	private NumericUpDown numGenerationCnt;
	private Label label2;
	private Button btnSearch;
    private Panel panel2;
    private System.Windows.Forms.Timer timer1;
	private Microsoft.Web.WebView2.WinForms.WebView2 webView;
	private NumericUpDown numGenerationGap;
	private Label label5;
	private NumericUpDown numTournamentSize;
	private Label label6;
	private Panel pnlProgress;
	private ProgressBar searchProgressBar;
	private Label lblSearchMessage;
}

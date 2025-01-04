namespace NQueen
{
    partial class NQueenForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new MindFusion.UI.WinForms.Button();
            this.txtMutationRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIndividualsCnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGenChangeCnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQeenCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.boardCtrl1 = new NQueen.View.BoardCtrl();
            this.pnlLeft.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txtPoint);
            this.pnlLeft.Controls.Add(this.label5);
            this.pnlLeft.Controls.Add(this.btnSearch);
            this.pnlLeft.Controls.Add(this.txtMutationRate);
            this.pnlLeft.Controls.Add(this.label4);
            this.pnlLeft.Controls.Add(this.txtIndividualsCnt);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.txtGenChangeCnt);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.txtQeenCnt);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(145, 487);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtPoint
            // 
            this.txtPoint.Enabled = false;
            this.txtPoint.Location = new System.Drawing.Point(14, 289);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(100, 19);
            this.txtPoint.TabIndex = 11;
            this.txtPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "得点";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundBrush = new MindFusion.Drawing.SolidBrush("#FFF0F0F0");
            this.btnSearch.BackgroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFDEDEDE");
            this.btnSearch.BackgroundBrushDown = new MindFusion.Drawing.SolidBrush("#FFAEAEAE");
            this.btnSearch.BackgroundBrushOver = new MindFusion.Drawing.SolidBrush("#FFC5C5C5");
            this.btnSearch.BorderBrush = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            this.btnSearch.BorderBrushDisabled = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            this.btnSearch.BorderBrushDown = new MindFusion.Drawing.SolidBrush("#FF777777");
            this.btnSearch.BorderBrushOver = new MindFusion.Drawing.SolidBrush("#FFA6A6A6");
            this.btnSearch.BorderThickness = 0;
            this.btnSearch.ForegroundBrush = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.btnSearch.ForegroundBrushDisabled = new MindFusion.Drawing.SolidBrush("#FF777777");
            this.btnSearch.ForegroundBrushDown = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.btnSearch.ForegroundBrushOver = new MindFusion.Drawing.SolidBrush("#FF000000");
            this.btnSearch.Location = new System.Drawing.Point(14, 225);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "検索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMutationRate
            // 
            this.txtMutationRate.Location = new System.Drawing.Point(14, 185);
            this.txtMutationRate.Name = "txtMutationRate";
            this.txtMutationRate.Size = new System.Drawing.Size(100, 19);
            this.txtMutationRate.TabIndex = 8;
            this.txtMutationRate.Text = "0.95";
            this.txtMutationRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "突然変異発生確率";
            // 
            // txtIndividualsCnt
            // 
            this.txtIndividualsCnt.Location = new System.Drawing.Point(14, 130);
            this.txtIndividualsCnt.Name = "txtIndividualsCnt";
            this.txtIndividualsCnt.Size = new System.Drawing.Size(100, 19);
            this.txtIndividualsCnt.TabIndex = 6;
            this.txtIndividualsCnt.Text = "1000";
            this.txtIndividualsCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "個体数";
            // 
            // txtGenChangeCnt
            // 
            this.txtGenChangeCnt.Location = new System.Drawing.Point(14, 77);
            this.txtGenChangeCnt.Name = "txtGenChangeCnt";
            this.txtGenChangeCnt.Size = new System.Drawing.Size(100, 19);
            this.txtGenChangeCnt.TabIndex = 4;
            this.txtGenChangeCnt.Text = "100";
            this.txtGenChangeCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "世代交代数";
            // 
            // txtQeenCnt
            // 
            this.txtQeenCnt.Location = new System.Drawing.Point(12, 24);
            this.txtQeenCnt.Name = "txtQeenCnt";
            this.txtQeenCnt.Size = new System.Drawing.Size(100, 19);
            this.txtQeenCnt.TabIndex = 2;
            this.txtQeenCnt.Text = "10";
            this.txtQeenCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQeenCnt.TextChanged += new System.EventHandler(this.txtQeenCnt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qeenの数";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.boardCtrl1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(145, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(601, 487);
            this.pnlBody.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(NQueen.NQueenData);
            // 
            // boardCtrl1
            // 
            this.boardCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardCtrl1.Location = new System.Drawing.Point(0, 0);
            this.boardCtrl1.Name = "boardCtrl1";
            this.boardCtrl1.Size = new System.Drawing.Size(601, 487);
            this.boardCtrl1.TabIndex = 0;
            // 
            // NQueenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 487);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlLeft);
            this.Name = "NQueenForm";
            this.Text = "NQeen";
            this.Load += new System.EventHandler(this.NQueenForm_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TextBox txtQeenCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIndividualsCnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGenChangeCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label label5;
        private MindFusion.UI.WinForms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMutationRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private View.BoardCtrl boardCtrl1;
    }
}


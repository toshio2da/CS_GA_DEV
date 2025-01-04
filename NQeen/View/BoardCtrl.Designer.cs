namespace NQueen.View
{
    partial class BoardCtrl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoard
            // 
            this.picBoard.BackColor = System.Drawing.Color.White;
            this.picBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoard.Location = new System.Drawing.Point(0, 0);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(363, 341);
            this.picBoard.TabIndex = 0;
            this.picBoard.TabStop = false;
            // 
            // BoardCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBoard);
            this.Name = "BoardCtrl";
            this.Size = new System.Drawing.Size(363, 341);
            this.Resize += new System.EventHandler(this.BoardCtrl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoard;
    }
}

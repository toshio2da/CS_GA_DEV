using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NQueen.View
{
    public partial class BoardCtrl : UserControl
    {
        private int nQueenCount = 10;
        private int xOffset;
        private int yOffset;
        private int cellSize;
        private List<int> queenPositions = new List<int>();

        public BoardCtrl()
        {
            InitializeComponent();
        }

        public void SetNQueenCount(int nQueenCount)
        {
            if (nQueenCount >= 4)
            {
                this.nQueenCount = nQueenCount;
                DrawBoard();
                ClearQueen();
            }
        }

        public void SetResult(List<int> result)
        {
            this.queenPositions.Clear();
            this.queenPositions.AddRange(result);

            DrawQueen();
        }

        private void DrawBoard()
        {
            picBoard.BackgroundImage?.Dispose();
            picBoard.BackgroundImage = new Bitmap(picBoard.Width, picBoard.Height);

            // ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(picBoard.BackgroundImage);

            //補間方法として高品質双三次補間を指定する
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            int size = picBoard.Width < picBoard.Height ? picBoard.Width : picBoard.Height;
            size = (int)(0.9 * size);
            cellSize = size / nQueenCount;
            size = cellSize * nQueenCount;

            xOffset = (picBoard.Width - size) / 2;
            yOffset = (picBoard.Height - size) / 2;

            // 横線
            int y = yOffset;
            for (int i = 0; i <= nQueenCount; i++)
            {
                g.DrawLine(Pens.Black, xOffset, y, xOffset + size, y);
                y += cellSize;
            }

            // 縦線
            int x = xOffset;
            for (int i = 0; i <= nQueenCount; i++)
            {
                g.DrawLine(Pens.Black, x, yOffset, x, yOffset + size);
                x += cellSize;
            }

            g.Dispose();

            picBoard.Refresh();
        }

        private Point GetPosition(int col, int row)
        {
            int x = xOffset + cellSize * col;
            int y = yOffset + cellSize * row;

            return new Point(x, y);
        }

        private void ClearQueen()
        {
            picBoard.Image?.Dispose();
            picBoard.Image = null;
        }

        private void DrawQueen()
        {
            if (nQueenCount < 4 || queenPositions.Count != nQueenCount)
            {
                ClearQueen();
                return;
            }

            picBoard.Image?.Dispose();
            picBoard.Image = new Bitmap(picBoard.Width, picBoard.Height);

            // ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(picBoard.Image);

            //補間方法として高品質双三次補間を指定する
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            DrawQeen(g);

            g.Dispose();

            picBoard.Refresh();
        }

        private void DrawQeen(Graphics g)
        {
            for (int row = 0; row < nQueenCount; row++)
            {
                int col = queenPositions[row];
                Point pt = GetPosition(col, row);

                //g.DrawImage(Properties.Resources.Queen, pt.X + 1, pt.Y + 1, cellSize - 10, cellSize - 2);
                g.FillEllipse(Brushes.Violet, pt.X + 1, pt.Y + 1, cellSize - 2, cellSize - 2);
            }
        }

        private void BoardCtrl_Resize(object sender, EventArgs e)
        {
            DrawBoard();
            DrawQueen();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NQueen
{
    public partial class NQueenForm : Form
    {
        private NQueenData data = new NQueenData();
        public NQueenForm()
        {
            InitializeComponent();
        }

        private void NQueenForm_Load(object sender, EventArgs e)
        {

            txtQeenCnt.DataBindings.Add("Text", bindingSource1, nameof(NQueenData.QueenCnt));
            txtGenChangeCnt.DataBindings.Add("Text", bindingSource1, nameof(NQueenData.GenerationChangeCnt));
            txtIndividualsCnt.DataBindings.Add("Text", bindingSource1, nameof(NQueenData.IndividualCnt));
            txtMutationRate.DataBindings.Add("Text", bindingSource1, nameof(NQueenData.MutationRate));
            txtPoint.DataBindings.Add("Text", bindingSource1, nameof(NQueenData.Point));

            bindingSource1.DataSource = data;
        }

        private void txtQeenCnt_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(txtQeenCnt.Text, out n))
            {
                if (n >= 5)
                    boardCtrl1.SetNQueenCount(n);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<int> result = new List<int>();
            Random r = new Random();
            for (int i = 0; i < data.QueenCnt; ++i)
            {
                int n = r.Next(0, 10 * data.QueenCnt - 1) / 10;
                result.Add(n);
            }
            boardCtrl1.SetResult(result);
        }

        private void DrawBoard()
        {

        }
    }
}

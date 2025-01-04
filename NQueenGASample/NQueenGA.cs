using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.tmdtools;

using static jp.co.tmdgroup.nqueengasample.NQueenGA;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jp.co.tmdgroup.nqueengasample
{
	internal class NQueenGA(NQueenGAContext context)
	{
		internal class NQueenGAContext
		{
			/// <summary>
			/// Queenの数
			/// </summary>
			public int QueenCnt { get; set; } = 10;

			/// <summary>
			/// 世代交代数
			/// </summary>
			public int GenerationChangeCnt { get; set; } = 500;

			/// <summary>
			/// 個体数
			/// </summary>
			public int IndividualCnt { get; set; } = 1000;

			/// <summary>
			/// 突然変異確立
			/// </summary>
			public double MutationRate { get; set; } = 0.95;

			public int Point { get; set; } = 0;
		}


		/// <summary>
		/// 制御コマンド変数
		/// </summary>
		int command = GeneticStatus.GO_AHEAD_SEARCH;



		/// <summary>
		/// GAの状態オブジェクト
		/// </summary>
		private GeneticStatus? gaStatus = null;



		/// <summary>
		/// 探索状態変数
		/// </summary>
		int status = GeneticStatus.WAIT_FOR_SEARCH;


		/// <summary>
		/// 探索結果
		/// </summary>
		int[] bestPattern = [];


		private class GeneticReportableImpl(NQueenGA parent) : IGeneticReportable
		{
			public void Report(Individual surperior)
			{
				parent.status = GeneticStatus.SEARCHING;
				parent.bestPattern = DataTools.CreateUniqElementArray((int[])surperior.Gene.GetBase());
				//owner.mapPanel.canvas.repaint();
			}

			public void FinishReport(Individual lastSurperior, int resultGenerationNumber, long computationTime)
			{
				parent.status = GeneticStatus.DONE_SEARCH;
				parent.bestPattern = DataTools.CreateUniqElementArray((int[])lastSurperior.Gene.GetBase());
				//owner.mapPanel.canvas.repaint();
			}
		}

		/**
		* 遺伝的アルゴリズムによる探索を行います
		**/
		public void SearchQueeen()
		{
			gaStatus = new ();
			gaStatus.Command = this.command;
			gaStatus.Reporter = new GeneticReportableImpl(this);

			NQueenGeneticAlgorithm model = new (context.QueenCnt);

			GeneticAlgorithm _ga = new (model, gaStatus, context.IndividualCnt);
			Individual _best = _ga.Search(context.GenerationChangeCnt); // 探索
		}
	}
}

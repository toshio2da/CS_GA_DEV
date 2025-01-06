using jp.co.tmdgroup.common.GeneticAlgorithm;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;
using jp.co.tmdgroup.common.Utils;

using static jp.co.tmdgroup.nqueengasample.NQueenGAObserver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jp.co.tmdgroup.nqueengasample
{
	internal class NQueenGAObserver(NQueenGAParam param)
	{
		internal class NQueenGAParam
		{
			/// <summary>
			/// Queenの数
			/// </summary>
			public int QueenCnt { get; set; } = 10;

			/// <summary>
			/// 世代交代数
			/// </summary>
			public int MaxGenerationCnt { get; set; } = 500;

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
		/// GAの状態オブジェクト
		/// </summary>
		private GASearchContext? gaContext = null;



		/// <summary>
		/// 探索状態変数
		/// </summary>
		private GASearchStatus status = GASearchStatus.WAIT_FOR_SEARCH;


		/// <summary>
		/// 探索結果
		/// </summary>
		private int[] bestPattern = [];

		private class GeneticReportableImpl(NQueenGAObserver parent, funcDelegate reportFunc) : IGeneticReportable
		{
			public void Report(Individual surperior)
			{
				parent.status = GASearchStatus.SEARCHING;
				parent.bestPattern = DataTools.CreateUniqElementArray((int[])surperior.Gene.GetBase());
                int point = (int)surperior.FitnessValue;
                //parent.bestPattern = (int[])surperior.Gene.GetBase();
                //owner.mapPanel.canvas.repaint();
                reportFunc.Invoke(parent.bestPattern, point);
            }

            public void FinishReport(Individual lastSurperior, int resultGenerationNumber, long computationTime)
			{
				parent.status = GASearchStatus.DONE_SEARCH;
				parent.bestPattern = DataTools.CreateUniqElementArray((int[])lastSurperior.Gene.GetBase());
                int point = (int)lastSurperior.FitnessValue;

                //parent.bestPattern = (int[])lastSurperior.Gene.GetBase();
                //owner.mapPanel.canvas.repaint();
                reportFunc.Invoke(parent.bestPattern, point);
            }
        }

		public delegate void funcDelegate(int[] bestPattern, int point);

        /**
		* 遺伝的アルゴリズムによる探索を行います
		**/
        public GASearchResult SearchQueeen(funcDelegate reportFunc)
        {
            NQueenGAModel model = new (param.QueenCnt);
			GeneticAlgorithm _ga = new (model);

			gaContext = new();
			gaContext.Command = GASearchCommand.GO_AHEAD_SEARCH;
			gaContext.Reporter = new GeneticReportableImpl(this, reportFunc);
			gaContext.IndividualCnt = param.IndividualCnt;
			gaContext.MaxGenerationCnt = param.MaxGenerationCnt;

			GASearchResult searchResult = _ga.Search(gaContext); // 探索

			return searchResult;
		}
	}
}

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
			public int QueenCnt { get; set; } = 30;

			/// <summary>
			/// 最大世代交代数
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

            /// <summary>
            /// 世代
            /// </summary>
            public int GenerationNumber { get; set; } = 0;

            /// <summary>
            /// 探索結果
            /// </summary>
            public int[] BestPattern { get; set; }
        }

		/// <summary>
		/// GA
		/// </summary>
		private GeneticAlgorithm _ga;

        /// <summary>
        /// GAの状態オブジェクト
        /// </summary>
        private GASearchContext? gaContext = null;

		private NQueenGAParam nQueenGAParam { get; set; } = param;

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
                parent.nQueenGAParam.BestPattern = DataTools.CreateUniqElementArray((int[])surperior.Gene.GetBase());
                parent.nQueenGAParam.GenerationNumber = (int)surperior.GenerationNumber;
                parent.nQueenGAParam.Point = (int)surperior.FitnessValue;
                parent.nQueenGAParam.GenerationNumber = surperior.GenerationNumber;
                //parent.bestPattern = (int[])surperior.Gene.GetBase();
                //owner.mapPanel.canvas.repaint();
            }

            public void FinishReport(Individual lastSurperior, int resultGenerationNumber, long computationTime)
			{
				parent.status = GASearchStatus.DONE_SEARCH;
                parent.nQueenGAParam.BestPattern = DataTools.CreateUniqElementArray((int[])lastSurperior.Gene.GetBase());
                parent.nQueenGAParam.Point = (int)lastSurperior.FitnessValue;
                parent.nQueenGAParam.GenerationNumber = lastSurperior.GenerationNumber;
                //parent.bestPattern = (int[])lastSurperior.Gene.GetBase();
                //owner.mapPanel.canvas.repaint();
            }
        }

        /**
		* 遺伝的アルゴリズムによる探索を行います
		**/
        public GASearchResult SearchQueeen(funcDelegate reportFunc)
        {
            NQueenGAModel model = new (param.QueenCnt);
			_ga = new (model);

			gaContext = new();
			gaContext.Command = GASearchCommand.GO_AHEAD_SEARCH;
			gaContext.Reporter = new GeneticReportableImpl(this);
			gaContext.IndividualCnt = param.IndividualCnt;
			gaContext.MaxGenerationCnt = param.MaxGenerationCnt;

			GASearchResult searchResult = _ga.Search(gaContext); // 探索

			return searchResult;
		}

		public void StopSearch()
		{
			_ga.StopSearchInterval = 1;
		}
	}
}

﻿using GALib.Algo;
using GALib.Core.Models;

using static jp.co.tmdgroup.nqueengasample.NQueenGAObserver;

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
			/// 最大世代交代数
			/// </summary>
			public int MaxGenerationCnt { get; set; } = 500;

			/// <summary>
			/// 個体数
			/// </summary>
			public int IndividualCnt { get; set; } = 100;

			/// <summary>
			/// 突然変異確立
			/// </summary>
			public double MutationRate { get; set; } = 0.95;
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



		private class GeneticReportableImpl(NQueenGAObserver parent) : IGeneticReportable
		{
			public void Report(Individual surperior)
			{
				parent.status = GASearchStatus.SEARCHING;
            }

            public void FinishReport(Individual lastSurperior, int resultGenerationNumber, long computationTime)
			{
				parent.status = GASearchStatus.DONE_SEARCH;
            }
        }

        /**
		* 遺伝的アルゴリズムによる探索を行います
		**/
        public GASearchResult SearchQueeen()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen
{
    internal class NQueenData
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
}

using GALib.Core.IndividualModel;
using GALib.IndividualModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.nqueengasample
{
	internal class NQueenIndividualModel : DefaultIndividualModel<int>
	{

		/** N-Queen問題のN。この数だけ盤ができ、クイーンが配置される。 */
		private int N;
		
		
		/// <summary>
		/// ヘルパコンストラクタ
		/// </summary>
		/// <param name="N">次数</param>
		public NQueenIndividualModel(int N)
		: base(new LimitedNumberIndividualFactory(N, N), new NQueenFitnessAlgorithm())
		{

		}
	}
}

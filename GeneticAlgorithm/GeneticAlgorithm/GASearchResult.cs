using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jp.co.tmdgroup.common.GeneticAlgorithm
{
	public class GASearchResult
	{
		internal GASearchResult() { }

		public Individual BestIndividual { get; internal set; }

		public int GenerationCnt{ get; internal set; }
	}
}

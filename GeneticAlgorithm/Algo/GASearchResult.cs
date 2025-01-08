using GALib.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Algo
{
	public class GASearchResult
	{
		internal GASearchResult() { }

		public Individual BestIndividual { get; internal set; }

		public int GenerationCnt { get; internal set; }

		public DateTime StartTime { get; internal set; }

		public DateTime EndTime { get; internal set; }
	}
}

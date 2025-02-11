using GALib.Core.Plugins;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.GAModel.Json
{
	public class GAModelSetting
	{

		public double? MutationProbability { get; set; }

		public double? InverseProbability { get; set; }

		public GAModelInfo? IndividualFactoryInfo { get; set; }

		public GAModelInfo? FitnessAlgorithmInfo { get; set; }

		public GAModelInfo? SelectionAlgorithmInfo { get; set; }

		public GAModelInfo? SurvivalAlgorithmInfo { get; set; }

		public GAModelInfo? CrossoverAlgorithmInfo { get; set; }
				
		public GAModelInfo? MutationAlgorithmInfo { get; set; }

		public GAModelInfo? InverseAlgorithmInfo { get; set; }

	}
}

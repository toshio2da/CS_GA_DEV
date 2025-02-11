using GALib.Core.Plugins;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.GAModel
{
	public class DefaultGAModel : AbstractGAModel
	{

		public DefaultGAModel(IIndividualFactory individualFactory, IFitness fitnessAlgorithm)
		: base(individualFactory, fitnessAlgorithm) { }

	}
}

using GALib.Core.IndividualModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.Plugins
{
	public interface IInverse
	{
		void Inverse(List<Individual> individualList, double inverseProbability);
	}
}

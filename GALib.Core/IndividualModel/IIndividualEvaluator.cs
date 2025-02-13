using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public interface IIndividualEvaluator
	{
		void InitIndividualEvaluator();

		void EvaluateIndividuals(IIndividualGroup individuals);

	}
}

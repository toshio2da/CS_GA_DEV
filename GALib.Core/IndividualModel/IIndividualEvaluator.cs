using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public interface IIndividualEvaluator
	{
		void InitIndividualEvaluator();

		void EvaluateIndividuals<TBase>(IIndividualGroup<TBase> individuals);

	}
}

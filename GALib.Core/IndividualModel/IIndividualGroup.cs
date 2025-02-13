using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public enum OrderTypes
	{
		/// <summary>
		/// 適応度の降順ソート
		/// </summary>
		DESC,
		/// <summary>
		/// 適応度の昇順ソート
		/// </summary>
		ASC,
	}
	public interface IIndividualGroup : IEnumerable<Individual>
	{
		OrderTypes OrderType { get; }

		List<Individual> Individuals { get; }

		void AddIndividual(Individual individual);

		void AddIndividuals(IEnumerable<Individual> individuals);

		Individual GetBestIndividual();

		double GetBestFitnessValue();

		Individual GetIndividual(int index);

		void Clear();

		IOrderedEnumerable<Individual> GetOrderedEnumerable();

		void InnerSort();
	}
}

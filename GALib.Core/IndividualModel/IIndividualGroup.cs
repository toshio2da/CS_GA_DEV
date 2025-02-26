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
	public interface IIndividualGroup<TBase> : IEnumerable<Individual<TBase>>
	{
		OrderTypes OrderType { get; }

		List<Individual<TBase>> Individuals { get; }

		void AddIndividual(Individual<TBase>? individual);

		void AddIndividuals(IEnumerable<Individual<TBase>> individuals);

		Individual<TBase>? GetBestIndividual();

		double GetBestFitnessValue();

		Individual<TBase> GetIndividual(int index);

		void Clear();

		IOrderedEnumerable<Individual<TBase>> GetOrderedEnumerable();

		void InnerSort();
	}
}

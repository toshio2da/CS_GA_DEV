using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public abstract class IndividualGroup : IIndividualGroup
	{
		public static IIndividualGroup CreateInstance(OrderTypes orderType)
		{
			IIndividualGroup ret = null!;
			switch (orderType)
			{
				case OrderTypes.DESC:
					ret = new DescIndividualsGroup();
					break;
				case OrderTypes.ASC:
					ret = new AscIndividualsGroup();
					break;
			}
			return ret;
		}

		protected IndividualGroup(OrderTypes orderType)
		{
			OrderType = orderType;
		}

		public OrderTypes OrderType { get; private set; }

		public List<Individual> Individuals { get; private set; } = [];

		public void AddIndividual(Individual individual)
		{
			Individuals.Add(individual);
		}

		public void AddIndividuals(IEnumerable<Individual> individuals)
		{
			Individuals.AddRange(individuals);
		}

		public Individual GetIndividual(int index)
		{
			return Individuals[index];
		}

		public void Clear()
		{
			Individuals.Clear();
		}

		public Individual? GetBestIndividual()
		{
			double bestFitnessValue = GetBestFitnessValue();
			return Individuals.Where(e => e.FitnessValue == bestFitnessValue).FirstOrDefault();
		}

		public abstract double GetBestFitnessValue();

		public abstract IOrderedEnumerable<Individual> GetOrderedEnumerable();

		public void InnerSort()
		{
			Individuals = GetOrderedEnumerable().ToList();
		}

		public IEnumerator<Individual> GetEnumerator()
		{
			return Individuals.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Individuals.GetEnumerator();
		}

		private class AscIndividualsGroup : IndividualGroup
		{
			public AscIndividualsGroup() : base(OrderTypes.ASC) { }

			public override double GetBestFitnessValue()
			{
				return Individuals.Min(e => e.FitnessValue);
			}

			public override IOrderedEnumerable<Individual> GetOrderedEnumerable()
			{
				return Individuals.OrderBy(e => e.FitnessValue);
			}
		}

		private class DescIndividualsGroup : IndividualGroup
		{
			public DescIndividualsGroup() : base(OrderTypes.DESC) { }

			public override double GetBestFitnessValue()
			{
				return Individuals.Max(e => e.FitnessValue);
			}

			public override IOrderedEnumerable<Individual> GetOrderedEnumerable()
			{
				return Individuals.OrderByDescending(e => e.FitnessValue);
			}
		}
	}
}

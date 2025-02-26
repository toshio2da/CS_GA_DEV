using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.IndividualModel
{
	public abstract class IndividualGroup<TBase> : IIndividualGroup<TBase>
	{
		public static IIndividualGroup<TBase> CreateInstance(OrderTypes orderType)
		{
			IIndividualGroup<TBase> ret = null!;
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

		public List<Individual<TBase>> Individuals { get; private set; } = [];

		public void AddIndividual(Individual<TBase> individual)
		{
			Individuals.Add(individual);
		}

		public void AddIndividuals(IEnumerable<Individual<TBase>> individuals)
		{
			Individuals.AddRange(individuals);
		}

		public Individual<TBase> GetIndividual(int index)
		{
			return Individuals[index];
		}

		public void Clear()
		{
			Individuals.Clear();
		}

		public Individual<TBase>? GetBestIndividual()
		{
			double bestFitnessValue = GetBestFitnessValue();
			return Individuals.Where(e => e.FitnessValue == bestFitnessValue).FirstOrDefault();
		}

		public abstract double GetBestFitnessValue();

		public abstract IOrderedEnumerable<Individual<TBase>> GetOrderedEnumerable();

		public void InnerSort()
		{
			Individuals = GetOrderedEnumerable().ToList();
		}

		public IEnumerator<Individual<TBase>> GetEnumerator()
		{
			return Individuals.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Individuals.GetEnumerator();
		}

		private class AscIndividualsGroup : IndividualGroup<TBase>
		{
			public AscIndividualsGroup() : base(OrderTypes.ASC) { }

			public override double GetBestFitnessValue()
			{
				return Individuals.Min(e => e.FitnessValue ?? double.MaxValue);
			}

			public override IOrderedEnumerable<Individual<TBase>> GetOrderedEnumerable()
			{
				return Individuals.OrderBy(e => e.FitnessValue);
			}
		}

		private class DescIndividualsGroup : IndividualGroup<TBase>
		{
			public DescIndividualsGroup() : base(OrderTypes.DESC) { }

			public override double GetBestFitnessValue()
			{
				return Individuals.Max(e => e.FitnessValue ?? double.MinValue);
			}

			public override IOrderedEnumerable<Individual<TBase>> GetOrderedEnumerable()
			{
				return Individuals.OrderByDescending(e => e.FitnessValue);
			}
		}
	}
}

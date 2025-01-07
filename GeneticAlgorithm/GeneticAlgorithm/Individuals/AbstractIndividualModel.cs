using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals
{
	public abstract class AbstractIndividualModel<TBase> : IIndividualModel, ITypedIndividualModel<TBase>
	{
		public AbstractIndividualModel(int genoSize)
		{
			this.GenoSize = genoSize;
		}

		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GenoSize { get; private set; }


		#region IIndividualModel 実装
		public Individual CreateNewIndividual() => new Individual(this, this.CreateNewGene());

		public Individual CreateNewIndividual(IGene gene) => new Individual(this, gene);

		public Individual CreateNewIndividual(object[] baseData) => new Individual(this, this.CreateNewGene(baseData));


		public abstract IGene CreateNewGene();

		public abstract IGene CreateNewGene(IGene gene);

		public abstract IGene CreateNewGene(TBase[] baseData);

		public abstract IGene CreateNewGene(object[] baseData);

		#endregion


		#region ITypedIndividualModel実装

		public Individual CreateNewIndividual(ITypedGene<TBase> gene) => new Individual(this, this.CreateNewGene(gene));

		public Individual CreateNewIndividual(TBase[] baseData) => new Individual(this, this.CreateNewGene(baseData));

		public abstract ITypedGene<TBase> CreateNewTypedGene();

		public abstract ITypedGene<TBase> CreateNewTypedGene(ITypedGene<TBase> gene);

		public abstract ITypedGene<TBase> CreateNewTypedGene(TBase[] baseData);

		public abstract ITypedGene<TBase> CreateNewTypedGene(object[] baseData);
		#endregion
	}
}

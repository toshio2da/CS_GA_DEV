namespace GALib.Core.IndividualModel
{
	public abstract class AbstractIndividualFactory<TBase> : IIndividualFactory, ITypedIndividualFactory<TBase>
	{
		protected AbstractIndividualFactory(int genoSize)
		{
			GenoSize = genoSize;
		}

		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GenoSize { get; private set; }


		#region IIndividualFactory 実装
		public Individual CreateNewIndividual() => new Individual(CreateNewGene());

		public Individual CreateNewIndividual(IGene gene) => new Individual(gene);

		public Individual CreateNewIndividual(object[] baseData) => new Individual(CreateNewGene(baseData));


		public abstract IGene CreateNewGene();

		public abstract IGene CreateNewGene(IGene gene);

		public abstract IGene CreateNewGene(TBase[] baseData);

		public abstract IGene CreateNewGene(object[] baseData);

		#endregion


		#region ITypedIndividualFactory実装

		public Individual CreateNewIndividual(ITypedGene<TBase> gene) => new Individual(CreateNewGene(gene));

		public Individual CreateNewIndividual(TBase[] baseData) => new Individual(CreateNewGene(baseData));

		public abstract ITypedGene<TBase> CreateNewTypedGene();

		public abstract ITypedGene<TBase> CreateNewTypedGene(ITypedGene<TBase> gene);

		public abstract ITypedGene<TBase> CreateNewTypedGene(TBase[] baseData);

		public abstract ITypedGene<TBase> CreateNewTypedGene(object[] baseData);
		#endregion
	}
}

namespace GALib.Core.IndividualModel
{
	public abstract class AbstractIndividualFactory<TBase> : IIndividualFactory<TBase>
	{
		protected AbstractIndividualFactory(int geneSize)
		{
			GeneSize = geneSize;
		}

		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GeneSize { get; private set; }

		public abstract IGene<TBase> CreateNewGene();

		public abstract IGene<TBase> CreateNewGene(IGene<TBase> gene);

		public abstract IGene<TBase> CreateNewGene(TBase[] baseData);

		public abstract IGene<TBase> CreateNewGene(object[] baseData);

		public abstract IGene<TBase> CreateNewRandumGene();


		public Individual<TBase> CreateNewIndividual(IGene<TBase> gene) => new Individual<TBase>(gene);

		public Individual<TBase> CreateNewIndividual(TBase[] baseData) => new Individual<TBase>(CreateNewGene(baseData));

		public Individual<TBase> CreateNewIndividual(object[] baseData) => new Individual<TBase>(CreateNewGene(baseData));

		public Individual<TBase> CreateNewRandumIndividual() => new Individual<TBase>(CreateNewRandumGene());

	}
}

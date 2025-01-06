using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals
{
	public abstract class AbstractIndividualModel<TBase>: IIndividualModel<TBase>
	{
		public AbstractIndividualModel(int genoSize)
		{
			this.GenoSize = genoSize;
		}

		/// <summary>
		/// 自己遺伝子の遺伝子長を取得します
		/// </summary>
		public int GenoSize { get; private set; }

		public abstract ITypedGene<TBase> CreateNewGene();
	}
}

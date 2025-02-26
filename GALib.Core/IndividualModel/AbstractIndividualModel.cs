namespace GALib.Core.IndividualModel
{
	public abstract class AbstractIndividualModel<TBase> : IIndividualModel<TBase>
	{
		public IIndividualFactory<TBase> IndividualFactory { get; private set; }

		public IFitness<TBase> FitnessAlgorithm { get; private set; }

		/// <summary>
		/// 究極個体出現によるキャンセルトークンを取得します
		/// </summary>
		public CancellationTokenSource UltimateCancelToken { get; private set; }


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="individualFactory"></param>
		public AbstractIndividualModel(IIndividualFactory<TBase> individualFactory, IFitness<TBase> fitnessAlgorithm)
		{
			this.IndividualFactory = individualFactory;
			this.FitnessAlgorithm = fitnessAlgorithm;
			this.UltimateCancelToken = new CancellationTokenSource();
		}


		public virtual void InitIndividualModel() { }

		public abstract List<Individual<TBase>> CreateInitIndividuals(int individualCount, CancellationTokenSource? cancelToken = default);

		public abstract void EvaluateIndividuals(List<Individual<TBase>> individuals, CancellationTokenSource? cancelToken = default);


	}
}

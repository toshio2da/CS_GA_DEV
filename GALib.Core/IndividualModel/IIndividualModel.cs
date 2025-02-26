namespace GALib.Core.IndividualModel;

public interface IIndividualModel<TBase>
{
	IIndividualFactory<TBase> IndividualFactory { get; }

	IFitness<TBase> FitnessAlgorithm { get; }


	void InitIndividualModel();

	List<Individual<TBase>> CreateInitIndividuals(int individualCount, CancellationTokenSource? cancelToken = default);

	void EvaluateIndividuals(List<Individual<TBase>> individuals, CancellationTokenSource? cancelToken = default);

	CancellationTokenSource UltimateCancelToken { get; }
}


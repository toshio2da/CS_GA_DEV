namespace GALib.Core.IndividualModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DefaultIndividualModel<TBase> : AbstractIndividualModel<TBase>
{
	public DefaultIndividualModel(IIndividualFactory<TBase> individualFactory, IFitness<TBase> fitnessAlgorithm)
	: base(individualFactory, fitnessAlgorithm) { }


	public override List<Individual<TBase>> CreateInitIndividuals(int individualCount, CancellationTokenSource? cancelToken = default)
	{
		List<Individual<TBase>> ret = new List<Individual<TBase>>();

		//並列で初期個体を生成
		Parallel.For(0, individualCount, index =>
		{
			//Debug.WriteLine($"初期個体生成:{index}:");

			//キャンセル済をチェック
			cancelToken?.Token.ThrowIfCancellationRequested();

			lock (ret)
				ret.Add(IndividualFactory.CreateNewRandumIndividual());
		});

		return ret;
	}


	public override void EvaluateIndividuals(List<Individual<TBase>> individuals, CancellationTokenSource? cancelToken = default)
	{
		individuals
		.AsParallel()
		.WithCancellation(cancelToken.Token)
		.ForAll(individual =>
		{
			//キャンセル済をチェック
			cancelToken.Token.ThrowIfCancellationRequested();

			//適応度を算出
			individual.FitnessValue = FitnessAlgorithm.GetFitnessValue(individual);

			//Debug.WriteLine($"{cnt}:[{individual.FitnessValue}]");
			//Interlocked.Add(ref cnt, 1);

			//究極の個体が現れたらキャンセル
			if (individual.FitnessValue == FitnessAlgorithm.UltimateFitnessValue)
			{
				if (!UltimateCancelToken.IsCancellationRequested && UltimateCancelToken.Token.CanBeCanceled)
				{
					UltimateCancelToken.Cancel();
				}
			}
		});
	}
}

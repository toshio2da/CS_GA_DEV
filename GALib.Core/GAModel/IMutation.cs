using GALib.Core.IndividualModel;

namespace GALib.Core.Plugins
{
	public interface IMutation
	{

		/// <summary>
		/// 集団に対して突然変異操作を行います
		/// </summary>
		/// <param name="individualIterator"></param>
		/// <param name="mutationProbability"></param>
		void Mutation(List<Individual> individualIterator, double mutationProbability);
	}
}

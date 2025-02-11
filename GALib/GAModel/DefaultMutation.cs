using GALib.Core;
using GALib.Core.Plugins;
using GALib.Core.Utils;

namespace GALib.Plugins
{
	public class DefaultMutation : IMutation
	{

		public void Mutation(List<Individual> individualList, double mutationProbability)
		{

			foreach (var individual in individualList)
			{
				IGene gene = individual.Gene;                   // その個体が持つ遺伝子を取得

				//------ 各塩基に対して行う ------//
				for (int geneIndex = 0; geneIndex < gene.GenoSize; geneIndex++)
				{

					//------ 確率のサイコロを振る ------//
					if (RandomGenerator.Random < mutationProbability)
					{
						gene.MutateOneGene(geneIndex);                  // 突然変異
					}
				}
			}
		}
	}
}

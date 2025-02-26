using GALib.Core.IndividualModel;
using GALib.Core.Plugins;
using GALib.Core.Utils;

namespace GALib.Plugins
{
	public class DefaultInverse : IInverse
	{
		public DefaultInverse() { }
		public void Inverse<TBase>(List<Individual<TBase>> individualList, double inverseProbability)
		{
			foreach (var individual in individualList)
			{
				IGene<TBase> gene = individual.Gene;

				//------ 確率のサイコロ以下であれば逆位を行う。逆位点はランダムに生成 ------//
				if (RandomGenerator.Random < inverseProbability)
				{
					gene.InverseSubGene((int)(RandomGenerator.Random * gene.GeneSize), (int)(RandomGenerator.Random * gene.GeneSize));
				}
			}
		}
	}
}

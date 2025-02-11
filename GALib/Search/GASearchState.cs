using GALib.Core;

namespace GALib.Search
{
	public class GASearchState
	{
		internal GASearchState() { }


		public IIndividualGroup SuperiorIndividuals { get; internal set; }

		public Individual BestIndividual => this.SuperiorIndividuals.GetBestIndividual();

		public int GenerationCount { get; set; } = 0;

	}
}

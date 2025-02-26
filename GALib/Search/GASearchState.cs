using GALib.Core.IndividualModel;

namespace GALib.Search
{
	public class GASearchState<TBase>
	{
		internal GASearchState() { }


		public IIndividualGroup<TBase> SuperiorIndividuals { get; internal set; }

		public Individual<TBase>? BestIndividual => this.SuperiorIndividuals.GetBestIndividual();

		public int GenerationCount { get; set; } = 0;

	}
}

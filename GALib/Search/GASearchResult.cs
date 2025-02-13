using GALib.Core.IndividualModel;

namespace GALib.Search
{
	public class GASearchResult
	{
		internal GASearchResult() { }

		public Individual? BestIndividual { get; internal set; }

		public int GenerationCount { get; internal set; }

		public DateTime StartTime { get; internal set; }

		public DateTime EndTime { get; internal set; }

		public bool IsCanceled { get; internal set; }

		public GASearchParam SearchParam { get; internal set; }

		public GASearchState LastSearchState{  get; internal set; }
	}
}

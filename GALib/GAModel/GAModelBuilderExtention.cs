using GALib.Core.GAModel;
using GALib.Plugins;


namespace GALib.GAModel
{
	public static class GAModelBuilderExtention
	{

		public static IGAModel BuildWithDefault(this GAModelBuilder builder)
		{
			if (builder.DefaultGAModel.SelectionAlgorithm == null)
			{
				builder.DefaultGAModel.SelectionAlgorithm = new TournamentSelection();
			}

			if (builder.DefaultGAModel.SurviveAlgorithm == null)
			{
				builder.DefaultGAModel.SurviveAlgorithm = new EliteStrategySurvive();
			}

			if (builder.DefaultGAModel.CrossoverAlgorithm == null)
			{
				builder.DefaultGAModel.CrossoverAlgorithm = new OnePointCrossover();
			}

			if (builder.DefaultGAModel.MutationAlgorithm == null)
			{
				builder.DefaultGAModel.MutationAlgorithm = new DefaultMutation();
			}

			if (builder.DefaultGAModel.InverseAlgorithm == null)
			{
				builder.DefaultGAModel.InverseAlgorithm = new DefaultInverse();
			}

			return builder.Build();
		}
	}
}

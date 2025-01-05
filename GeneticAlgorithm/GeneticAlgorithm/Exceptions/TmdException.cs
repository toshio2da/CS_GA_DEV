namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions
{
	public class TmdException : Exception
	{
		public TmdException(string information) : base(information) { }
		public TmdException(string information, Exception innerException) : base(information, innerException) { }

	}
}

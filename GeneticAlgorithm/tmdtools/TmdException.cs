namespace jp.co.tmdgroup.common.tmdtools
{
	public class TmdException : Exception
	{
		public TmdException(String information) : base(information) { }
		public TmdException(String information, Exception innerException) : base(information, innerException) { }

	}
}

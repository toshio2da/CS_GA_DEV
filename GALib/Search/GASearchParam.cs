namespace GALib.Search
{
	public class GASearchParam
	{
		/// <summary>
		/// 集団の個体数
		/// </summary>
		public int IndividualCount { get; set; } = 200;

		/// <summary>
		/// 最大世代数
		/// </summary>
		public int MaxGenerationCount { get; set; } = 3000;
	}
}

using GALib.Core.Utils;
using GALib.Search;
using GALib.GAModel;
using System.Text;


namespace jp.co.tmdgroup.nqueengasample
{
	/**
	 * <p>タイトル: Genetic Algorithm Library</p>
	 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	 * <p>著作権: Copyright (c) 2001  森本寛</p>
	 * <p>会社名: 株式会社東京マイクロデータ</p>
	 * @author 森本寛
	 * @version 1.0
	 */

	public class NQueenToHtmlConverter(GASearchResult<int> gaSearchResult)
	{

		private const int MIN_CELL_XY = 26;

		public String ToHtml(Size webViewSize)
		{

			int[] gene = gaSearchResult.BestIndividual.Gene.GetBase();
			gene = DataTools.CreateUniqElementArray(gene);

			int tableXY = Math.Min(webViewSize.Width, webViewSize.Height);
			tableXY -= 100;
			int cellXY = Math.Abs(tableXY / gene.Length);

			if (cellXY < MIN_CELL_XY)
			{
				tableXY = MIN_CELL_XY * gene.Length;
				cellXY = MIN_CELL_XY;
			}

			TimeSpan span = TimeSpan.FromTicks(gaSearchResult.EndTime.Ticks - gaSearchResult.StartTime.Ticks);

			StringBuilder buffer = new();

			buffer.Append($"<h3 style='margin:0px;'>スコア：{gaSearchResult.BestIndividual.FitnessValue}</h3>");
			buffer.Append($"<h3 style='margin:0px;'>世代交代数：{gaSearchResult.GenerationCount}</h3>");
			buffer.Append($"<h4 style='margin:0px;'>経過時間：{span.ToString(@"hh\:mm\:ss\.fff")}</h4>");

			buffer.Append($"<table cellpadding='0' cellspacing='0' border='2' style='width:{tableXY}px;height:{tableXY}px;'>  <tbody>");

			for (int rowIndex = 0; rowIndex < gene.Length; rowIndex++)
			{
				buffer.Append($"<tr style='height:{cellXY}px;'>");
				for (int columnIndex = 0; columnIndex < gene.Length; columnIndex++)
				{
					if (gene[rowIndex] == columnIndex)
					{
						buffer.Append($"<td valign='top' align='center' style='width:{cellXY}px;background-color:black;'>");
					}
					else
					{
						buffer.Append($"<td valign='top' align='center' style='width:{cellXY}px;'>");
					}

					buffer.Append("<br></td>");
				}
				buffer.Append("</tr>");
			}

			buffer.Append("</tbody></table>");

			return buffer.ToString();
		}
	}
}
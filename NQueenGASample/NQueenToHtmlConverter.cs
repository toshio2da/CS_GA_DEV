namespace jp.co.tmdgroup.nqueengasample;

using jp.co.tmdgroup.common.GeneticAlgorithm;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;
using jp.co.tmdgroup.common.Utils;

using System.Runtime.CompilerServices;
using System.Text;


/**
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0
 */

public class NQueenToHtmlConverter(GASearchResult gaSearchResult)
{

	public String ToHtml(int webViewWidth)
	{
		int[] gene = (int[])(gaSearchResult.BestIndividual.Gene.GetBase());
		gene = DataTools.CreateUniqElementArray(gene);

		int w = Math.Abs(webViewWidth / gene.Length);

		TimeSpan span = TimeSpan.FromTicks(gaSearchResult.EndTime.Ticks - gaSearchResult.StartTime.Ticks);

		StringBuilder buffer = new();

		buffer.Append($"<h3>スコア：{gaSearchResult.BestIndividual.FitnessValue}</h3>");
		buffer.Append($"<h3>世代交代数：{gaSearchResult.GenerationCnt}</h3>");
		buffer.Append($"<h4>経過時間：{span.ToString(@"hh\:mm\:ss\.fff")}</h4>");

		buffer.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"2\" width=\"" + webViewWidth.ToString() + "\">  <tbody>");

		for (int rowIndex = 0; rowIndex < gene.Length; rowIndex++)
		{
			buffer.Append("<tr height='" + w.ToString() + "'>");
			for (int columnIndex = 0; columnIndex < gene.Length; columnIndex++)
			{
				if (gene[rowIndex] == columnIndex)
				{
					buffer.Append("<td valign=\"top\" align=\"center\" style='background-color:black'>");
				}
				else
				{
					buffer.Append("<td valign=\"top\" align=\"center\">");
				}

				buffer.Append("<br></td>");
			}
			buffer.Append("</tr>");
		}

		buffer.Append("</tbody></table>");

		return buffer.ToString();
	}
}

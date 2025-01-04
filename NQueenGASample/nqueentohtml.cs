namespace jp.co.tmdgroup.nqueengasample;

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

public class NQueenToHtml
{

	public NQueenToHtml()
	{
	}


	public static String ToHtml(int[] gene, int webViewWidth)
	{

		StringBuilder buffer = new();
		int w = Math.Abs(webViewWidth / gene.Length);

		buffer.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"2\" width=\"" + webViewWidth.ToString() + "\">  <tbody>");

		for (int rowIndex = 0; rowIndex < gene.Length; rowIndex++)
		{

			buffer.Append("<tr height='" + w.ToString() + "'>");
			for (int columnIndex = 0; columnIndex < gene.Length; columnIndex++)
			{
				if (gene[rowIndex] == columnIndex)
				{
					//buffer.Append("<img src=\"queen.bmp\">");
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

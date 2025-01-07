using GALib.Core.Models;

namespace GALib.Core;

/**
 * <p>標準の途中経過報告クラスです。標準出力に途中経過を表示します。</p>
 *
 *
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002 森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/12/07)
 */

public class DefaultGeneticReporter : IGeneticReportable
{

	/// <summary>
	/// デフォルトコンストラクタ
	/// </summary>
	public DefaultGeneticReporter() { }


	/**
     * <p>検索の途中経過を標準出力に表示します。</p>
     * 渡された個体を変更しないでください。<br>
     *
     * @param nowBestInvidual 現在における最優秀個体
     * @param resultGenerationNumber 最終的に行った世代交代数
     * @param computationTime 最終的に計算に使用した時間
     */
	public void Report(Individual surperior)
	{

		double fitnessValue = surperior.FitnessValue;
		Console.Write("適応度： ");
		Console.WriteLine(fitnessValue);
	}


	/**
     * <p>検索終了を標準出力に通知します。</p>
     *
     * @param lastSuperior 最終的な最優秀個体
     */
	public void FinishReport(Individual lastSuperior, int resultGenerationNumber, long computationTime)
	{

		Console.WriteLine("検索が完了しました");
		Console.WriteLine("世代交代数: " + resultGenerationNumber);
		Console.WriteLine("計算時間(秒): " + computationTime / 1000);
	}
}

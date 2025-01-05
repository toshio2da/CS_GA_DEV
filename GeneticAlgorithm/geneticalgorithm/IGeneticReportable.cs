using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

namespace jp.co.tmdgroup.common.GeneticAlgorithm;

/**
 * <p>遺伝的アルゴリズムによる検索中の途中経過を得るためのインタフェースです。</p>
 * 本インタフェースの実装クラスをGeneticAlgorithmクラスに渡すと、途中経過として最優秀個体の更新時にreport()
 * メソッドが自動的に呼び出されます。<br>
 * これにより検索の途中経過を知ることができます。<br>
 *
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002 森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/12/07)
 */

public interface IGeneticReportable
{

	/**
     * <p>検索途中に最優秀個体が更新された時に自動で呼び出されます。</p>
     * 渡された個体の情報を決して変更しないでください。<br>
     *
     * @param surperior 現在における最優秀個体
     */
	public void Report(Individual surperior);


	/**
     * <p>検索が終了した時に自動で呼び出されます。</p>
     * 終了通知処理を行ってください。最終的な最優秀個体が渡されます。<br>
     *
     * @param lastSurperior 最終的な最優秀個体
     * @param resultGenerationNumber 最終的に行った世代交代数
     * @param computationTime 最終的に計算に使用した時間
     */
	public void FinishReport(Individual lastSurperior, int resultGenerationNumber, long computationTime);
}

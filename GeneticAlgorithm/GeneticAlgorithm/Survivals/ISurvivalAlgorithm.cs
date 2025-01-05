namespace jp.co.tmdgroup.common.GeneticAlgorithm.Survivals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using System.Collections.Generic;

/**
 * <p>世代交代時に親集団の生存を決めるクラスのインタフェースです。</p>
 * 遺伝的アルゴリズムでは世代交代時に全ての親が死ぬわけではなく、新しい世代と
 * 共にその形を変えずに生き残る場合があります。<br>
 * 親世代の生き残りと新世代との割合は世代間ギャップ[G]によって定められます。<br>
 * <br>
 * 本インタフェースは世代交代時に死滅せずに生き残る親を決める方法を記述します。
 * 代表的なものでは優秀な親集合を順番にそのまま次世代に残す「エリート戦略」と
 * 集団の多様性を維持する「近親者の相殺」などがあげられます。
 * <br>
 * ユーザーは世代間ギャップ[G]を指定する必要があります。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/30)
 */
public interface ISurvivalAlgorithm
{


	/**
     * <p>世代間ギャップ[G]を取得または設定します。</p>
     * 世代間ギャップは 0.0 - 1.0で示されます。<br>
     * G = 1.0 の場合、世代が変わる毎に全ての個体は死滅し、次世代が誕生します。<br>
     * つまり、親集団は生き残りません。<br>
     * G = 0.0 の場合は世代が変わっても全ての親が存続するので遺伝的アルゴリズムは昨日しなくなってしまいます。<br>
     * 一般的には世代間ギャップ[G]はかなり高めに設定されます。0.95 - 1.0が多いようです。<br>
     *
     * @param generationGap 指定する世代間ギャップ
     * @throws OutOfRangeException 指定した世代間ギャップが範囲[0.0 - 1.0]を越えています
     */
	public double GenerationGap { get; set; }

	/**
     * <p>親集団の中で次世代に生存する集団を決定します。</p>
     * 代表的なエリート戦略ではそのまま優秀な親は次世代に引き継がれます。<br>
     * 次世代に引き継がれる集団は元の集団から削除されます。<br>
     * つまり、引数survivorsの数は戻り値集団の数だけ減ることになります。<br>
     *
     * @param survivors 生き残りの親集団
     * @return 次世代に引き継がれる親集団
     * @throws IllegalIndividualException 集団の要素にIndivisualクラスでない要素があります
     */
	public List<Individual> Survive(List<Individual> survivors);
}

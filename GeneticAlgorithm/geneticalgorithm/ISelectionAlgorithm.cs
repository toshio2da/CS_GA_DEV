namespace jp.co.tmdgroup.common.geneticalgorithm;

using System.Collections.Generic;

/**
 * <p>適応度に応じて個体の淘汰を行うクラスのインタフェースです。</p>
 * ここでいう「淘汰」とはn種類の親集合からn個の子供の材料を作り出すことを指します。<br>
 * つまり、この淘汰ではn個の親からn個の子候補を作りだし、数としては変化がありませんが、
 * n子の親のうち、消滅するものもあれば複数個に増えることもあります。<br>
 * これはその親の持つ適応度によって異なります。一般的には適応度が高いもの程多く残り、
 * 適応度の低いものは子の候補になる確率が低くなります。<br>
 * 各個人は既に適応度を保持していなければいけません。<br>
 * <br>
 * 基本的に元の集合にない個体は結果の集合には現れません。<br>
 * そういう意味でこの操作は「選択」とも呼ばれます。<br>
 * <br>
 * 淘汰のアルゴリズムはいろいろありますが、「ルーレット方式」「ランク方式」「トーナメント方式」
 * 等が有名です。全ての淘汰アルゴリズムはこのインタフェースの派生クラスによって記述されます。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/29)
 */
public interface ISelectionAlgorithm
{

	/**
     * <p>親集合から子集合候補を淘汰によって作成します。<br>
     * 集合の数に変更はありませんが、親集合の個人が複数発生することがあります。<br>
     * これは各々の適応度によって異なります。<br>
     * <br>
     * 各個人は適応度を既に保持している必要があります。<br>
     * この適応度はFitnessAlgorithmによって算出された生のデータです。<br>
     * <br>
     * @param group 淘汰を行う親集合。要素は全てIndividualかその派生クラスである必要があります。
     * @return 子集合候補。この集合を用いて新しい世代を創生します。
     * @throws IllegalElementException group内にIndividualまたはその派生クラスではない要素があります。
     */
	public List<Individual> Select(List<Individual> group); //throws IllegalIndividualException;
}

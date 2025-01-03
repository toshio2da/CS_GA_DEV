namespace jp.co.tmdgroup.common.geneticalgorithm;

using jp.co.tmdgroup.common.geneticalgorithm.exception;
using jp.co.tmdgroup.common.geneticalgorithm.model;

/**
 * <p>遺伝的アルゴリズムの基本操作、交叉を行うクラスのインタフェースです。</p>
 * 交叉親集団からランダムに2体を選び、その2体を元に2体の子供を生成します。<br>
 * 交叉の手法はいくつか提案されています。<br>
 * この交叉と突然変異、あるいは逆位によって多様な子供を作成し、優秀な個体を作成していきます。<br>
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

public interface CrossoverAlgorithm
{


    /**
     * <p>親候補集団から交叉を行い、子集団を生成します。</p>
     * 交叉親集団からランダムに2体を選び、その2体を元に2体の子供を生成します。<br>
     * 子供2体の合計遺伝子は親の合計遺伝子と等しくなります。<br>
     * つまり子供2体で親の同じ遺伝子は共有されません。<br>
     *
     * @param perentCandidates 親候補集団。この中からランダムに親を選びます。
     * @param childrenNumber 生成する子集団の数。偶数でなければなりません。
     * @return 生成された子集団
     * @throws IllegalIndividualException perentCandidatesの中にindividualクラスでないオブジェクトが入っています
     */
    public List<Individual> crossover(List<Individual> perentCandidates, int childrenNumber); //throws IllegalIndividualException;
}

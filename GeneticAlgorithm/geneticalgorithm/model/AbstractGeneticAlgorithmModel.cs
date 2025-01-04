namespace jp.co.tmdgroup.common.geneticalgorithm.model;

using jp.co.tmdgroup.common.geneticalgorithm;
/**
 * <p>GeneticAlgorithmインタフェースの提供メソッドのうち、推奨デフォルト値を設定した抽象クラスです。</p>
 * 遺伝的アルゴリズムによる検索を行う上で使用する手法を定めるモデルクラスの抽象クラスです。
 * 突然変異確率を遺伝子長の逆数、逆位確率を0で返します。これは広範囲に渡る問題で適応可能なパラメータ値です。<br>
 * <br>
 * 遺伝的アルゴリズムには大きくわけで4つのステップがあります。<br>
 * 「適応度算出」これは問題によって異なるものです。<br>
 * 「淘汰」これは適応度によってどの個体を子集団の親候補にするかを決定します。<br>
 * 「生存」親集団の中から次世代集団に直接生き残る個体の決め方を定めます。<br>
 * 「生殖」では親集団から次世代の子集団を生成します。交叉や突然変異、逆位などが知られます。<br>
 * <br>
 * 本インタフェースではこれらの様々な手法を実装したクラスをGeneticAlgorithmクラスに与えます。<br>
 * このインタフェースによってGeneticAlgorithmクラスは使用する手法を切り替えることが出来ます。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/11/03)
 */

public abstract class AbstractGeneticAlgorithmModel: IGeneticAlgorithmModel
{


	//=========================================================================//
	//-------------------- GeneticAlgorithmインタフェース実装 --------------------//
	//=========================================================================//

	/**
     * <p>遺伝子の各塩基が突然変異を起こす確率を返します。</p>
     * この確率は各個人の各塩基1つ1つに対して適応されます。<br>
     * つまり、本メソッドが1.0を返すと、全ての個体の全ての遺伝子の全ての塩基がランダムに生成されることになってしまい
     * いつまで経っても収束しないことになってしまいます。<br>
     * 通常は各個体に1つの突然変異が発生するかしないかの値を取ります。<br>
     * つまり、各個体の持つ遺伝子の遺伝子長の逆数が一般的です。<br>
     * 全く突然変位が怒らないようにしてしまうと個体の多様性が維持できず、局所解に収束しやすくなってしまいます。<br>
     * <br>
     * 本メソッドでは遺伝子長の逆数を返します。<br>
     * この値は各個体が突然変異を1つ起こすか起こさないか程度の値です。<br>
     *
     * @return 各塩基の突然変異率。遺伝子長の逆数。
     */
	public double getMutationProbability()
	{

		return (1.0 / (double)this.getIndividualModel().getGenoSize());
	}


	/**
     * <p>個体の遺伝子に逆位が起こる確率を返します。</p>
     * 逆位とは部分遺伝子の順序が逆になる遺伝子操作です。<br>
     * あまり一般的に用いられる操作ではなく、通常は0が設定されます。<br>
     * 逆位が起こるとされた個体の遺伝子はランダムな2点を取り、その間の遺伝子の順序が逆になります。<br>
     * <br>
     * 本メソッドでは0.0を返します。<br>
     * つまり、逆位操作は全く行いません。<br>
     *
     * @return  各個体に逆位が起こる確率
     */
	public double getInverseProbability()
	{

		//------ 逆位操作は行わない ------//
		return 0.0;
	}

	public abstract IIndividual getIndividualModel();
	public abstract FitnessAlgorithm getFitnessAlgorithm();
	public abstract SelectionAlgorithm getSelectionAlgorithm();
	public abstract SurvivalAlgorithm getSurvivalAlgorithm();
	public abstract CrossoverAlgorithm getCrossoverAlgorithm();
}

namespace jp.co.tmdgroup.common.geneticalgorithm.sample;

using jp.co.tmdgroup.common.geneticalgorithm;
using jp.co.tmdgroup.common.geneticalgorithm.exception;
using jp.co.tmdgroup.common.geneticalgorithm.model;

/**
 * <p>代表的なNP完全問題であるN-Queen問題を遺伝的アルゴリズムで解くモデルクラスです。</p>
 * N-Queen問題は式での解法が困難で有名な問題です。<br>
 * N*Nの盤上にN個のクイーンを配置します。<br>
 * ただし、クイーン同士はお互いに取ることができないようにしなければいけません。<br>
 * 解は複数ありますが、Nが大きくなるにしたがって組み合わせ数は累乗に多くなり、解くのが非常に難しくなります。<br>
 * 遺伝子には制限整数配列を用います。各遺伝子の位置が行を表し、中の数字が列を表します。<br>
 * <br>
 * 例えばN=5で、ある個体の遺伝子が<br>
 * <br>
 * [3][1][4][2][0]の場合<br>
 * <br>
 * [×][×][×][Q][×] → 0番目の塩基が3 <br>
 * [×][Q][×][×][×] → 1番目の塩基が1 <br>
 * [×][×][×][×][Q] → 2番目の塩基が4 <br>
 * [×][×][Q][×][×] → 3番目の塩基が2 <br>
 * [Q][×][×][×][×] → 4番目の塩基が0 <br>
 * <br>
 * となり、これが正解の一つになります。<br>
 * 本クラスでは遺伝的アルゴリズムでこの様な解を求めます。<br>
 * <br>
 * 本モデルクラスは遺伝的アルゴリズムを用いてこの問題を解くためのモデルクラスです。
 * 交叉は2点交叉を使用、淘汰にはトーナメント方式を使用します。<br>
 * 世代間ギャップは0.95。生存にはエリート戦略を用います。<br>
 * 突然変異率はデフォルトの遺伝子長の逆数を使用、逆位は行いません。<br>
 * 適応度の計算はお互いに取ることができるQueenが1つにつきペナルティ100の減点方式です。<br>
 * Integer.MAX_VALUEを最大値とし、ペナルティがつかないとこの値をとります。<br>
 * よって最大適応度(究極の個体)の適応度値はInteger.MAX_VALUEとなります。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0   (2002/11/03)
 */

public class NQueenModel : AbstractGeneticAlgorithm
{


	//===================================================//
	//-------------------- メンバ変数 --------------------//
	//===================================================//

	/** N-Queen問題のN。この数だけ盤ができ、クイーンが配置される。 */
	protected int N;

	/** 個体モデル */
	protected IIndividual individualModel;

	/** 適応度計算アルゴリズム。専用のアルゴリズムを用意。 */
	protected IFitnessAlgorithm fitnessAlgorithm;

	/** 淘汰アルゴリズム。トーナメント方式を採用。*/
	protected ISelectionAlgorithm selectionAlgorithm;

	/** 生存アルゴリズム。エリート戦略を採用。*/
	protected ISurvivalAlgorithm survivalAlgorithm;

	/** 交叉アルゴリズム。2点交叉を採用。*/
	protected ICrossoverAlgorithm crossoverAlgorithm;




	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>構築子です。<p>
     * 取り扱うN-Queen問題の次数Nを指定します。<br>
     *
     * @param N 次数Nです
     */
	public NQueenModel(int N)
	{

		try
		{
			//------ 次数Nを設定 ------//
			this.N = N;


			//------ 各モデルインスタンスを作成・保持 ------//
			this.individualModel = new LimitedNumberIndividualModel(this.N, this.N);  // 限定整数配列遺伝子を使用
			this.fitnessAlgorithm = new NQueenFitnessAlgorithm();   //
			this.selectionAlgorithm = new TournamentMethod(2);      // トーナメント方式。トーナメントサイズはデフォルトの2.
			this.survivalAlgorithm = new EliteStrategy(0.95);      // エリート戦略による生存方式を採用。
																   //            this.crossoverAlgorithm = new TwoPointCrossover();      // 交叉は2点交叉。
			this.crossoverAlgorithm = new OnePointCrossover();
		}
		catch (OutOfRangeException exception)
		{

			Console.WriteLine(exception.StackTrace);
			throw;
		}
	}




	//========================================================================================//
	//-------------------- AbstractGeneticAlgorithmModelインタフェースの実装 --------------------//
	//========================================================================================//

	/**
     * <p>使用する個体のモデルを実装するクラスのインスタンスを返します。</p>
     * 個体モデルは個体の遺伝子長、塩基配列などを決定します。<br>
     * 個体モデルは適応度計算アルゴリズムと相互に関係しますが、他のアルゴリズムとは独立ですので、
     * 柔軟な設計を行うことができます。<br>
     * <br>
     * 本モデルクラスでは限定整数配列遺伝子を採用しています。<br>
     *
     * @return 使用する個体のモデルを実装するクラスのインスタンス
     */
	public override IIndividual IndividualModel => this.individualModel;



	/**
     * <p>使用する適応度計算アルゴリズムを実装するクラスのインスタンスを返します。</p>
     * GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
     * 適応度の計算法は問題によって異なります。<br>
     * 適応度の計算クラスは取り扱う個体の遺伝子の塩基タイプと対応している必要があります。<br>
     *
     * @return 使用する適応度計算アルゴリズムを実装するクラスのインスタンス
     */
	public override IFitnessAlgorithm FitnessAlgorithm => this.fitnessAlgorithm;




	/**
     * <p>使用する淘汰アルゴリズムを実装するクラスのインスタンスを返します。</p>
     * GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
     * 本モデルクラスではトーナメント方式を採用しています。
     *
     * @return 使用する淘汰アルゴリズムを実装するクラスのインスタンス
     */
	public override ISelectionAlgorithm SelectionAlgorithm => this.selectionAlgorithm;



	/**
     * 使用する生存アルゴリズムを実装するクラスのインスタンスを返します。</p>
     * GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
     * 生存とは親集団の中から次世代子集団の中にそのまま生き残る個体を指します。<br>
     * 生存割合は世代間ギャップ[G]によって決定されます。G = 1 の時は生存しません。<br>
     * 本モデルクラスではエリート戦略を採用しています。<br>
     *
     * @return 使用する生存アルゴリズムを実装するクラスのインスタンス
     */
	public override ISurvivalAlgorithm SurvivalAlgorithm => this.survivalAlgorithm;



	/**
	 * <p>使用する交叉アルゴリズムを実装するクラスのインスタンスを返します。</p>
	 * GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
	 * 遺伝的アルゴリズムは交叉と突然変異、または逆位によって集団の中から優秀な個体を生成し、最適な解を検索します。<br>
	 * 交叉アルゴリズムには様々なものがありますが、1点交叉と2点交叉が一般的です。<br>
	 * 本モデルクラスでは2点交叉を採用しています。<br>
	 *
	 * @return 使用する交叉アルゴリズムを実装するクラスのインスタンスを返します。
	 */
	public override ICrossoverAlgorithm CrossoverAlgorithm => this.crossoverAlgorithm;

}

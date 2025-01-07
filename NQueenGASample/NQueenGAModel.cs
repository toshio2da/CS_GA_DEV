namespace jp.co.tmdgroup.nqueengasample;

using GALib.Core;
using GALib.Impls.Models;
using GALib.Impls.Plugins;

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

public class NQueenGAModel : AbstractGAModel
{
	/** N-Queen問題のN。この数だけ盤ができ、クイーンが配置される。 */
	private int N;


	/// <summary>
	/// ヘルパコンストラクタ
	/// </summary>
	/// <param name="N">次数</param>
	public NQueenGAModel(int N)
	{
		//------ 次数Nを設定 ------//
		this.N = N;

		//------ 各モデルインスタンスを作成・保持 ------//
		this.IndividualModel = new LimitedNumberIndividualModel(this.N, this.N);  // 限定整数配列遺伝子を使用
		this.FitnessAlgorithm = new NQueenFitnessAlgorithm();   //
		this.SelectionAlgorithm = new TournamentMethod(2);      // トーナメント方式。トーナメントサイズはデフォルトの2.
		this.SurvivalAlgorithm = new EliteStrategy(0.95);      // エリート戦略による生存方式を採用。
		this.CrossoverAlgorithm = new OnePointCrossover();
	}
}

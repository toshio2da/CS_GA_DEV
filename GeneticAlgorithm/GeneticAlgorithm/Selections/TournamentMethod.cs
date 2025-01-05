using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;
using jp.co.tmdgroup.common.Utils;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Selections;
/**
 * <p>トーナメント方式によって淘汰を行います。</p>
 * 親集団より子集団候補を作成するのに用いられる淘汰アルゴリズムの一つです。<br>
 * 親集団中から複数の個体を選び、その中から一番適応度の高いものを選択します。<br>
 * この操作を子集団候補が揃うまで繰り返します。<br>
 * 当然、同一の親が複数回選ばれることもあります。<br>
 * <br>
 * トーナメントサイズによって一度に比べる個体の数を指定することが出来ます。<br>
 * 通常は2が用いられます。デフォルト値も同様に2を採用しています。<br>
 * しかし、ある種の問題では2では淘汰圧が低くなる場合があります。<br>
 * その場合は淘汰圧を高くするとうまく行く場合はあります。<br>
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
public class TournamentMethod : ISelectionAlgorithm
{



	//========================================================//
	//-------------------- 追加メンバ変数 --------------------//
	//========================================================//

	/** トーナメントサイズ。詳細はクラスの説明を参照 */
	protected int tournamentSize = 2;




	//================================================//
	//-------------------- 構築子 --------------------//
	//================================================//

	/**
     * <p>構築子です。</p>
     * トーナメントサイズは2に設定されます。<br>
     */
	public TournamentMethod()
	{
	}



	/**
     * <p>トーナメントサイズを指定して構築を行います。</p>
     * トーナメントサイズによって淘汰圧を加減することができます。<br>
     * デフォルトでは2になりますが、高くすることによって淘汰圧が高まります。<br>
     *
     * @param tournamentSize 指定するトーナメントサイズ。0や負の値が入れられた場合は2となります。
     */
	public TournamentMethod(int tournamentSize)
	{

		//------ トーナメントサイズを設定。不正な値の場合は2になる。 ------//
		this.tournamentSize = tournamentSize > 1 ? tournamentSize : 2;
	}




	//======================================================================//
	//-------------------- インタフェースメソッドの実装 --------------------//
	//======================================================================//

	/**
     * <p>親集合から子集合候補を淘汰によって作成します。</p>
     * 集合の数に変更はありませんが、親集合の個人が複数発生することがあります。<br>
     * これは各々の適応度によって異なります。<br>
     * <br>
     * 各個人は適応度を既に保持している必要があります。<br>
     * この適応度はFitnessAlgorithmによって算出された生のデータです。<br>
     * <br>
     * Tournamentクラスではトーナメント方式によって淘汰を行います。<br>
     * 親集団中から複数の個体を選び、その中から一番適応度の高いものを選択します。<br>
     * この操作を子集団候補が揃うまで繰り返します。<br>
     * 当然、同一の親が複数回選ばれることもあります。<br>
     *
     * @param group 淘汰を行う親集合。要素は全てIndividualかその派生クラスである必要があります。
     * @return 子集合候補。この集合を用いて新しい世代を創生します。
     * @throws IllegalIndividualException group内にIndividualまたはその派生クラスではない要素があります。
     */
	public List<Individual> Select(List<Individual> group)
	{ //throws IllegalIndividualException {

		//------ 元の親集合の数になるまで繰り返す ------//
		List<Individual> candidates = [];                   // 最終的に選ばれた子集団候補者
		List<Individual> preLiminary = [];                     // 予選候補者。この中で適応度の一番高いものが候補者となる。
		for (int index = 0; index < group.Count; index++)
		{

			//------ 一度に選ぶ小集団をランダムに選出 ------//
			preLiminary.Clear();                                                   // 予選候補者を初期化
			for (int candidateIndex = 0; candidateIndex < tournamentSize; candidateIndex++)
			{
				preLiminary.Add(group[(int)(RandomGenerator.Random * group.Count)]);   // ランダムに予選候補者を選出
			}


			//------ 適応度が最大の個体を選出・子集合候補者に追加 ------//
			//Collections.sort(preLiminary);
			preLiminary = preLiminary.OrderByDescending(e => e.FitnessValue).ToList();

			candidates.Add(preLiminary[0]);
		}


		//------ 子集合候補を返す ------//
		return candidates;
	}
}


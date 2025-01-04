
namespace jp.co.tmdgroup.common.geneticalgorithm;
/**
 * <p>エリート戦略による親集団の生き残りアルゴリズムです。</p>
 * エリート戦略では適応度の高い順に並べ、優秀な個体のみを全て次世代に受け継がせます。<br>
 * 適応度の高い個体はいつまでも残ることになります。<br>
 * 生き残る個体の数は世代間ギャップ[G]で決定されます。<br>
 * G = 0.9の時、優秀な10%の親は次世代集団にそのまま残ることになります。<br>
 * エリート戦略を用いると収束が早くなるという利点がありますが、局所解に陥る危険性も高くなります。<br>
 * また、毎回ソートする必要があるので計算コストも高くなります。<br>
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

public class EliteStrategy : AbstractSurvival
{


	//================================================//
	//-------------------- 構築子 --------------------//
	//================================================//

	/**
     * <p>構築子です。</p>
     * 特に何も行いません。<br>
     * 世代間ギャップはデフォルトの1.0が適応されます。
     */
	public EliteStrategy() : base()
	{
	}



	/**
     * <p>世代間ギャップを指定する構築子です。</p>
     *
     * 世代間ギャップは 0.0\uFF5E1.0で示されます。<br>
     * G = 1.0 の場合、世代が変わる毎に全ての個体は死滅し、次世代が誕生します。<br>
     * つまり、親集団は生き残りません。<br>
     * G = 0.0 の場合は世代が変わっても全ての親が存続するので遺伝的アルゴリズムは機能しなくなってしまいます。<br>
     * 一般的には世代間ギャップ[G]はかなり高めに設定されます。0.95-1.0が多いようです。<br>
     *
     * @param generationGap 指定する世代間ギャップ
     * @throws OutOfRangeException 指定した世代間ギャップが範囲[0.0-1.0]を越えています
     */
	public EliteStrategy(double generationGap)
	: base(generationGap)
	{ //throws OutOfRangeException {

		//------ 世代間ギャップを設定して構築 ------//
	}






	//===================================================================================//
	//-------------------- SurvivalAlgorithmインタフェースメソッドの実装 --------------------//
	//===================================================================================//

	/**
     * <p>エリート戦略による親集団の生き残りアルゴリズムです。</p>
     * エリート戦略では適応度の高い順に並べ、優秀な個体のみを全て次世代に受け継がせます。<br>
     * 適応度の高い個体はいつまでも残ることになります。<br>
     * 生き残る個体の数は世代間ギャップ[G]で決定されます。<br>
     * G = 0.9の時、優秀な10%の親は次世代集団にそのまま残ることになります。<br>
     * エリート戦略を用いると収束が早くなるという利点がありますが、局所解に陥る危険性も高くなります。<br>
     * また、毎回ソートする必要があるので計算コストも高くなります。<br>
     * エリート戦略では収束が早くなる反面、局所解に陥りやすいという問題もあります。
     * <br>
     * つまり、引数survivorsの数は戻り値集団の数だけ減ることになります。<br>
     * 与えられた集団は適応度の高い順に並んでいることが前提となっています。<br>
     *
     * @param survivors 生き残り候補の親集団。適応度順にソート済み。
     * @return 次世代に引き継がれるエリート親集団
     * @throws IllegalIndividualException 集団の要素にIndivisualクラスでない要素があります
     */
	public override List<Individual> Survive(List<Individual> survivors)
	{ //throws IllegalIndividualException {

		//------ ソートを行う。 ------//
		//        Collections.sort(survivors);


		//------ 世代間ギャップによって決められた数だけ順に抽出 ------//
		int eliteNumber = (int)(survivors.Count * (1.0 - this.GenerationGap));  // 生き残るエリートの数を計算

		//T.Tsuda
		List<Individual> elites = [.. survivors.GetRange(0, eliteNumber)];

		//List<Individual> elites = new List<Individual>(eliteNumber);                            // 生き残るエリート親集団
		//ListIterator survivorsIterator = survivors.listIterator();//survivors.Count);//.iterator();                        // イテレータを取得

		//for (int eliteIndex = 0; eliteIndex < eliteNumber; eliteIndex++)
		//{

		//	//------ 適応度の高い順にエリート集団に格納・元の集団から削除 ------//
		//	Individual elite = (Individual)survivorsIterator.next();      // エリートを取得
		//	elites.add(elite);                                                  // エリート集団に追加
		//}

		//------ エリート親集団を返す ------//
		return elites;
	}

}

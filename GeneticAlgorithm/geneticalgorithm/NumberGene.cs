namespace jp.co.tmdgroup.common.geneticalgorithm;


using jp.co.tmdgroup.common.geneticalgorithm.exception;
using jp.co.tmdgroup.common.tmdtools;
//using jp.co.tmdgroup.common.geneticalgorithm.algorithm;

/**
 * <p>正の整数配列で遺伝子を表す遺伝子型です。</p>
 * 遺伝的アルゴリズムで使用される遺伝子型でも一般的な塩基タイプです。<br>
 * 遺伝子はすべて整数で表され、その組み合わせて個体の適応度が決定されます。<br>
 * 断片遺伝子は int[]型で表されますので、適切なキャストを行う必要があります。<br>
 * 突然変異は整数型の撮りうる全ての値です。<br>
 * <br>
 * 本クラスを派生し、突然変異の挙動を変えることで使用する範囲を限定した遺伝子型を簡単に構築することが出来ます。<br>
 * 整数配列遺伝子を用いた問題の場合、使用する整数を限定のが一般的であり、また効率的でもあります。<br>
 * そのため、mutateOneGene()メソッドのみfinal宣言をしておらず、オーバーライドが可能です。<br>
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
public class NumberGene : AbstractNumberGene
{
	/**
     * <p>サイズ指定構築子です。</p>
     * 遺伝子はランダムに作成されます<br>
     *
     * @param size  遺伝子の長さ
     */
	public NumberGene(int size) : base(size) {

		//------ 乱数で初期化 ------//
		this.RandumReconstruct();
	}


	/**
     * <p>コピーコンストラクタです。</p>
     * 引数で渡した配列がそのまま使用されます。<br>
     *
     * @param gene  遺伝子整数値塩基配列
     */
	public NumberGene(int[] gene) : base(gene) { }



	/**
     * <p>1塩基に対して突然変異を起こします。</p>
     * 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
     * 突然変位は遺伝子の塩基タイプによって異なります。<br>
     *
     * 整数型遺伝子では 0 ~ 2147483647の範囲の値を取ります。<br>
     * 本メソッドをオーバーライドすることで範囲を限定することもできます。<br>
     * randomReconstruct()メソッドは本メソッドを使用しているため、本メソッドの、
     * オーバーライドのみで範囲限定の整数型遺伝子のクラスを構築することが出来ます。<br>
     *
     * @param genoIndex  突然変異を起こさせる塩基の場所を指定します。
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます。
     */
	public override void MutateOneGene(int genoIndex)
	{
		//------ ランダム整数を代入します ------//
		this.baseData[genoIndex] = (int)(GARandomGenerator.Random * 2147483647);
	}
}

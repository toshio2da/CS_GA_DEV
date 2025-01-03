namespace jp.co.tmdgroup.common.geneticalgorithm;

using jp.co.tmdgroup.common.geneticalgorithm.exception;


/**
 * <p>限定された範囲の正の整数を塩基として持つ遺伝子クラスです。</p>
 * 範囲限定の整数遺伝子は広い用途に用いられます。<br>
 * 突然変異も限定範囲の数の値が使用されます。<br>
 * その他の性質はNumberGeneクラスと同じです。
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/11/01)
 */

public class LimitedNumberGene : NumberGene
{


	//=====================================================//
	//------------------- 追加メンバ変数 --------------------//
	//=====================================================//

	/** 塩基の取りうる指定範囲 */
	protected int limitNumber;




	//==============================================//
	//------------------- 構築子 --------------------//
	//==============================================//

	/**
     * <p>サイズと共に塩基の取りうる範囲の指定構築子です。</p>
     * 遺伝子は範囲内の整数でランダムに作成されます<br>
     *
     * @param size  遺伝子の長さ
     * @param limitNumber  指定範囲です。負の値が渡されたときはその絶対を使用します。
     */
	public LimitedNumberGene(int size, int limitNumber)
	: base(size)
	{

		//------ 基底クラスの構築子を呼ぶ ------//



		//------ 限定範囲を保持。負の整数の場合は絶対値を使用 ------//
		this.limitNumber = Math.Abs(limitNumber);


		//------ 乱数で初期化 ------//
		this.randumReconstruct();

	}



	/**
     * <p>コピーコンストラクタです。</p>
     * 引数で渡した配列がそのまま使用されます。<br>
     *
     * @param gene  遺伝子整数値塩基配列
     * @throws IllegalGenoSizeException 渡された遺伝子の長さが正しくありません
     */
	public LimitedNumberGene(int[] gene) :
	base(gene)//------ 親クラスの構築子を呼び出す ------//
	{ //throws IllegalGenoSizeException {

	}



	//=============================================================================//
	//------------------- 突然変異遺伝子生成メソッドのオーバーライド --------------------//
	//=============================================================================//


	/**
     * <p>1塩基に対して突然変異を起こします。</p>
     * 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
     * 突然変位は遺伝子の塩基タイプによって異なります。<br>
     *
     * ユーザーが指定した限定範囲の値を取ります。<br>
     * 正確には指定した数未満の値を取ります。ユーザーが10を指定した場合、0~9の値となります。
     * randomReconstruct()メソッドは本メソッドを使用しているため、本メソッドの、
     * オーバーライドのみで範囲限定の整数型遺伝子のクラスを構築することが出来ます。<br>
     *
     * @param genoIndex  突然変異を起こさせる塩基の場所を指定します。
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます。
     */
	public void mutateOneGene(int genoIndex)
	{ //throws OutOfBoundsGeneException {
		try
		{

			//------ ランダム整数を代入します ------//
			this.baseData[genoIndex] = (int)(GARandomGenerator.random() * this.limitNumber);
		}
		catch (OutOfRangeException exception)
		{
			throw new OutOfBoundsGeneException();
		}
	}
}

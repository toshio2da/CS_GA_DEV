namespace jp.co.tmdgroup.common.geneticalgorithm.model;

using jp.co.tmdgroup.common.geneticalgorithm;
/**
 * <p>範囲限定の整数型塩基タイプを持つ個体の個体モデルです。</p>
 * 個体モデルのうち、整数型塩基タイプの個体モデルクラスです。<br>
 * 遺伝子長は構築時に与えます。<br>
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

public class LimitedNumberIndividualModel : NumberIndividualModel
{


	//===================================================//
	//-------------------- メンバ変数 --------------------//
	//===================================================//

	/** 自己遺伝子の遺伝子長 */
	protected int limitNumber;




	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>整数型塩基タイプの個体モデルの構築子です。</p>
     * 自己遺伝子の遺伝子長を指定します。<br>
     * 遺伝子長は適応する問題によって異なるのが一般的です。<br>
     * 整数塩基は指定範囲未満の値をとります。<br>
     * limitNumberに10と指定した場合、整数塩基は0~9の値をとります。<br>
     *
     * @param genoSize  自己遺伝子の遺伝子長
     * @param limitNumber  指定範囲です。負の値が渡されたときはその絶対を使用します。
     */
	public LimitedNumberIndividualModel(int genoSize, int limitNumber)
	: base(genoSize)//------ 遺伝子長を保持 ------//
	{
		//------ 範囲を指定 ------//
		this.limitNumber = limitNumber;
	}



	//==========================================================================//
	//-------------------- IndividualModelインタフェースの実装 --------------------//
	//==========================================================================//

	/**
     * <p>新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します。 </p>
     * 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです。<br>
     *
     * @return 新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値。
     */
	public override IGene CreateNewGene()
	{
		//------ 新しく整数配列遺伝子を生成 ------//
		return new LimitedNumberGene(this.GetGenoSize(), this.limitNumber);
	}
}

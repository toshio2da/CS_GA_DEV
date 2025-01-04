namespace jp.co.tmdgroup.common.geneticalgorithm.model;

using jp.co.tmdgroup.common.geneticalgorithm;

/**
 * <p>整数型塩基タイプを持つ個体の個体モデルです。</p>
 * 個体モデルのうち、整数型塩基タイプの個体モデルクラスです。<br>
 * 遺伝子長は構築時に与えます。<br>
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
public class NumberIndividualModel : IIndividual
{


	//===================================================//
	//-------------------- メンバ変数 --------------------//
	//===================================================//

	/** 自己遺伝子の遺伝子長 */
	protected int genoSize;




	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>整数型塩基タイプの個体モデルの構築子です。</p>
     * 自己遺伝子の遺伝子長を指定します。<br>
     * 遺伝子長は適応する問題によって異なるのが一般的です。<br>
     *
     * @param genoSize  自己遺伝子の遺伝子長
     */
	public NumberIndividualModel(int genoSize)
	{

		//------ 遺伝子長を保持 ------//
		this.genoSize = genoSize;
	}




	//==========================================================================//
	//-------------------- IndividualModelインタフェースの実装 --------------------//
	//==========================================================================//

	/**
     * <p>遺伝子の塩基タイプがこの個体モデルにおいて正しいかどうかをチェックします。</p>
     * 渡された遺伝子が整数型の塩基タイプを持つかチェックします。<br>
     * 整数型塩基タイプでなければfalseを返します。
     *
     * @param gene  チェックしたい遺伝子です。
     * @return  正しければtrue, 不正であればfalseを返します。
     */
	public bool isLegalGenoType(IGene gene)
	{

		//------ 試しにキャストしてみる ------//
		bool[]? test = gene.getBase() as bool[];
		return (test != null);

		/*
		try
		{
			//------ 試しにキャストしてみる ------//
			int[] test = (int[])gene.getBase();


			//------ キャスト可能なのでtrueを返す ------//
			return true;
		}
		catch (InvalidCastException exception)
		{

			//------ 塩基タイプが整数型でないのでfalseを返す ------//
			return false;
		}
		*/
	}



	/**
     * <p>自己遺伝子の遺伝子長を取得します。</p>
     * 自己遺伝子の遺伝子長を定義するメソッドです。<br>
     * 本メソッドを実装することで遺伝子長が決定されます。<br>
     * <br>
     * 本抽象クラスでは本メソッドは未実装です。<br>
     * 派生クラスでオーバーライドする必要があります。<br>
     *
     * @return  自己遺伝子の遺伝子長
     */
	public int getGenoSize()
	{

		//------ 遺伝子長を返す ------//
		return this.genoSize;
	}




	/**
     * <p>新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します。 </p>
     * 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです。<br>
     *
     * @return 新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値。
     */
	public IGene createNewGene()
	{

		//------ 新しく整数配列遺伝子を生成 ------//
		return new NumberGene(this.getGenoSize());
	}
}

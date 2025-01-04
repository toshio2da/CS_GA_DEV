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
public class NumberGene : IGene
{


	//==================================================//
	//------------------- メンバ変数 --------------------//
	//==================================================//

	/** 塩基表現。整数値遺伝子 */
	protected int[] baseData;





	//==============================================//
	//------------------- 構築子 --------------------//
	//==============================================//

	/**
     * <p>サイズ指定構築子です。</p>
     * 遺伝子はランダムに作成されます<br>
     *
     * @param size  遺伝子の長さ
     */
	public NumberGene(int size)
	{

		//------ 遺伝子領域を確保 ------//
		this.baseData = new int[size];


		//------ 乱数で初期化 ------//
		this.RandumReconstruct();
	}



	/**
     * <p>コピーコンストラクタです。</p>
     * 引数で渡した配列がそのまま使用されます。<br>
     *
     * @param gene  遺伝子整数値塩基配列
     */
	public NumberGene(int[] gene)
	{

		//------ 渡された参照をそのまま使用します ------//
		this.baseData = gene;
	}




	//======================================//
	//------ Geneインタフェースの実装 ------//
	//======================================//

	/**
     * <p>自己遺伝子の遺伝子長を返します。</p>
     *
     * @return 自己遺伝子の遺伝子長です。
     */
	public int GetGenoSize()
	{

		//------ 自己遺伝子の遺伝子長を返します ------//
		return this.baseData.Length;
	}



	/**
     * <p>遺伝子の塩基配列を返します。</p>
     * この塩基配列を使って適応度の算出などを行います。<br>
     *
     * @return 遺伝子配列
     */
	public object GetBase()
	{

		//------ 塩基配列を返す ------//
		return this.baseData;
	}



	/**
	  * <p>遺伝子断片から個体の遺伝子を生成します。</p>
	  * 渡された遺伝子断片をつなぎ合わせ、生成された遺伝子を自分の遺伝子として保持します。<br>
	  * 遺伝子断片の塩基タイプは遺伝子クラスの塩基タイプと一致している必要があります。<br>
	  * 遺伝子断片はVectorの順番通りに融合されます。<br>
	  * <br>
	  * NumberGeneクラスの場合、piecesOfGeneの各要素はint[]である必要があります。<br>
	  *
	  * @param piecesOfGene  融合する遺伝子断片、塩基タイプは一致していなければないけません
	  * @throws IllegalGenoSizeException  遺伝子断片の合計遺伝子長が本遺伝子の遺伝子長と一致しません(遺伝子不足又は過多)
	  * @throws IllegalGenoTypeException  遺伝子断片の塩基タイプが本遺伝子の塩基タイプと一致しません
	  */
	public void CreateGene(object[] piecesOfGene)
	{ //throws IllegalGenoSizeException, IllegalGenoTypeException {
		try
		{

			//------ 融合した遺伝子を作成 ------//
			int[] newGene = DataTools.FuseIntegerArray(piecesOfGene);       // 2値バイナリ型をつなげる


			//------ 遺伝子長をチェック ------//
			if (newGene.Length != this.GetGenoSize())
			{
				throw new IllegalGenoSizeException();                           // 遺伝子長が正しくないので例外を送出
			}


			//------ 自己遺伝子を更新 ------//
			this.baseData = newGene;

		}
		catch (InvalidCastException exception)
		{

			//------ 塩基タイプが一致しないので例外を送出 ------//
			throw new IllegalGenoTypeException(exception);
		}
	}




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
	public void MutateOneGene(int genoIndex)
	{ //throws OutOfBoundsGeneException {
		try
		{

			//------ ランダム整数を代入します ------//
			this.baseData[genoIndex] = (int)(GARandomGenerator.Random * 2147483647);
		}
		catch (OutOfRangeException exception)
		{
			throw new OutOfBoundsGeneException(exception);
		}
	}




	/**
     * <p>自己遺伝子の部分遺伝子断片を返します</p>
     * 部分遺伝子を返すことで交叉を行うことができます。<br>
     * 部分遺伝子は初端と終端を指定することで抜き出します。<br>
     * 初端と終端の遺伝子も返される部分遺伝子断片に含まれます。<br>
     * 例えば、getSubGene(0, 5) とした場合の返される遺伝子断片の長さは6となります。<br>
     * getSubGene(1,1)とすることで1塩基を抜き出すこともできます。<br>
     *
     * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
     * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
     * @return  抜き出された部分遺伝子断片です
     * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
     */
	public IGene GetSubGene(int firstGenoIndex, int lastGenoIndex)
	{ //throws OutOfBoundsGeneException {

		try
		{

			//------ 抜き出す部分遺伝子断片を作成 ------//
			int[] subGene = new int[lastGenoIndex - firstGenoIndex + 1];


			//------ 指定箇所をコピー ------//
			for (int index = 0; index < subGene.Length; index++)
			{
				subGene[index] = this.baseData[firstGenoIndex + index];
			}


			//------ 部分遺伝子断片を返す ------//
			return new NumberGene(subGene);

		}
		catch (OutOfRangeException exception)
		{
			throw new OutOfBoundsGeneException(exception);                               // 遺伝子長範囲外をアクセスしたため例外を送出
		}
	}




	/**
     * <p>自己遺伝子を全てランダムなもので再構築します。</p>
     * 個体遺伝子の初期化などに用いられます。<br>
     * ランダムな遺伝子は mutateOneGene()メソッドを使用して生成されます。
     */
	public void RandumReconstruct()
	{
		try
		{

			//------ 全塩基を再構築 ------//
			for (int index = 0; index < this.baseData.Length; index++)
			{
				this.MutateOneGene(index);
			}
		}
		catch (OutOfBoundsGeneException exception)
		{
			Console.WriteLine(exception.StackTrace);
		}
	}




	/**
	 * <p>指定した場所の遺伝子に逆位を行います。</p>
	 * 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
	 * あまり一般的に用いられるGAオペレーションではありません。
	 *
	 * @param firstGenoIndex  抜き出す遺伝子断片の初端を指定します
	 * @param lastGenoIndex  抜き出す遺伝子断片の終端を指定します
	 * @throws OutOfBoundsGeneException  遺伝子長範囲内に収まらない場所を指定した場合に送出されます
	 */
	public void InverseSubGene(int firstGenoIndex, int lastGenoIndex)
	{ //throws OutOfBoundsGeneException {

		try
		{

			//------ 逆位を行うために遺伝子断片を作成 ------//
			IGene subGene = this.GetSubGene(firstGenoIndex, lastGenoIndex);
			int[] gene = (int[])subGene.GetBase();


			//------ 逆順にコピー ------//
			for (int index = 0; index < gene.Length; index++)
			{
				this.baseData[firstGenoIndex + index] = gene[gene.Length - index - 1];
			}

		}
		catch (OutOfRangeException exception)
		{
			throw new OutOfBoundsGeneException(exception);                               // 遺伝子長範囲外をアクセスしたため例外を送出
		}
	}
}

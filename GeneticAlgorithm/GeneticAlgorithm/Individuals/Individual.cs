namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/**
 * <p> 個体を表現します。自己遺伝子と、その適応度を保持します。</p>
 * 遺伝的アルゴリズムにおける個体を表現します。<br>
 * 自己の遺伝子を持ち、その遺伝子に対する適応度を保持します。<br>
 * 適応度はFitnessクラスによって行われ、更新されます。<br>
 * 本個体クラスの集合によって集団を構成します。<br>
 * 適応度によってソートを行うためにComparableインタフェースを実装しています。<br>
 * 気をつけていただきたいのは、適応度が高いもの程小さく評価されることです。<br>
 * つまり、適応度が高いほど個体の評価値は小さくなります。<br>
 * これは適応度の高い順番に高速にアクセスするためです。<br>
 * IndivisualModelによって初期化することで遺伝子型を決定します。<br>
 * 各問題に応じて適切な遺伝子クラスを選択し、モデルクラスを実装することで動作します。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/16)
 */
public class Individual : IComparable
{


	//====================================================//
	//-------------------- 保持個体情報 --------------------//
	//====================================================//

	/** 自己を表現する遺伝子。様々な塩基タイプがあります。*/
	protected IGene gene = null!;


	/** 自己遺伝子の適応度。Fitnessクラスによって評価されます。*/
	protected double fitnessValue = 0.0;


	/** 個体の遺伝子モデルを決定するモデルクラスです。*/
	protected IIndividualModel individualModel;




	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>モデル指定構築子です。</p>
     * 構築子でIndivisualModelクラスを指定することで遺伝子型などを選択します。<br>
     * 遺伝子はランダムに生成されます。<br>
     *
     * @param individualModel  個体の設定情報を記述するモデルクラスです。
     */
	public Individual(IIndividualModel individualModel)
	{
		//------ モデルクラスを設定 ------//
		this.individualModel = individualModel;                  // 遺伝子長・タイプを決定。


		//------ ランダムな遺伝子を取得・保持 ------//
		gene = this.individualModel.CreateNewGene();        // モデルクラスに生成させる
	}




	//===============================================================//
	//-------------------- 保持情報アクセスメソッド --------------------//
	//===============================================================//

	/// <summary>
	/// <p>個体の適応度を取得または設定します。</p>
	/// 適応度はFitnessクラスによって評価されます。<br>
	/// Indivisualクラスはその適応度を保持します。<br>
	/// </summary>
	public double FitnessValue
	{
		get =>
		//------ 適応度を返す ------//
		fitnessValue;

		set =>
		//------ 適応度を設定 ------//
		fitnessValue = value;
	}


	/**
     * <p>個体の保持する遺伝子を取得します。</p>
     * 遺伝子の型は構築時に指定されるIndivisualModelによって決定されます。<br>
     *
     * @return  保持遺伝子
     */
	public IGene Gene => gene;



	/**
     * <p>個体の遺伝子情報を設定・更新します。</p>
     * 本メソッドはCrossOverAlgorithm等によって呼び出されます。<br>
     *
     * @param gene  新しく設定する遺伝子です。
     * @throws IllegalGenoSizeException  遺伝子断片の合計遺伝子長が本遺伝子の遺伝子長と一致しません(遺伝子不足又は過多)
     * @throws IllegalGenoTypeException  遺伝子断片の塩基タイプが本遺伝子の塩基タイプと一致しません
     */
	protected void SetGene(IGene gene)
	{ //throws IllegalGenoTypeException, IllegalGenoSizeException {

		//------ 設定する遺伝子情報が正しいかチェック ------//
		if (individualModel.GenoSize != gene.GenoSize)
		{
			throw new IllegalGenoSizeException();                              // 遺伝子長がモデルと一致しないので例外を送出
		}
		if (!individualModel.IsLegalGenoType(gene))
		{
			throw new IllegalGenoTypeException();                               // 塩基タイプがモデルと一致しないので例外を送出
		}


		//------ 問題がないので遺伝子を設定 ------//
		this.gene = gene;
	}


	/**
     * 適応されているIndividualModeクラスを返します。
     *
     * @return 適応されているモデルクラス
     */
	public IIndividualModel IndividualModel => individualModel;



	//====================================================//
	//-------------------- Comparable --------------------//
	//====================================================//

	/**
     * <p>インタフェースComparableの実装メソッドです。ソートに利用されます。</p>
     * 個体の比較は保持している適応度によって行われます。<br>
     * 適応度は高い程小さいと評価されます。<br>
     * これは適応度の高い個体の高速アクセスのためです。<br>
     * 非直感的ですが、ユーザーは意識する必要はありません。<br>
     *
     * @param object 比較する対象のIndivisualインスタンスです。
     * @return 比較結果。自分が小さい場合には負の数。同じ場合はゼロ。大きい場合は正の数を返します。
     */
	public int CompareTo(object? other)
	{
		//T.Tsuda
		if (other == null) return 1;
		if (other is not Individual) return 1;


		//------ 適当度を用いて比較 ------//
		double targetFitnessValue = ((Individual)other).FitnessValue;
		if (fitnessValue > targetFitnessValue)
		{
			return -1;                                                          // 対象よりも適応度が高いので負の数を返す（適応度の高い個体ほど小さいと評価される)
		}
		else
		{
			return fitnessValue == targetFitnessValue ? 0 : 1;           // 対象と同じであればゼロ、自分の適応度が大きければ正の数を返す
		}
	}
}

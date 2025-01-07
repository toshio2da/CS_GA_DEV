namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm;
using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/// <summary>
/// <p>範囲限定の整数型塩基タイプを持つ個体の個体モデルです。</p>
/// 個体モデルのうち、整数型塩基タイプの個体モデルクラスです。<br>
/// 遺伝子長は構築時に与えます。<br>
/// <br>
/// <br>
/// <br>
/// <p>タイトル: Genetic Algorithm Library</p>
/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
/// <p>著作権: Copyright (c) 2001  森本寛</p>
/// <p>会社名: 株式会社東京マイクロデータ</p>
/// @author 森本寛
/// @version 1.0 (2002/11/01)
/// </summary>

public class LimitedNumberIndividualModel : AbstractIndividualModel<int>
{
	/** 自己遺伝子の遺伝子長 */
	private int limitNumber;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="size">自己遺伝子の遺伝子長</param>
	/// <param name="limitNumber">指定範囲です。負の値が渡されたときはその絶対を使用します</param>
	public LimitedNumberIndividualModel(int size, int limitNumber) : base(size)
	{
		this.limitNumber = limitNumber;
	}

	public override IGene CreateNewGene() => new LimitedNumberGene(this.GenoSize, this.limitNumber);

	public override IGene CreateNewGene(IGene gene) => new LimitedNumberGene(gene, this.limitNumber);

	public override IGene CreateNewGene(int[] baseData) => new LimitedNumberGene(baseData, this.limitNumber);

	public override IGene CreateNewGene(object[] baseData) => new LimitedNumberGene(baseData, this.limitNumber);


	public override ITypedGene<int> CreateNewTypedGene()
	{
		var ret = new LimitedNumberGene(this.GenoSize, this.limitNumber);
		ret.RandumReconstruct();
		return ret;
	}

	public override ITypedGene<int> CreateNewTypedGene(ITypedGene<int> gene) => new LimitedNumberGene(gene, this.limitNumber);


	public override ITypedGene<int> CreateNewTypedGene(int[] baseData) => new LimitedNumberGene(baseData, this.limitNumber);


	public override ITypedGene<int> CreateNewTypedGene(object[] baseData) => new LimitedNumberGene(baseData, this.limitNumber);

}

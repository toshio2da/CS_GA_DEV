namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/**
 * <p>2値塩基タイプを持つ個体の個体モデルです。抽象クラスです。</p>
 * 個体モデルのうち、2値塩基タイプの個体モデルの基底クラスです。<br>
 * 塩基タイプチェックメソッド isLegalGenoType()は実装済みです。<br>
 * 遺伝子長チェックメソッドは構築時に与えたサイズを返します。<br>
 */

public class BinaryIndividualModel : AbstractIndividualModel<bool>
{
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="genoSize">自己遺伝子の遺伝子長</param>
	public BinaryIndividualModel(int genoSize) : base(genoSize) { }

	/// <summary>
	/// 新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します
	/// </summary>
	/// <remarks>
	/// 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです
	/// </remarks>
	/// <returns>新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値</returns>
	public override ITypedGene<bool> CreateNewGene()
	{
		//------ 新しく2値遺伝子を生成、返す ------//
		return new BinaryGene(this.GenoSize);
	}
}

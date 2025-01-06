namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm;
using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

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
public class NumberIndividualModel : AbstractIndividualModel<int>
{
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="genoSize">自己遺伝子の遺伝子長</param>
	public NumberIndividualModel(int genoSize) : base(genoSize) { }

	/// <summary>
	/// 新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します
	/// </summary>
	/// <remarks>
	/// 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです
	/// </remarks>
	/// <returns>新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値</returns>
	public override ITypedGene<int> CreateNewGene()
	{
		//------ 新しく整数配列遺伝子を生成 ------//
		return new NumberGene(this.GenoSize);
	}
}

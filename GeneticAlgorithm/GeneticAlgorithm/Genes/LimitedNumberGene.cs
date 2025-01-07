namespace jp.co.tmdgroup.common.GeneticAlgorithm;

using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;
using jp.co.tmdgroup.common.Utils;

/// <summary>
/// <p>限定された範囲の正の整数を塩基として持つ遺伝子クラスです。</p>
/// 範囲限定の整数遺伝子は広い用途に用いられます。<br>
/// 突然変異も限定範囲の数の値が使用されます。<br>
/// その他の性質はNumberGeneクラスと同じです。
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
public class LimitedNumberGene : AbstractTypedGene<int>
{
	/** 塩基の取りうる指定範囲 */
	protected int limitNumber;

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="size">遺伝子の長さ</param>
	/// <param name="limitNumber">指定範囲です。負の値が渡されたときはその絶対を使用します。</param>
	public LimitedNumberGene(int size, int limitNumber) : base(size)
	{
		//------ 限定範囲を保持。負の整数の場合は絶対値を使用 ------//
		this.limitNumber = Math.Abs(limitNumber);

		//------ 乱数で初期化 ------//
		this.RandumReconstruct();
	}

	protected override AbstractTypedGene<int> GetNewGeneInstance()
	{
		return new LimitedNumberGene(GenoSize, limitNumber);
	}

	protected override int GetMutateValue()
	{
		return (int)(RandomGenerator.Random * this.limitNumber);
	}
}
using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.Utils;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/// <summary>
/// <p>2値配列で遺伝子を表す遺伝子型です。</p>
/// 遺伝的アルゴリズムで使用される遺伝子型でも最も一般的な塩基タイプです。<br>
/// 遺伝子はすべてtrue, falseで表され、その組み合わせて個体の適応度が決定されます。<br>
/// 断片遺伝子は bool[]型で表されますので、適切なキャストを行う必要があります。<br>
/// 突然変異は true ←→ false の反転で表されます。<br>
/// <br>
/// <br>
/// <br>
/// <p>タイトル: Genetic Algorithm Library</p>
/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
/// <p>著作権: Copyright (c) 2002  森本寛</p>
/// <p>会社名: 株式会社東京マイクロデータ</p>
/// @author 森本寛
/// @version 1.0 (2002/10/16)
/// </summary>
public class BinaryGene : AbstractTypedGene<bool>
{
	///// <summary>
	///// コンストラクタ
	///// </summary>
	///// <param name="size">遺伝子の長さ</param>
	public BinaryGene(int size) : base(size)
	{
		//------ 乱数で初期化 ------//
		this.RandumReconstruct();
	}

	public override Type GeneType => typeof(BinaryGene);

	protected override bool GetMutateValue()
	{
		return RandomGenerator.Random < 0.5;                         // 0.5未満だったら
	}
}
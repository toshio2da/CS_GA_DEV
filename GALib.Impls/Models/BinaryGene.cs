using GALib.Core.Models;
using GALib.Core.Utils;

namespace GALib.Impls.Models
{

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
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="geneSize">遺伝子の長さ</param>
		internal BinaryGene(int geneSize) : base(geneSize) { }

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子</param>
		internal BinaryGene(IGene gene) : base(gene) { }

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子</param>
		internal BinaryGene(ITypedGene<bool> gene) : base(gene) { }

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		internal BinaryGene(object[] baseData) : base(baseData) { }


		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		public BinaryGene(bool[] baseData) : base(baseData) { }

		protected override AbstractTypedGene<bool> GetNewGeneInstance()
		{
			return new BinaryGene(GenoSize);
		}

		protected override bool GetMutateValue()
		{
			return RandomGenerator.Random < 0.5;                         // 0.5未満だったら
		}
	}
}
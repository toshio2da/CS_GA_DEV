using GALib.Core.Models;
using GALib.Core.Utils;

namespace GALib.Impls.Models
{
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
		/// <param name="geneSize">遺伝子の長さ</param>
		internal LimitedNumberGene(int geneSize, int limitNumber) : base(geneSize)
		{
			this.limitNumber = Math.Abs(limitNumber);
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子</param>
		internal LimitedNumberGene(IGene gene, int limitNumber) : base(gene)
		{
			this.limitNumber = Math.Abs(limitNumber);
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="gene">遺伝子</param>
		internal LimitedNumberGene(ITypedGene<int> gene, int limitNumber) : base(gene)
		{
			this.limitNumber = Math.Abs(limitNumber);
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		internal LimitedNumberGene(int[] baseData, int limitNumber) : base(baseData)
		{
			this.limitNumber = Math.Abs(limitNumber);
		}

		/// <summary>
		/// コピーコンストラクタ
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		internal LimitedNumberGene(object[] baseData, int limitNumber) : base(baseData)
		{
			this.limitNumber = Math.Abs(limitNumber);
		}

		protected override AbstractTypedGene<int> GetNewGeneInstance()
		{
			return new LimitedNumberGene(GenoSize, limitNumber);
		}

		protected override int GetMutateValue()
		{
			return (int)(RandomGenerator.Random * limitNumber);
		}
	}
}
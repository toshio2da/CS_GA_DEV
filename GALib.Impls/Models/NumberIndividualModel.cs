using GALib.Core.Models;

namespace GALib.Impls.Models
{
	/// <summary>
	/// <p>整数型塩基タイプを持つ個体の個体モデルです。</p>
	/// 個体モデルのうち、整数型塩基タイプの個体モデルクラスです。<br>
	/// 遺伝子長は構築時に与えます。<br>
	/// <br>
	/// <br>
	/// <br>
	/// <p>タイトル: Genetic Algorithm Library</p>
	/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	/// <p>著作権: Copyright (c) 2002  森本寛</p>
	/// <p>会社名: 株式会社東京マイクロデータ</p>
	/// @author 森本寛
	/// @version 1.0 (2002/10/30)
	/// </summary>
	public class NumberIndividualModel : AbstractIndividualModel<int>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="genoSize">自己遺伝子の遺伝子長</param>
		public NumberIndividualModel(int genoSize) : base(genoSize) { }

		public override IGene CreateNewGene()
		{
			return new NumberGene(GenoSize);
		}

		public override IGene CreateNewGene(IGene gene)
		{
			return new NumberGene(gene);
		}

		public override IGene CreateNewGene(int[] baseData)
		{
			return new NumberGene(baseData);
		}

		public override IGene CreateNewGene(object[] baseData)
		{
			return new NumberGene(baseData);
		}

		public override ITypedGene<int> CreateNewTypedGene()
		{
			var ret = new NumberGene(GenoSize);
			ret.RandumReconstruct();
			return ret;
		}

		public override ITypedGene<int> CreateNewTypedGene(ITypedGene<int> gene)
		{
			return new NumberGene(gene);
		}

		public override ITypedGene<int> CreateNewTypedGene(int[] baseData)
		{
			return new NumberGene(baseData);
		}

		public override ITypedGene<int> CreateNewTypedGene(object[] baseData)
		{
			return new NumberGene(baseData);
		}
	}
}
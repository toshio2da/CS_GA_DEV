using GALib.Core.IndividualModel;

namespace GALib.IndividualModel
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
	public class NumberIndividualFactory : AbstractIndividualFactory<int>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="geneSize">自己遺伝子の遺伝子長</param>
		public NumberIndividualFactory(int geneSize) : base(geneSize) { }

		public override IGene<int> CreateNewGene() => new NumberGene(GeneSize);
		
		public override IGene<int> CreateNewGene(IGene<int> gene)=>new NumberGene(gene);
		
		public override IGene<int> CreateNewGene(int[] baseData)=> new NumberGene(baseData);
		
		public override IGene<int> CreateNewGene(object[] baseData)=>new NumberGene(baseData);
		
		public override IGene<int> CreateNewRandumGene()
		{
			var ret = new NumberGene(GeneSize);
			ret.RandumReconstruct();
			return ret;
		}
	}
}
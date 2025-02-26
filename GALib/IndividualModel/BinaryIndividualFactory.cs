using GALib.Core.IndividualModel;

namespace GALib.IndividualModel
{
	/// <summary>
	/// <p>2値塩基タイプを持つ個体の個体モデルです。抽象クラスです。</p>
	/// 個体モデルのうち、2値塩基タイプの個体モデルの基底クラスです。<br>
	/// 塩基タイプチェックメソッド isLegalGeneType()は実装済みです。<br>
	/// 遺伝子長チェックメソッドは構築時に与えたサイズを返します。<br>
	/// </summary>
	public class BinaryIndividualFactory : AbstractIndividualFactory<bool>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="geneSize">自己遺伝子の遺伝子長</param>
		public BinaryIndividualFactory(int geneSize) : base(geneSize) { }

		public override IGene<bool> CreateNewGene() => new BinaryGene(GeneSize);

		public override IGene<bool> CreateNewGene(IGene<bool> gene) => new BinaryGene(gene);

		public override IGene<bool> CreateNewGene(bool[] baseData) => new BinaryGene(baseData);

		public override IGene<bool> CreateNewGene(object[] baseData) => new BinaryGene(baseData);

		public override IGene<bool> CreateNewRandumGene()
		{
			var ret = new BinaryGene(GeneSize);
			ret.RandumReconstruct();
			return ret;
		}
	}
}
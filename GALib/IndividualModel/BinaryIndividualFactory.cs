using GALib.Core.IndividualModel;

namespace GALib.IndividualModel
{
	/// <summary>
	/// <p>2値塩基タイプを持つ個体の個体モデルです。抽象クラスです。</p>
	/// 個体モデルのうち、2値塩基タイプの個体モデルの基底クラスです。<br>
	/// 塩基タイプチェックメソッド isLegalGenoType()は実装済みです。<br>
	/// 遺伝子長チェックメソッドは構築時に与えたサイズを返します。<br>
	/// </summary>
	public class BinaryIndividualFactory : AbstractIndividualFactory<bool>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="genoSize">自己遺伝子の遺伝子長</param>
		public BinaryIndividualFactory(int genoSize) : base(genoSize) { }

		public override IGene CreateNewGene() => new BinaryGene(GenoSize);

		public override IGene CreateNewGene(IGene gene) => new BinaryGene(gene);

		public override IGene CreateNewGene(bool[] baseData) => new BinaryGene(baseData);

		public override IGene CreateNewGene(object[] baseData) => new BinaryGene(baseData);

		public override ITypedGene<bool> CreateNewTypedGene()
		{
			var ret = new BinaryGene(GenoSize);
			ret.RandumReconstruct();
			return ret;
		}

		public override ITypedGene<bool> CreateNewTypedGene(ITypedGene<bool> gene) => new BinaryGene(gene);

		public override ITypedGene<bool> CreateNewTypedGene(bool[] baseData) => new BinaryGene(baseData);

		public override ITypedGene<bool> CreateNewTypedGene(object[] baseData) => new BinaryGene(baseData);
	}
}
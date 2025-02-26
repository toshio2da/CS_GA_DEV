using GALib.Core.IndividualModel;

namespace GALib.IndividualModel
{
	/// <summary>
	/// <p>範囲限定の整数型塩基タイプを持つ個体の個体モデルです。</p>
	/// 個体モデルのうち、整数型塩基タイプの個体モデルクラスです。<br>
	/// 遺伝子長は構築時に与えます。<br>
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

	public class LimitedNumberIndividualFactory : AbstractIndividualFactory<int>
	{
		/** 自己遺伝子の遺伝子長 */
		private int limitNumber;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="size">自己遺伝子の遺伝子長</param>
		/// <param name="limitNumber">指定範囲です。負の値が渡されたときはその絶対を使用します</param>
		public LimitedNumberIndividualFactory(int size, int limitNumber) : base(size)
		{
			this.limitNumber = limitNumber;
		}

		public override IGene<int> CreateNewGene() => new LimitedNumberGene(GeneSize, limitNumber);

		public override IGene<int> CreateNewGene(IGene<int> gene) => new LimitedNumberGene(gene, limitNumber);

		public override IGene<int> CreateNewGene(int[] baseData) => new LimitedNumberGene(baseData, limitNumber);

		public override IGene<int> CreateNewGene(object[] baseData) => new LimitedNumberGene(baseData, limitNumber);


		public override IGene<int> CreateNewRandumGene()
		{
			var ret = new LimitedNumberGene(GeneSize, limitNumber);
			ret.RandumReconstruct();
			return ret;
		}
	}
}
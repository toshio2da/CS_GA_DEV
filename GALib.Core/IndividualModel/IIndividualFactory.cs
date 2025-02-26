namespace GALib.Core.IndividualModel
{
	/// <summary>
	/// <p>個体クラスIndividualの挙動を設定するモデルクラスの基底クラスです。</p>
	/// 本インタフェースを実装したクラスによってIndividualの性質を決定します。<br>
	/// 個体の遺伝子情報は遺伝子の塩基タイプと遺伝子の長さで決定されます。<br>
	/// 個体モデルはその両方を実装、決定する必要があります。<br>
	/// <br>
	/// 本インタフェースの実装クラスは必ず標準構築子を持つ必要があり、かつ引数指定のコンストラクタを宣言しないでください。<br>
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
	public interface IIndividualFactory<TBase>
	{
		int GeneSize { get; }
		IGene<TBase> CreateNewGene();

		IGene<TBase> CreateNewGene(IGene<TBase> gene);

		IGene<TBase> CreateNewGene(TBase[] baseData);

		IGene<TBase> CreateNewGene(object[] baseData);

		IGene<TBase> CreateNewRandumGene();


		Individual<TBase> CreateNewIndividual(IGene<TBase> gene);

		Individual<TBase> CreateNewIndividual(TBase[] baseData);

		Individual<TBase> CreateNewIndividual(object[] baseData);

		Individual<TBase> CreateNewRandumIndividual();

	}
}

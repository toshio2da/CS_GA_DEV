namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

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
public interface ITypedIndividualModel<TBase> : IIndividualModel
{
	public Individual CreateNewIndividual(ITypedGene<TBase> gene);

	public Individual CreateNewIndividual(TBase[] baseData);

	public ITypedGene<TBase> CreateNewTypedGene();

	public ITypedGene<TBase> CreateNewTypedGene(ITypedGene<TBase> gene);

	public ITypedGene<TBase> CreateNewTypedGene(TBase[] baseData);

	public ITypedGene<TBase> CreateNewTypedGene(object[] baseData);
}

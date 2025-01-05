namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/**
 * <p>個体クラスIndividualの挙動を設定するモデルクラスの基底クラスです。</p>
 * 本インタフェースを実装したクラスによってIndividualの性質を決定します。<br>
 * 個体の遺伝子情報は遺伝子の塩基タイプと遺伝子の長さで決定されます。<br>
 * 個体モデルはその両方を実装、決定する必要があります。<br>
 * <br>
 * 本インタフェースの実装クラスは必ず標準構築子を持つ必要があり、かつ引数指定のコンストラクタを宣言しないでください。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/16)
 */
public interface IIndividualModel
{
	/// <summary>
	/// 自己遺伝子の遺伝子長を取得します
	/// </summary>
	public int GenoSize{ get; }

	/// <summary>
	/// 遺伝子の塩基タイプがこの個体モデルにおいて正しいかどうかをチェックします
	/// </summary>
	/// <remarks>
	///　渡された遺伝子が整数型の塩基タイプを持つかチェックします。<br>
	///　整数型塩基タイプでなければfalseを返します。
	/// </remarks>
	/// <param name="gene">チェックしたい遺伝子です</param>
	/// <returns>正しければtrue, 不正であればfalseを返します</returns>
	public bool IsLegalGenoType(IGene gene);

	/// <summary>
	/// 新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します
	/// </summary>
	/// <remarks>
	/// 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです
	/// </remarks>
	/// <returns>新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値</returns>
	public IGene CreateNewGene();

}

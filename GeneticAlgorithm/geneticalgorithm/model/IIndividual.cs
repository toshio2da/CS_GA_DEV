namespace jp.co.tmdgroup.common.geneticalgorithm.model;

using jp.co.tmdgroup.common.geneticalgorithm;

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
public interface IIndividual
{

	/**
     * <p>自己遺伝子の遺伝子長を取得します。</p>
     * 自己遺伝子の遺伝子長を定義するメソッドです。<br>
     * 本メソッドを実装することで遺伝子長が決定されます。<br>
     *
     * @return  自己遺伝子の遺伝子長
     */
	public int getGenoSize();



	/**
     * <p>遺伝子の塩基タイプがこの個体モデルにおいて正しいかどうかをチェックします。</p>
     *
     * @param gene  チェックしたい遺伝子です。
     * @return  正しければtrue, 不正であればfalseを返します。
     */
	public bool isLegalGenoType(IGene gene);



	/**
     * <p>新しい遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します。 </p>
     * 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです。<br>
     * また、isLegalGenoType()メソッドで正しいと判断される塩基タイプを持っています。<br>
     *
     * @return 新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値。
     */
	public IGene createNewGene();

}

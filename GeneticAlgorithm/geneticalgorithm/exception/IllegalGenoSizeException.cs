namespace jp.co.tmdgroup.common.geneticalgorithm.exception;

/**
 * <p>遺伝子長が正しくない時に送出されます。</p>
 * 交叉時の場合に本例外送出された場合は遺伝子断片の合計長が個体の遺伝子長と一致しないことを表します。
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0   2002/10/16
 */
public class IllegalGenoSizeException : GeneticAlgorithmException
{

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public IllegalGenoSizeException()
	{
	}
}

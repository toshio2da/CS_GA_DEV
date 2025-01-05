namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

/**
 * <p>交叉や突然変位操作の時、遺伝子長を越える場所、または負の値を指定したときに送出されいます。</p>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/30)
 */
public class OutOfBoundsGeneException : GeneticAlgorithmException
{


	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public OutOfBoundsGeneException() { }

	public OutOfBoundsGeneException(Exception innerException) : base(innerException) { }
}

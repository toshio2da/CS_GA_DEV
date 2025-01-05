namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

/**
 * <p>与えた値や位置情報が指定範囲外であった場合に送出されます。</p>
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

public class OutOfRangeException : GeneticAlgorithmException
{


	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public OutOfRangeException() { }

	public OutOfRangeException(Exception innerException) : base(innerException) { }

}

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

/**
 * <p>遺伝子の塩基タイプが不正な場合に送出されます</p>
 * 交叉時などに渡された遺伝子断片が異なる塩基タイプ(byte[]とint[]など)を持つ場合、<br>
 * または適応度計算を行う場合にサポートされていない塩基タイプの遺伝子が渡されたときに送出される例外です。
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
public class IllegalGenoTypeException : GeneticAlgorithmException
{


	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public IllegalGenoTypeException() { }

	public IllegalGenoTypeException(Exception innerException) : base(innerException) { }
}

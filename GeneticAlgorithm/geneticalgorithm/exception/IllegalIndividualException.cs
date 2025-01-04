namespace jp.co.tmdgroup.common.geneticalgorithm.exception;

/**
 * <p>渡された集合が不正な要素を保持しています。</p>
 * 集合に保持されている要素が必要とされているクラスまたはその派生クラスではありません。<br>
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
public class IllegalIndividualException : GeneticAlgorithmException
{


	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public IllegalIndividualException() { }

	public IllegalIndividualException(Exception innerException) : base(innerException) { }

}

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

/**
 * <p>タイトル: Generic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/30)
 */

public class IllegalElementException : TmdSearchException
{

	public IllegalElementException(string information) : base(information) { }
	public IllegalElementException(string information, Exception innerException) : base(information, innerException) { }

}

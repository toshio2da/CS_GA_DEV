﻿namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
/**
 * <p>タイトル: Generic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0
 */

public class IllegalParameterTypeException : TmdSearchException
{

	public IllegalParameterTypeException(string information) : base(information) { }

	public IllegalParameterTypeException(string information, Exception innerException) : base(information, innerException) { }
}

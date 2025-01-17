﻿namespace jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;

/**
 * <p>遺伝的アルゴルズムライブラリで送出される全ての例外クラスの基底クラス。</p>
 * この例外を補足することで本ライブラリ独自例外を全てつかまえることができます。<br>
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
public class GeneticAlgorithmException : Exception
{


	//===============================================//
	//-------------------- 構築子 --------------------//
	//===============================================//

	/**
     * <p>デフォルト構築子。</p>
     *
     * 最終更新バージョン：1.0
     */
	public GeneticAlgorithmException() { }

	public GeneticAlgorithmException(Exception innerException) : base(innerException.Message, innerException) { }

}

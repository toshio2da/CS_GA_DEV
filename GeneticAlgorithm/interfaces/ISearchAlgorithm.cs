namespace jp.co.tmdgroup.common.interfaces;

using jp.co.tmdgroup.common.geneticalgorithm;

/**
 * <p>検索を行うクラス群の基本インタフェースです。</p>
 * 本インタフェースを実装する形で検査クラスを作成することでそれらのクラスを一意的に取り扱うことができます。<br>
 * 検索法は山登り法、遺伝的アルゴリズム、シンプレックス法など様々なものがあります。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: TMD Interfaces</p>
 * <p>説明: 基本インタフェース群</p>
 * <p>著作権: Copyright (c) 2001  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0   2002/11/01
 */

public interface ISearchAlgorithm
{


	/**
     * <p>検索を行います。</p>
     *
     * @return 検索結果のオブジェクト
     */
	public Individual Search(int maxIterationNumber);
	//throws IllegalParameterTypeException, IllegalParameterSizeException, IllegalElementException, ArgumentOutOfRangeException;


	/**
     * <p>内部の状態を初期状態に戻します。</p>
     */
	public void Reset();
}

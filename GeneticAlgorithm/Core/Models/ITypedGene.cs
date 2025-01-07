namespace GALib.Core.Models;
/// <summary>
/// <p>個体の持つ遺伝子情報を持つクラスのインタフェースです。</p>
/// 遺伝子は様々な塩基タイプを持っており、それらの共通インタフェースとして本インタフェースを使用します。<br>
/// 個体は遺伝子とその適応度を持ちます。個体の持つ遺伝子情報クラスは必ず本インタフェースを実装する必要があります。
/// <br>
/// <br>
/// <br>
/// <p>タイトル: Genetic Algorithm Library</p>
/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
/// <p>著作権: Copyright (c) 2002  森本寛</p>
/// <p>会社名: 株式会社東京マイクロデータ</p>
/// @author 森本寛
/// @version 1.0 (2002/10/16)
/// </summary>
public interface ITypedGene<TBase> : IGene
{
	/// <summary>
	/// 遺伝子の型指定された塩基配列を返します
	/// </summary>
	/// <returns>型指定された遺伝子配列</returns>
	TBase[] GetTypedBase();


	void SetTypedBase(TBase[] baseData);

	/// <summary>
	/// 自己遺伝子の型指定された部分遺伝子断片を返します
	/// </summary>
	/// <remarks>
	/// 部分遺伝子を返すことで交叉を行うことができます。<br>
	/// 部分遺伝子は初端と終端を指定することで抜き出します。<br>
	/// 初端と終端の遺伝子も返される部分遺伝子断片に含まれます。<br>
	/// 例えば、getSubGene(0, 5) とした場合の返される遺伝子断片の長さは6となります。<br>
	/// getSubGene(1,1)とすることで1塩基を抜き出すこともできます。<br>
	/// </remarks>
	/// <param name="firstGenoIndex">抜き出す遺伝子断片の初端を指定します</param>
	/// <param name="lastGenoIndex">抜き出す遺伝子断片の終端を指定します</param>
	/// <returns>抜き出された部分遺伝子断片です</returns>
	ITypedGene<TBase> GetTypedSubGene(int firstGenoIndex, int lastGenoIndex);
}

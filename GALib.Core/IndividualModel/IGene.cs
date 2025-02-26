namespace GALib.Core.IndividualModel
{
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
	public interface IGene<TBase>
	{
		/// <summary>
		/// 塩基配列数を取得します
		/// </summary>
		int GeneSize { get; }

		/// <summary>
		/// 遺伝子の型指定された塩基配列を返します
		/// </summary>
		/// <returns>型指定された遺伝子配列</returns>
		TBase[] GetBase();

		/// <summary>
		/// 遺伝子の型指定された塩基配列を設定します
		/// </summary>
		/// <param name="baseData">塩基配列</param>
		void SetBase(TBase[] baseData);

		/// <summary>
		/// 塩基配列を一意に識別する為のハッシュ値を返します
		/// </summary>
		/// <returns></returns>
		string? GetHash();

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
		/// <param name="firstGeneIndex">抜き出す遺伝子断片の初端を指定します</param>
		/// <param name="lastGeneIndex">抜き出す遺伝子断片の終端を指定します</param>
		/// <returns>抜き出された部分遺伝子断片です</returns>
		IGene<TBase> GetSubGene(int firstGeneIndex, int lastGeneIndex);

		/// <summary>
		/// 指定した場所の遺伝子に逆位を行います
		/// </summary>
		/// <remarks>
		/// 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
		/// あまり一般的に用いられるGAオペレーションではありません。
		/// </remarks>
		/// <param name="firstGeneIndex">抜き出す遺伝子断片の初端を指定します</param>
		/// <param name="lastGeneIndex">抜き出す遺伝子断片の終端を指定します</param>
		void InverseSubGene(int firstGeneIndex, int lastGeneIndex);

		/// <summary>
		/// 1塩基に対して突然変異を起こします
		/// </summary>
		/// <remarks>
		/// 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
		/// 突然変位は遺伝子の塩基タイプによって異なります。<br>
		/// </remarks>
		/// <param name="geneIndex">塩基インデックス</param>
		void MutateOneGene(int geneIndex);
	}
}

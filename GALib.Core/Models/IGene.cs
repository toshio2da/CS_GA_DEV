namespace GALib.Core.Models
{
	/**
	 * <p>個体の持つ遺伝子情報を持つクラスのインタフェースです。</p>
	 * 遺伝子は様々な塩基タイプを持っており、それらの共通インタフェースとして本インタフェースを使用します。<br>
	 * 個体は遺伝子とその適応度を持ちます。個体の持つ遺伝子情報クラスは必ず本インタフェースを実装する必要があります。
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
	public interface IGene
	{
		/// <summary>
		/// 自己遺伝子の遺伝子長を返します
		/// </summary>
		int GenoSize { get; }

		/// <summary>
		/// 遺伝子の塩基配列を返します
		/// </summary>
		/// <returns>遺伝子配列</returns>
		T[] GetBase<T>();

		/// <summary>
		///  遺伝子の塩基配列を設定します
		/// </summary>
		/// <param name="baseData">遺伝子配列</param>
		void SetBase<T>(T[] baseData);

		/// <summary>
		/// 自己遺伝子を全てランダムなもので再構築します
		/// </summary>
		/// <remarks>
		/// 個体遺伝子の初期化などに用いられます
		/// </remarks>
		void RandumReconstruct();


		/// <summary>
		/// 1塩基に対して突然変異を起こします
		/// </summary>
		/// <remarks>
		/// 自己遺伝子内の指定塩基に対して突然変位を行います。<br>
		/// 突然変位は遺伝子の塩基タイプによって異なります。<br>
		/// </remarks>
		/// <param name="genoIndex">塩基インデックス</param>
		void MutateOneGene(int genoIndex);

		/// <summary>
		/// 指定した場所の遺伝子に逆位を行います
		/// </summary>
		/// <remarks>
		/// 逆位とは指定した場所の遺伝子の順番を反転させる操作を指します。<br>
		/// あまり一般的に用いられるGAオペレーションではありません。
		/// </remarks>
		/// <param name="firstGenoIndex">抜き出す遺伝子断片の初端を指定します</param>
		/// <param name="lastGenoIndex">抜き出す遺伝子断片の終端を指定します</param>
		void InverseSubGene(int firstGenoIndex, int lastGenoIndex);

	}
}
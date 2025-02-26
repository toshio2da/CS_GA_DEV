using GALib.Core.Plugins;
using GALib.Core.Utils;
using GALib.Core.IndividualModel;

namespace GALib.Plugins
{
	/// <summary>
	/// トーナメント方式によって淘汰を行います。
	/// </summary>
	/// <remarks>
	/// 親集団より子集団候補を作成するのに用いられる淘汰アルゴリズムの一つです。
	/// 親集団中から複数の個体を選び、その中から一番適応度の高いものを選択します。
	/// この操作を子集団候補が揃うまで繰り返します。
	/// 当然、同一の親が複数回選ばれることもあります。
	/// 
	/// トーナメントサイズによって一度に比べる個体の数を指定することが出来ます。
	/// 通常は2が用いられます。デフォルト値も同様に2を採用しています。
	/// しかし、ある種の問題では2では淘汰圧が低くなる場合があります。
	/// その場合は淘汰圧を高くするとうまく行く場合はあります。
	/// 
	/// <p>タイトル: Genetic Algorithm Library</p>
	/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	/// <p>著作権: Copyright (c) 2002  森本寛</p>
	/// <p>会社名: 株式会社東京マイクロデータ</p>
	/// @author 森本寛
	/// @version 1.0 (2002/10/30)
	/// </remarks>
	public class TournamentSelection : ISelection
	{
		private int _tournamentSize = 2;

		/// <summary>
		/// トーナメントサイズ
		/// </summary>
		public int TournamentSize
		{
			get => _tournamentSize;
			set
			{
				//不正な値の場合は2になる
				this._tournamentSize = value > 1 ? value : 2;
			}
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TournamentSelection() { }

		/// <summary>
		/// ヘルパコンストラクタ
		/// </summary>
		/// <param name="tournamentSize">トーナメントサイズ</param>
		public TournamentSelection(int tournamentSize)
		{
			this.TournamentSize = tournamentSize;
		}

		/// <summary>
		/// 親集合から子集合候補を淘汰によって作成します。
		/// </summary>
		/// <remarks>
		/// 集合の数に変更はありませんが、親集合の個人が複数発生することがあります。
		/// これは各々の適応度によって異なります。
		/// 
		/// 各個人は適応度を既に保持している必要があります。
		/// この適応度はFitnessAlgorithmによって算出された生のデータです。
		/// 
		/// Tournamentクラスではトーナメント方式によって淘汰を行います。
		/// 親集団中から複数の個体を選び、その中から一番適応度の高いものを選択します。
		/// この操作を子集団候補が揃うまで繰り返します。
		/// 当然、同一の親が複数回選ばれることもあります。
		/// </remarks>
		/// <param name="group">淘汰を行う親集合。要素は全てIndividualかその派生クラスである必要があります。</param>
		/// <returns>子集合候補。この集合を用いて新しい世代を創生します</returns>
		public List<Individual<TBase>> Selection<TBase>(List<Individual<TBase>> group)
		{
			//元の親集合の数になるまで繰り返す
			List<Individual<TBase>> candidates = []; // 最終的に選ばれた子集団候補者
			List<Individual<TBase>> preLiminary = [];// 予選候補者。この中で適応度の一番高いものが候補者となる。
			for (int index = 0; index < group.Count; index++)
			{

				//一度に選ぶ小集団をランダムに選出
				preLiminary.Clear();	// 予選候補者を初期化
				for (int candidateIndex = 0; candidateIndex < this.TournamentSize; candidateIndex++)
				{
					preLiminary.Add(group[(int)(RandomGenerator.Random * group.Count)]);   // ランダムに予選候補者を選出
				}

				//適応度が最大の個体を選出・子集合候補者に追加
				//Collections.sort(preLiminary);
				preLiminary = preLiminary.OrderByDescending(e => e.FitnessValue).ToList();

				candidates.Add(preLiminary[0]);
			}

			//子集合候補を返す
			return candidates;
		}
	}
}
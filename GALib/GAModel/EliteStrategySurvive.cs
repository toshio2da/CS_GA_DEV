using GALib.Core.IndividualModel;
using GALib.Core.Plugins;

namespace GALib.Plugins
{
	/// <summary>
	/// エリート戦略による親集団の生き残りアルゴリズムです。
	/// </summary>
	/// <remarks>
	/// エリート戦略では適応度の高い順に並べ、優秀な個体のみを全て次世代に受け継がせます。<br>
	/// 適応度の高い個体はいつまでも残ることになります。<br>
	/// 生き残る個体の数は世代間ギャップ[G]で決定されます。<br>
	/// G = 0.9の時、優秀な10%の親は次世代集団にそのまま残ることになります。<br>
	/// エリート戦略を用いると収束が早くなるという利点がありますが、局所解に陥る危険性も高くなります。<br>
	/// また、毎回ソートする必要があるので計算コストも高くなります。<br>
	/// <p>タイトル: Genetic Algorithm Library</p>
	/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
	/// <p>著作権: Copyright (c) 2002  森本寛</p>
	/// <p>会社名: 株式会社東京マイクロデータ</p>
	/// @author 森本寛
	/// @version 1.0 (2002/10/30)
	/// </remarks>

	public class EliteStrategySurvive : ISurvive
	{

		/// <summary>
		/// 世代間ギャップ
		/// </summary>
		public double GenerationGap { get; set; } = 0.95;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public EliteStrategySurvive() { }

		/// <summary>
		/// ヘルパコンストラクタ
		/// </summary>
		/// <param name="generationGap">世代間ギャップ</param>
		public EliteStrategySurvive(double generationGap)
		{
			GenerationGap = generationGap;
		}

		public List<Individual> Survive(List<Individual> survivors)
		{
			//ソートを行う
			survivors = survivors.OrderByDescending(e => e.FitnessValue).ToList();

			// 世代間ギャップによって決められた数だけ順に抽出
			int eliteNumber = (int)(survivors.Count * (1.0 - GenerationGap));  // 生き残るエリートの数を計算

			List<Individual> elites = [.. survivors.GetRange(0, eliteNumber)];
			return elites;
		}
	}
}
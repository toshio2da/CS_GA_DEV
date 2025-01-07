
using GALib.Core.Plugins;
using GALib.Core.Models;

namespace GALib.Core;

/// <summary>
/// <p>GeneticAlgorithmインタフェースの提供メソッドのうち、推奨デフォルト値を設定した抽象クラスです。</p>
/// 遺伝的アルゴリズムによる検索を行う上で使用する手法を定めるモデルクラスの抽象クラスです。
/// 突然変異確率を遺伝子長の逆数、逆位確率を0で返します。これは広範囲に渡る問題で適応可能なパラメータ値です。<br>
/// <br>
/// 遺伝的アルゴリズムには大きくわけで4つのステップがあります。<br>
/// 「適応度算出」これは問題によって異なるものです。<br>
/// 「淘汰」これは適応度によってどの個体を子集団の親候補にするかを決定します。<br>
/// 「生存」親集団の中から次世代集団に直接生き残る個体の決め方を定めます。<br>
/// 「生殖」では親集団から次世代の子集団を生成します。交叉や突然変異、逆位などが知られます。<br>
/// <br>
/// 本インタフェースではこれらの様々な手法を実装したクラスをGeneticAlgorithmクラスに与えます。<br>
/// このインタフェースによってGeneticAlgorithmクラスは使用する手法を切り替えることが出来ます。<br>
/// <br>
/// <br>
/// <br>
/// <p>タイトル: Genetic Algorithm Library</p>
/// <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
/// <p>著作権: Copyright (c) 2001  森本寛</p>
/// <p>会社名: 株式会社東京マイクロデータ</p>
/// @author 森本寛
/// @version 1.0 (2002/11/03)
/// </summary>
public abstract class AbstractGAModel : IGAModel
{
	/// <summary>
	/// 遺伝子の各塩基が突然変異を起こす確率を返します
	/// </summary>
	public virtual double MutationProbability => 1.0 / IndividualModel.GenoSize;

	/// <summary>
	/// 個体の遺伝子に逆位が起こる確率を返します。
	/// </summary>
	public virtual double InverseProbability => 0.0;//------ 逆位操作は行わない ------//

	public IIndividualModel IndividualModel { get; protected set; } = null!;
	public IFitnessAlgorithm FitnessAlgorithm { get; protected set; } = null!;
	public ISelectionAlgorithm SelectionAlgorithm { get; protected set; } = null!;
	public ISurvivalAlgorithm SurvivalAlgorithm { get; protected set; } = null!;
	public ICrossoverAlgorithm CrossoverAlgorithm { get; protected set; } = null!;

}

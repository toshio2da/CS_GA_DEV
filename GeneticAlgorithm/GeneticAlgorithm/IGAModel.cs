﻿using jp.co.tmdgroup.common.GeneticAlgorithm.Crossovers;
using jp.co.tmdgroup.common.GeneticAlgorithm.Fitnesses;
using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;
using jp.co.tmdgroup.common.GeneticAlgorithm.Selections;
using jp.co.tmdgroup.common.GeneticAlgorithm.Survivals;

namespace jp.co.tmdgroup.common.GeneticAlgorithm;

/// <summary>
/// <p>遺伝的アルゴリズムによる検索を行う上で使用する手法を定めるモデルクラスのインタフェースです。</p>
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
/// <p>著作権: Copyright (c) 2002  森本寛</p>
/// <p>会社名: 株式会社東京マイクロデータ</p>
/// @author 森本寛
/// @version 1.0 (2002/10/30)
/// </summary>
public interface IGAModel
{
	/// <summary>
	/// 使用する個体のモデルを実装するクラスのインスタンスを返します
	/// </summary>
	/// <remarks>
	/// 個体モデルは個体の遺伝子長、塩基配列などを決定します。<br>
	/// 個体モデルは適応度計算アルゴリズムと相互に関係しますが、他のアルゴリズムとは独立ですので、柔軟な設計を行うことができます。
	/// </remarks>
	public IIndividualModel IndividualModel { get; }

	/// <summary>
	/// 使用する適応度計算アルゴリズムを実装するクラスのインスタンスを取得します
	/// </summary>
	/// <remarks>
	/// GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
	/// 適応度の計算法は問題によって異なります。<br>
	/// 適応度の計算クラスは取り扱う個体の遺伝子の塩基タイプと対応している必要があります。<br>
	/// </remarks>
	public IFitnessAlgorithm FitnessAlgorithm { get; }

	/// <summary>
	/// <p>使用する淘汰アルゴリズムを実装するクラスのインスタンスを返します。</p>
	/// </summary>
	/// <remarks>
	/// GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
	/// 淘汰アルゴリズムには様々なものがありますが、代表的なものでは「ルーレット方式」「ランク方式」「トーナメント方式」などがあげられます。<br>
	/// </remarks>
	/// 
	public ISelectionAlgorithm SelectionAlgorithm { get; }

	/// <summary>
	/// 使用する生存アルゴリズムを実装するクラスのインスタンスを返します。</p>
	/// </summary>
	/// <remarks>
	/// GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
	/// 生存とは親集団の中から次世代子集団の中にそのまま生き残る個体を指します。<br>
	/// 生存割合は世代間ギャップ[G]によって決定されます。G = 1 の時は生存しません。<br>
	/// </remarks>
	public ISurvivalAlgorithm SurvivalAlgorithm { get; }

	/// <summary>
	/// <p>使用する交叉アルゴリズムを実装するクラスのインスタンスを返します。</p>
	/// </summary>
	/// <remarks>
	/// GeneticAlgorithmクラスはこのメソッドで返されたクラスのアルゴリズムを使用することになります。<br>
	/// 遺伝的アルゴリズムは交叉と突然変異、または逆位によって集団の中から優秀な個体を生成し、最適な解を検索します。<br>
	/// 交叉アルゴリズムには様々なものがありますが、1点交叉と2点交叉が一般的です。<br>
	/// 本ライブラリでは2点交叉の使用を推奨しています。<br>
	/// </remarks>
	public ICrossoverAlgorithm CrossoverAlgorithm { get; }

	/// <summary>
	/// 遺伝子の各塩基が突然変異を起こす確率を返します</p>
	/// </summary>
	/// <remarks>
	/// 各塩基の突然変異率(0.0:突然変位が怒らない  1.0:全ての塩基に突然変異が起こる  通常:0.005程度？)
	/// この確率は各個人の各塩基1つ1つに対して適応されます。<br>
	/// つまり、本メソッドが1.0を返すと、全ての個体の全ての遺伝子の全ての塩基がランダムに生成されることになってしまい
	/// いつまで経っても収束しないことになってしまいます。<br>
	/// 通常は各個体に1つの突然変異が発生するかしないかの値を取ります。<br>
	/// つまり、各個体の持つ遺伝子の遺伝子長の逆数が一般的です。<br>
	/// 全く突然変位が怒らないようにしてしまうと個体の多様性が維持できず、局所解に収束しやすくなってしまいます。<br>
	/// </remarks>
	public double MutationProbability { get; }

	/// <summary>
	/// 個体の遺伝子に逆位が起こる確率を返します。
	/// </summary>
	/// <remarks>
	/// 逆位とは部分遺伝子の順序が逆になる遺伝子操作です。<br>
	/// あまり一般的に用いられる操作ではなく、通常は0が設定されます。<br>
	/// 逆位が起こるとされた個体の遺伝子はランダムな2点を取り、その間の遺伝子の順序が逆になります。<br>
	/// </remarks>
	public double InverseProbability { get; }
}

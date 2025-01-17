﻿using jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

namespace jp.co.tmdgroup.common.GeneticAlgorithm.Fitnesses;
/**
 * <p>個体の適応度を算出するクラスのインタフェースです。</p>
 * 問題毎に適応度の計算法は異なります。適当度を算出するクラスは本インタフェースを実装することによって行われます。<br>
 * 本インタフェースのメソッド、fitness()メソッドを実装することにより問題毎の適応度の計算法を定めます。<br>
 * 適応度は大きいほど個体が優秀であることをしめします。<br>
 * fitness()メソッドは生の適応度を返す必要があります。<br>
 * スケーリング技法等のデータ加工はSelectionクラスが行います。<br>
 * <br>
 * 適応度の計算法は問題毎によって異なりますが、同様に使用する個体の遺伝子塩基タイプも問題毎によってことなります。<br>
 * よってfitness()メソッドには対応している塩基タイプの遺伝子が渡される必要があります。<br>
 * 同様に遺伝子長も対応している必要があります。<br>
 * <br>
 * <br>
 * <br>
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/17)
 */
public interface IFitnessAlgorithm
{

	/**
     * <p>各個体の適応度を計算します。</p>
     * 本メソッドを実装することで、各問題毎の適応度算出法を実装します。<br>
     * 本メソッドは適応度を返すと共に、渡した個体に適応度が保持されます。またその様に実装してください。<br>
     *
     * @param individual  適応度を算出する個体です。対応した遺伝子をもている必要があります。
     * @return 渡された個体の適応度を返します。引数で渡した個体にも設定してあります。
     * @throws IllegalGenoSizeException  遺伝子断片の合計遺伝子長が本遺伝子の遺伝子長と一致しません(遺伝子不足又は過多)
     * @throws IllegalGenoTypeException  遺伝子断片の塩基タイプが本遺伝子の塩基タイプと一致しません
     */
	public double GetFitnessValue(Individual individual); //throws IllegalGenoTypeException, IllegalGenoSizeException;



	/**
     * <p>個体のもてる最大の適応度、つまり最良値を返します。</p>
     * 本メソッドと同じ値を持つ個体が現れた場合、検索は終了します。<br>
     * この値は問題毎に変化するのが一般的です。<br>
     * <br>
     * ペナルティ減算で適応度を算出する場合は十分に大きい正の数からペナルティ値を引くのが一般的です。<br>
     * その様に実装する場合には減算に使用する十分に大きい正の値そのものを本メソッドで返すことで最良値とすることができます。<br>
     * <bt>
     * 問題によっては最良値が不明な場合はあります。<br>
     * その時は本メソッドで負の値を返してください。その場合、どの様な適応度を持った個体が現れても検索が終了することはありません。<br>
     * 世代数や時間のみの情報で検索を終了することになります。<br>
     *
     * @return 個体の持つことの出来る最大の適応度を返します。
     */
	public double BestFitnessValue { get; }
}

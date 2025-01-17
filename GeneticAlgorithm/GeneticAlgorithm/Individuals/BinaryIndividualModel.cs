﻿namespace jp.co.tmdgroup.common.GeneticAlgorithm.Individuals;

using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;

/**
 * <p>タイトル: Genetic Algorithm Library</p>
 * <p>説明: 汎用的な遺伝的アルゴリズムライブラリの構築</p>
 * <p>著作権: Copyright (c) 2002  森本寛</p>
 * <p>会社名: 株式会社東京マイクロデータ</p>
 * @author 森本寛
 * @version 1.0 (2002/10/30)
 */

/**
 * <p>2値塩基タイプを持つ個体の個体モデルです。抽象クラスです。</p>
 * 個体モデルのうち、2値塩基タイプの個体モデルの基底クラスです。<br>
 * 塩基タイプチェックメソッド isLegalGenoType()は実装済みです。<br>
 * 遺伝子長チェックメソッドは構築時に与えたサイズを返します。<br>
 */

public class BinaryIndividualModel : AbstractIndividualModel
{
	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="genoSize">自己遺伝子の遺伝子長</param>
	public BinaryIndividualModel(int genoSize) : base(genoSize) { }


	/// <summary>
	/// 遺伝子の塩基タイプがこの個体モデルにおいて正しいかどうかをチェックします
	/// </summary>
	/// <remarks>
	///　渡された遺伝子が整数型の塩基タイプを持つかチェックします。<br>
	///　整数型塩基タイプでなければfalseを返します。
	/// </remarks>
	/// <param name="gene">チェックしたい遺伝子です</param>
	/// <returns>正しければtrue, 不正であればfalseを返します</returns>
	public override bool IsLegalGenoType(IGene gene)
	{
		return (gene.GetBase() is bool[]);
	}


	/// <summary>
	/// 新しい整数配列遺伝子を生成し、返します。各個体は本メソッドより遺伝子を生成します
	/// </summary>
	/// <remarks>
	/// 生成される遺伝子はgetGenoSize()メソッドで返される遺伝子長のものです
	/// </remarks>
	/// <returns>新しく生成された遺伝子。遺伝子長はgetGenoSize()で返される値</returns>
	public override IGene CreateNewGene()
	{
		//------ 新しく2値遺伝子を生成、返す ------//
		return new BinaryGene(this.GenoSize);
	}
}

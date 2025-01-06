﻿namespace jp.co.tmdgroup.common.GeneticAlgorithm;

using jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions;
using jp.co.tmdgroup.common.GeneticAlgorithm.Genes;
using jp.co.tmdgroup.common.Utils;

using System;

/// <summary>
/// <p>正の整数配列で遺伝子を表す遺伝子型です。</p>
/// 遺伝的アルゴリズムで使用される遺伝子型でも一般的な塩基タイプです。<br>
/// 遺伝子はすべて整数で表され、その組み合わせて個体の適応度が決定されます。<br>
/// 断片遺伝子は int[]型で表されますので、適切なキャストを行う必要があります。<br>
/// 突然変異は整数型の撮りうる全ての値です。<br>
/// <br>
/// 本クラスを派生し、突然変異の挙動を変えることで使用する範囲を限定した遺伝子型を簡単に構築することが出来ます。<br>
/// 整数配列遺伝子を用いた問題の場合、使用する整数を限定のが一般的であり、また効率的でもあります。<br>
/// そのため、mutateOneGene()メソッドのみfinal宣言をしておらず、オーバーライドが可能です。<br>
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

public class NumberGene : AbstractTypedGene<int>
{
	///// <summary>
	///// コンストラクタ
	///// </summary>
	///// <param name="size">遺伝子の長さ</param>
	public NumberGene(int size) : base(size) {

		//------ 乱数で初期化 ------//
		this.RandumReconstruct();
	}

	public override Type GeneType => typeof(NumberGene);

	protected override int GetMutateValue()
	{
		return (int)(RandomGenerator.Random * 2147483647);
	}
}

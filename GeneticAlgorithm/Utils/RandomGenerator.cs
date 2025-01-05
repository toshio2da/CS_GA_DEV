using System.Runtime.CompilerServices;

namespace jp.co.tmdgroup.common.Utils;

/**
 * <p>タイトル: 乱数発生クラス</p>
 * <p>説明: 乱数発生クラス</p>
 * <p>著作権: Copyright (c) 2006</p>
 * <p>会社名: 東京マイクロデータ</p>
 * @author 杉山太二
 * @version 1.0
 */

public static class RandomGenerator
{
	static private Random? randomBase = null;
	static private int seed;

	public static int Seed
	{
		set
		{
			seed = value;
			randomBase = new Random(seed);
		}
	}


	public static double Random
	{
		get
		{
			randomBase ??= new Random();
			return randomBase.NextDouble();
		}
	}
}

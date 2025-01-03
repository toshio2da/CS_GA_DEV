using System.Runtime.CompilerServices;

namespace jp.co.tmdgroup.common.geneticalgorithm;

/**
 * <p>タイトル: 乱数発生クラス</p>
 * <p>説明: 乱数発生クラス</p>
 * <p>著作権: Copyright (c) 2006</p>
 * <p>会社名: 東京マイクロデータ</p>
 * @author 杉山太二
 * @version 1.0
 */

public class GARandomGenerator
{
	static private Random? randomBase = null;
	static private int seed;

	[MethodImpl(MethodImplOptions.Synchronized)]
	static public void setSeed(int s)
	{
		seed = s;
		randomBase = new Random(seed);
	}


	[MethodImpl(MethodImplOptions.Synchronized)]
	static public double random()
	{
		if (randomBase == null)
		{
			randomBase = new Random();
		}
		return randomBase.NextDouble();
	}
}

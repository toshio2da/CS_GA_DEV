using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace jp.co.tmdgroup.common.tmdtools
{
	public class DataTools
	{
		public static int[] createUniqElementArray(int[] ints)
		{
			return ints.Distinct().ToArray();
		}

		public static bool[] fuseBinaryArray(object[] binaryArrays)
		{
			return binaryArrays.SelectMany(e => (bool[])e).ToArray();

			/*
			//------ 合計配列長を確認 ------//
			int allArraySize = 0;                             // 融合される合計配列長
			var iterator = binaryArrays.GetEnumerator();       // 全ての要素にアクセスするためにイテレータを使用
			while (iterator.MoveNext())
			{
				bool[] array = (bool[])(iterator.Current);     // 2値配列を一つ取り出す
				allArraySize += array.Length;                        // 合計サイズに加算
			}

			//------ 配列要素を順にコピー ------//
			bool[] newBinaryArray = new bool[allArraySize];   // 融合された配列をここに格納
			iterator = binaryArrays.GetEnumerator();                      // 全ての要素にアクセスするためにイテレータを使用
			int allIndex = 0;                              // この添字で順にコピー
			while (iterator.MoveNext())
			{
				bool[] array = (bool[])(iterator.Current);     // 2値配列を一つ取り出す

				//------ 1配列毎にコピー ------//
				for (int index = 0; index < array.Length; index++)
				{
					newBinaryArray[allIndex++] = array[index];       // 各2値をコピー
				}
			}

			//------ 融合した配列を返す ------//
			return newBinaryArray;
			*/
		}


		public static int[] fuseIntegerArray(object[] intArrays)
		{
			return intArrays.SelectMany(e => (int[])e).ToArray();
			/*
			//------ 合計配列長を確認 ------//
			int allArraySize = 0;                         // 融合される合計配列長
			var iterator = intArrays.GetEnumerator();      // 全ての要素にアクセスするためにイテレータを使用
			while (iterator.MoveNext())
			{
				int[] array = (int[])(iterator.Current);         // 4バイト整数配列を一つ取り出す
				allArraySize += array.Length;                    // 合計サイズに加算
			}

			//------ 配列要素を順にコピー ------//
			int[] newIntegerArray = new int[allArraySize];      // 融合された配列をここに格納
			iterator = intArrays.GetEnumerator();                     // 全ての要素にアクセスするためにイテレータを使用
			int allIndex = 0;                          // この添字で順にコピー
			while (iterator.MoveNext())
			{
				int[] array = (int[])(iterator.Current);         // 4バイト整数配列を一つ取り出す

				//------ 1配列毎にコピー ------//
				for (int index = 0; index < array.Length; index++)
				{
					newIntegerArray[allIndex++] = array[index];  // 各4バイト整数をコピー
				}
			}

			//------ 融合した配列を返す ------//
			return newIntegerArray;
			*/
		}
	}
}

using GALib.Core.Models;

using System.ComponentModel.Design;
using System.Diagnostics;

namespace GALib.Core.Utils
{
	public static class DataTools
	{

		public static (Individual son, Individual daughter) Crossover(Individual father, Individual mother, params int[] splitIndexes)
		{
			//重複の除去とソート
			int[] _splitIndexes = splitIndexes.Distinct().OrderBy(e => e).ToArray();

			int geneSize = father.IndividualModel.GenoSize;
			if (_splitIndexes.Length <= 0 || _splitIndexes.Length > geneSize)
			{
				throw new Exception($"サイズ{geneSize}の遺伝子は{_splitIndexes}に分割できません");
			}

			List<object[]> fatherGeneList = ArraySplits(father.Gene.GetBase<object>(), _splitIndexes);

			//Debug.WriteLine("=====================================");
			//Debug.WriteLine("Fathers");
			//foreach (object[] item in fatherGeneList)
			//{
			//	Debug.WriteLine(string.Join("\t", item.Select(e => Convert.ToString(e))));
			//}

			List<object[]> motherGeneList = ArraySplits(mother.Gene.GetBase<object>(), _splitIndexes);

			//Debug.WriteLine("=====================================");
			//Debug.WriteLine("Mothers");
			//foreach (object[] item in motherGeneList)
			//{
			//	Debug.WriteLine(string.Join("\t", item.Select(e => Convert.ToString(e))));
			//}
			//Debug.WriteLine("");


			object[][] childGenArray = { new object[geneSize], new object[geneSize] };


			int offset = 0;
			for (int i = 0; i < fatherGeneList.Count; i++)
			{
				bool isEven = i % 2 == 0;
				Array.Copy(fatherGeneList[i], 0, childGenArray[isEven ? 0 : 1], offset, fatherGeneList[i].Length);
				Array.Copy(motherGeneList[i], 0, childGenArray[isEven ? 1 : 0], offset, motherGeneList[i].Length);
				offset += fatherGeneList[i].Length;
			}

			//Debug.WriteLine("=====================================");
			//Debug.WriteLine("Sons");
			//Debug.WriteLine(string.Join("\t", childGenArray[0].Select(e => Convert.ToString(e))));

			//Debug.WriteLine("=====================================");
			//Debug.WriteLine("Daughters");
			//Debug.WriteLine(string.Join("\t", childGenArray[1].Select(e => Convert.ToString(e))));


			//戻り値タプル
			(Individual son, Individual daughter) ret = (father.IndividualModel.CreateNewIndividual(childGenArray[0]), mother.IndividualModel.CreateNewIndividual(childGenArray[1]));

			return ret;
		}


		public static List<object[]> ArraySplits(object[] source, params int[] splitIndexes)
		{
			List<object[]> result = new List<object[]>(splitIndexes.Length + 1);
			ArraySplits(result, source, 0, splitIndexes);
			return result;
		}


		public static void ArraySplits(List<object[]> result, object[] source, int sourceIndex, params int[] splitIndexes)
		{
			int curretnIndex = splitIndexes[result.Count];
			var buf = ArrayMid(source, sourceIndex, curretnIndex);
			result.Add(buf.take);
			if (buf.rest.Length > 0)
			{
				if (result.Count >= splitIndexes.Length)
				{
					result.Add(buf.rest);
				}
				else
				{
					ArraySplits(result, source, sourceIndex + buf.take.Length, splitIndexes);
				}
			}
		}

		public static (object[] take, object[] rest) ArrayMid(object[] source, int startIndex, int endIndex)
		{
			int takeLength = endIndex - startIndex + 1;
			int restLength = source.Length - (endIndex + 1);
			if (restLength <= 0) restLength = 0;


			(object[] take, object[] rest) ret = (new object[takeLength], new object[restLength]);

			Array.Copy(source, startIndex, ret.take, 0, takeLength);
			if (restLength > 0)
			{
				Array.Copy(source, startIndex + takeLength, ret.rest, 0, restLength);
			}

			return ret;
		}


		/// <summary>
		/// 重複している数字を重複しないように置き換える
		/// </summary>
		/// <param name="ints">整数配列</param>
		/// <returns></returns>
		public static int[] CreateUniqElementArray(int[] ints)
		{
			List<int> newNums = new List<int>();

			List<int> nums = new List<int>();
			for (int i = 0; i < ints.Length; ++i)
			{
				nums.Add(i);
			}

			for (int i = 0; i < ints.Length; ++i)
			{
				nums.Remove(ints[i]);
			}

			if (nums.Count == 0)
			{
				return ints;
			}

			for (int i = 0; i < ints.Length; ++i)
			{
				int n = ints[i];
				if (newNums.Contains(n))
				{
					// 既にあるので置き換える
					int pos = ints[i] % nums.Count;
					n = nums[pos];
					nums.RemoveAt(pos);
				}

				newNums.Add(n);
			}

			return newNums.ToArray();
		}


		public static T[] ConvertInnerArray<T>(object[] arrays)
		{
			return arrays.SelectMany(e => (T[])e).ToArray();
		}

		public static bool[] FuseBinaryArray(object[] binaryArrays)
		{
			return binaryArrays.SelectMany(e => (bool[])e).ToArray();
		}


		public static int[] FuseIntegerArray(object[] intArrays)
		{
			return intArrays.SelectMany(e => (int[])e).ToArray();
		}
	}
}

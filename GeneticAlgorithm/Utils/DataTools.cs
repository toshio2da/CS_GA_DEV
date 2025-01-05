namespace jp.co.tmdgroup.common.Utils
{
	public static class DataTools
	{
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

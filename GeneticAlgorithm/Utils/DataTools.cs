namespace jp.co.tmdgroup.common.Utils
{
	public static class DataTools
	{
		public static int[] CreateUniqElementArray(int[] ints)
		{
			List<int> nums = new List<int>();
			for (int i = 0; i < ints.Length; ++i)
			{
				nums.Add(i);
			}

			List<int> newNums = new List<int>();
            for (int i = 0; i < ints.Length; ++i)
			{
				int pos = ints[i] % nums.Count;
                int n = nums[pos];
				newNums.Add(n);
				nums.RemoveAt(pos);
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

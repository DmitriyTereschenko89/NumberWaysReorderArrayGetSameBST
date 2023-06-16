namespace NumberWaysReorderArrayGetSameBST
{
	internal class Program
	{
		public class NumberWaysReorderArrayGetSameBST
		{
			private long modulo = (long)1e9 + 7;
			private long[][] table;

			private long DFS(List<int> nums)
			{
				int n = nums.Count;
				if (n < 3)
				{
					return 1;
				}
				List<int> leftNodes = new();
				List<int> rightNodes = new();
				for (int i = 1; i < n; ++i)
				{
					if (nums[i] < nums[0])
					{
						leftNodes.Add(nums[i]);
					}
					else
					{
						rightNodes.Add(nums[i]);
					}
				}
				long leftNumWays = DFS(leftNodes) % modulo;
				long rightNumWays = DFS(rightNodes) % modulo;
				return leftNumWays * rightNumWays % modulo * table[n - 1][leftNodes.Count] % modulo;
			}
			
			public int NumOfWays(int[] nums)
			{
				int n = nums.Length;
				table = new long[n][];
				for (int r = 0; r < n; ++r)
				{
					table[r] = new long[r + 1];
					table[r][0] = table[r][^1] = 1;
					for (int c = 1; c < r; ++c)
					{
						table[r][c] = (table[r - 1][c - 1] + table[r - 1][c]) % modulo;
					}
				}
				return (int)((DFS(nums.ToList()) - 1) % modulo);
			}
		}

		static void Main(string[] args)
		{
			NumberWaysReorderArrayGetSameBST numberWaysReorderArrayGetSameBST = new();
            Console.WriteLine(numberWaysReorderArrayGetSameBST.NumOfWays(new int[] { 2, 1, 3 }));
			Console.WriteLine(numberWaysReorderArrayGetSameBST.NumOfWays(new int[] { 3, 4, 5, 1, 2 }));
			Console.WriteLine(numberWaysReorderArrayGetSameBST.NumOfWays(new int[] { 1, 2, 3 }));
		}
	}
}
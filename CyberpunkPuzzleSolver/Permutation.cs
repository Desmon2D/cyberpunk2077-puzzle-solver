namespace CyberpunkPuzzleSolver;

public static class Permutation
{
	public static readonly int[] FactorialValues = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 }; //0! -> 12!

	public static T[][] CalculatePermutation<T>(T[] values)
	{
		if (values.Length > 12)
			throw new ArgumentException("n must be <= 12", nameof(values));

		int permutationCount = FactorialValues[values.Length];
		var permutations = new T[permutationCount][];
		for (var i = 0; i < permutationCount; i++)
			permutations[i] = new T[values.Length];

		Span<bool> unusedValues = stackalloc bool[values.Length];

		for (var p = 0; p < permutationCount; p++)
		{
			unusedValues.Fill(true);

			for (var i = 0; i < values.Length; i++)
			{
				var currentN = values.Length - i;
				var groupSize = FactorialValues[currentN];
				var index = p % groupSize * currentN / groupSize;				
				var value = GetUnusedValue(unusedValues, index);

				unusedValues[value] = false;
				permutations[p][i] = values[value];
			}
		}

		return permutations;
	}

	public static int[][] CalculatePermutation(int n)
	{
		if (n > 12)
			throw new ArgumentException("max(n) == 12", nameof(n));

		int permutationCount = FactorialValues[n];
		var permutations = new int[permutationCount][];
		for (var i = 0; i < permutationCount; i++)
			permutations[i] = new int[n];

		Span<bool> unusedValues = stackalloc bool[n];

		for (var p = 0; p < permutationCount; p++)
		{
			unusedValues.Fill(true);

			for (var i = 0; i < n; i++)
			{
				var currentN = n - i;
				var groupSize = FactorialValues[currentN];
				var index = p % groupSize * currentN / groupSize;				
				var value = GetUnusedValue(unusedValues, index);

				unusedValues[value] = false;
				permutations[p][i] = value;
			}
		}

		return permutations;
	}

	public static int GetUnusedValue(Span<bool> span, int index)
	{
		var i = 0;
		var origin = 0;

		while (true)
		{
			while (!span[i + origin])
				origin++;

			if (i == index)
				return i + origin;

			i++;
		}
	}
}
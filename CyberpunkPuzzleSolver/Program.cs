using System;
using System.Collections.Specialized;
using System.Net.Http.Headers;

const int matrixSize = 5;
const int bufferSize = 7;

var matrix = new byte[matrixSize, matrixSize]
{
	{ 0x1C, 0x55, 0xFF, 0xBD, 0xE9 },
	{ 0xBD, 0x1C, 0xE9, 0xFF, 0xE9 },
	{ 0x55, 0xBD, 0xFF, 0x1C, 0x1C },
	{ 0xE9, 0xBD, 0x1C, 0x55, 0x55 },
	{ 0x55, 0xE9, 0xBD, 0x55, 0xFF },
};
var demons = new byte[][]
{
	new byte[] { 0xE9, 0x55 },
	new byte[] { 0x55, 0xBD, 0xE9 },
	new byte[] { 0xFF, 0x1C, 0xBD, 0xE9 },
	new byte[] { 0x55, 0x1C, 0xFF, 0x55 },
};

var n = 10;
var permutations = CalculatePermutation(n);
for (var p = 0; p < permutations.Length; p++)
{
	for (var i = 0; i < n; i++)
		Console.Write(permutations[p][i] + " ");
	
	Console.WriteLine();
}

static int[] Factorial() => new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 }; //0! -> 12!

static int[][] CalculatePermutation(int n)
{
	if (n > 12)
		throw new ArgumentException("max(n) == 12", nameof(n));

	var permutationsCount = Factorial();
	var permutations = new int[permutationsCount[n]][];
	for (var i = 0; i < permutationsCount[n]; i++)
		permutations[i] = new int[n];

	var indexes = new int[n];
	Span<bool> unusedIndexes = stackalloc bool[n];

	for (var p = 0; p < permutationsCount[n]; p++)
	{
		for (var i = 0; i < n; i++)
		{
			var currentN = n - i;
			var groupSize = permutationsCount[currentN];
			indexes[i] = p % groupSize * currentN / groupSize;
		}

		unusedIndexes.Fill(true);

		for (var i = 0; i < n; i++)
		{
			var value = GetUnusedIndex(unusedIndexes, indexes[i]);
			unusedIndexes[value] = false;

			permutations[p][i] = value;
		}
	}

	return permutations;
}

static int GetUnusedIndex(Span<bool> span, int index)
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

//static int[][] CalculatePermutation(int n)
//{
//	var permutationsCount = Factorial();
//	var permutations = new int[permutationsCount[n]][];
//	for (var i = 0; i < permutationsCount[n]; i++)
//		permutations[i] = new int[n];

//	var indexes = new int[n];
//	var temp = new LinkedList<int>();

//	for (var p = 0; p < permutationsCount[n]; p++)
//	{
//		for (var i = 0; i < n; i++)
//		{
//			var currentN = n - i;
//			var groupSize = permutationsCount[currentN];
//			indexes[i] = p % groupSize * currentN / groupSize;
//		}

//		for (var i = 0; i < n; i++)
//			temp.AddLast(i);

//		for (var i = 0; i < n; i++)
//		{
//			var value = temp.ElementAt(indexes[i]);
//			temp.Remove(value);
			
//			permutations[p][i] = value;
//		}
//	}

//	return permutations;
//}

//foreach (var path in Solve(matrix, demons))
//	Console.WriteLine($"{pos.p}: {pos.x + 1} - {pos.y + 1} [{matrix[pos.y][pos.x]}]");

/////////////////////////////////////////////////

//static (int y, int x)[][] Solve(byte[,] matrix, byte[][] demons)
//{
//	var permutation = new byte[matrix.Length][];
//}

//static byte[][] CalculatePermutation(byte[][] demons)
//{
//	var maxLength = demons.Sum(a => a.Length);
//	int permutationsCount = CalculateFactorial(demons.Length);
//	var permutations = new byte[permutationsCount][];
//
//	for (var i = 0; i < permutationsCount; i++)
//	{
//		permutations[i];
//	}
//
//
//	return permutations;
//}
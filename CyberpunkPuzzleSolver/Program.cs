using CyberpunkPuzzleSolver;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
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

var permutations = Permutation.CalculatePermutation(4);
foreach (var item in permutations)
{
	for (int i = 0; i < item.Length; i++)
	{
		Console.Write(item[i]);
		Console.Write(' ');
	}	
	
	Console.WriteLine();
}

static (int y, int x)[][] Solve(byte[,] matrix, byte[][] demons)
{
	var permutation = new byte[matrix.Length][];
	return null;
}
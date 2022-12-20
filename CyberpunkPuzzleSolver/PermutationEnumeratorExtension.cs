namespace CyberpunkPuzzleSolver;
public static class PermutationEnumeratorExtension
{
	public static PermutationEnumerator<T> SpanSplit<T>(this T[] values)
		=> new(values);
}
namespace CyberpunkPuzzleSolver;

public ref struct PermutationEnumerator<T>
{
	private readonly T[] _values;
	private readonly int _maxIndex;

	private int _currentIndex = -1;
	private readonly bool[] _unusedValues;
	private readonly T[] _result;

	internal PermutationEnumerator(T[] values)
	{
		_values = values;
		_maxIndex = Permutation.FactorialValues[_values.Length];
		_unusedValues = new bool[_maxIndex];
		_result = new T[_values.Length];
	}

	public PermutationEnumerator<T> GetEnumerator() => this;
	public bool MoveNext() => ++_currentIndex < _maxIndex;

	public T[] Current
	{
		get
		{
			_unusedValues.AsSpan().Fill(true);

			for (var i = 0; i < _values.Length; i++)
			{
				var currentN = _values.Length - i;
				var groupSize = Permutation.FactorialValues[currentN];
				var index = _currentIndex % groupSize * currentN / groupSize;
				var value = Permutation.GetUnusedValue(_unusedValues, index);

				_unusedValues[value] = false;
				_result[i] = _values[value];
			}

			return _result;
		}
	}
}
public static class EnumerableExtensions
{
	public static IEnumerable Pivot<T, TGroupKey, TPivotKey, TColumn, TElement>(
		this IEnumerable<T> input,
		Func<T, TGroupKey> groupBy,
		Func<T, TPivotKey> pivotBy,
		Func<IGrouping<TPivotKey, T>, TColumn> keySelector,
		Func<IGrouping<TPivotKey, T>, TElement> elementSelector)
	{
		return input
			.GroupBy(groupBy)
			.Select(g => new
			{
				Value = g.Key,
				Data = g.GroupBy(pivotBy)
					.ToDictionary(keySelector, elementSelector)
			});
	}
}
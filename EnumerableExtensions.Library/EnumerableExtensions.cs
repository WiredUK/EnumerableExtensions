using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions.Library.Models;

namespace EnumerableExtensions.Library
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<PivotRow<TGroupKey, TColumn, TElement>>  Pivot<T, TGroupKey, TPivotKey, TColumn, TElement>(
            this IEnumerable<T> input,
            Func<T, TGroupKey> groupBy,
            Func<T, TPivotKey> pivotBy,
            Func<IGrouping<TPivotKey, T>, TColumn> keySelector,
            Func<IGrouping<TPivotKey, T>, TElement> elementSelector)
        {
            return input
                .GroupBy(groupBy)
                .Select(g => new PivotRow<TGroupKey, TColumn, TElement>
                {
                    Value = g.Key,
                    Data = g.GroupBy(pivotBy)
                        .Select(p => new PivotColumnItem<TColumn, TElement>
                        {
                            Column = keySelector.Invoke(p),
                            Element = elementSelector.Invoke(p)
                        })
					
                });
        }
    }
}
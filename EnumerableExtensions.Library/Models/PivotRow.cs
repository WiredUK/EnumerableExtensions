using System.Collections.Generic;

namespace EnumerableExtensions.Library.Models
{
    public class PivotRow<TValue, TColumn, TElement>
    {
        public TValue Value { get; set; }
        public IEnumerable<PivotColumnItem<TColumn, TElement>> Data { get; set; }
    }
}
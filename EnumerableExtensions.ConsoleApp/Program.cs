using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions.Library;

namespace EnumerableExtensions.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var data = new List<Thing>
            {
                new Thing {Product = "Cheese", Date = DateTime.UtcNow, Quantity = 5},
                new Thing {Product = "Cheese", Date = DateTime.UtcNow.AddMonths(1), Quantity = 10},
                new Thing {Product = "Cheese", Date = DateTime.UtcNow.AddMonths(1), Quantity = 15},
                new Thing {Product = "Fruit", Date = DateTime.UtcNow, Quantity = 5},
                new Thing {Product = "Fruit", Date = DateTime.UtcNow.AddMonths(1), Quantity = 5},
                new Thing {Product = "Fruit", Date = DateTime.UtcNow.AddMonths(1), Quantity = 5},
            };

            var pivottedData = data.Pivot(
                d => d.Product,
                e => e.Date.ToString("yyyy-MM"),
                k => k.Key,
                g => g.Sum(x => x.Quantity));

            foreach (var pivottedItem in pivottedData)
            {
                Console.WriteLine($"{pivottedItem.Value} has {pivottedItem.Data.Count()} items");
            }

            Console.ReadKey();
        }
    }
}

# Enumerable Extensions

I have no idea if I will ever use this (made it for fun), but I intend to keep a collection of extensions to help deal with enumerable data.

The only thing in here right now is a generic pivot method that will group and pivot data. Example usage:

Lets assume we have a class:

	public class Thing
	{
		public string Product { get; set; }
		public DateTime Date { get; set; }
		public int Quantity { get; set; }
	}

And some data:	

	var data = new List<Thing>
	{
		new Thing { Product = "Cheese", Date = DateTime.UtcNow, Quantity = 5 },
		new Thing { Product = "Cheese", Date = DateTime.UtcNow.AddMonths(1), Quantity = 10 },
		new Thing { Product = "Cheese", Date = DateTime.UtcNow.AddMonths(1), Quantity = 15 },
		new Thing { Product = "Fruit", Date = DateTime.UtcNow, Quantity = 5 },
		new Thing { Product = "Fruit", Date = DateTime.UtcNow.AddMonths(1), Quantity = 5 },
		new Thing { Product = "Fruit", Date = DateTime.UtcNow.AddMonths(1), Quantity = 5 },
	};

We can now pivot on this list like this:

	var pivottedData = data.Pivot(
		d => d.Product, 
		e => e.Date.ToString("yyyy-MM"), 
		k => k.Key, 
		g => g.Sum(x => x.Quantity));

Which gives a list like this:

[![enter image description here][1]][1]

  [1]: https://raw.githubusercontent.com/WiredUK/EnumerableExtensions/master/example-results.png
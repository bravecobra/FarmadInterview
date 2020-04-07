using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ReSharper disable All

namespace LinqPuzzle
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = GetItems().Skip(1).Take(2);

            Console.WriteLine("Retrieved all items");
            Console.WriteLine($"Count: {await items.CountAsync()}");
            await foreach (var item in items)
            {
                Console.WriteLine($"Item: {item}");
            }
        }

        public static async IAsyncEnumerable<string> GetItems()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
                Console.WriteLine($"Yielding {i + 1}");
                yield return $"{i + 1}";
            }
        }
    }
}

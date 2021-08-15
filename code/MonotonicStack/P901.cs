
using System;
using System.Collections.Generic;
using System.Linq;
namespace P901
{
    public class StockSpanner
    {
        List<int> _all = new List<int>();

        public StockSpanner()
        {

        }

        // brute force
        public int Next(int price)
        {
            _all.Add(price);
            var count = 1;
            for (var j = _all.Count - 2; j >= 0; j--)
            {
                if (_all[j] <= price)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }

    public class Test
    {
        public static void Run()
        {
            Console.WriteLine(String.Join(",", TestCase(new int[] { 100, 80, 60, 70, 60, 75, 85 }))); // [1,1,1,2,1,4,6]
        }

        static int[] TestCase(int[] prices)
        {
            var s = new StockSpanner();
            return prices.Select(x => s.Next(x)).ToArray();
        }
    }
}

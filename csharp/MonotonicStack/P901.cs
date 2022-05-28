
using System;
using System.Collections.Generic;
using System.Linq;
namespace P901
{
    public class StockSpanner
    {
        List<int> _all = new List<int>();

        Stack<(int price, int days)> _stack = new Stack<(int price, int days)>();
        int _currentIndex = -1;
        public StockSpanner()
        {
        }

        public int Next(int price)
        {
            while (_stack.Count > 0 && _stack.Peek().price <= price)
            {
                _stack.Pop();
            }

            var last = _stack.Count == 0 ? -1 : _stack.Peek().days;
            _currentIndex += 1;
            _stack.Push((price, _currentIndex));

            var ans = _currentIndex - last;
            return ans;

        }
        public int Next2(int price)
        {
            var ans = 1;
            {
                while (_stack.Count > 0 && _stack.Peek().price <= price)
                {
                    ans += _stack.Pop().days;
                }
                _stack.Push((price, ans));
                return ans;
            }
        }
        // brute force
        public int NextSlow(int price)
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

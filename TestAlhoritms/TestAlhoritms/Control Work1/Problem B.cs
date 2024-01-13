using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlhoritms.Control_Work1
{
    public class Problem_B
    {
        public void Solve() 
        {
            int n = int.Parse(Console.ReadLine());
            var memo = new Dictionary<int, uint>();
            Console.WriteLine(Comp(n));

            uint Comp(int n)
            {
                if (memo.ContainsKey(n)) { return memo[n]; }
                if (n <= 2)
                {
                    return 1;
                }
                else if (n % 2 == 1)
                {
                    memo[n] = Comp(6 * n / 7) + Comp(2 * n / 3);
                    return memo[n];
                }
                else
                {
                    memo[n] = Comp(n - 1) + Comp(n - 3);
                    return memo[n];
                }
            }
        }
    }
}

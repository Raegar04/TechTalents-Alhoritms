using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlhoritms.Control_Work2
{
    public class Problem_C
    {
        public void Solve()
        {
            int n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Console.WriteLine(GetGroups());

            int GetGroups()
            {
                numbers.Sort();
                numbers.Reverse();

                var data = new List<List<int>>();
                var res = 0;

                foreach (int number in numbers)
                {
                    bool add = false;

                    foreach (var item in data)
                    {
                        var sum = item.Sum();
                        if (sum + number == 10)
                        {
                            res++;
                            data.Remove(item);
                            add = true;
                            break;
                        }
                        if (sum + number < 10)
                        {
                            item.Add(number);
                            add = true;
                            break;
                        }
                    }

                    if (!add)
                    {
                        data.Add(new List<int> { number });
                    }
                }
                return res;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlhoritms.Control_Work2
{
    public class Problem_2_C
    {
        static void Main()
        {
            var data = new Dictionary<Coord, int>();
            var results = new List<int>();

            int n;
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid input for 'n'");
                return;
            }

            while (true)
            {
                var inp = Console.ReadLine();
                if (inp == "3")
                {
                    break;
                }

                var input = inp.Split(' ');

                if (int.TryParse(input[0], out int operation))
                {
                    switch (operation)
                    {
                        case 1:
                            ProcessOperation1(data, input);
                            break;
                        case 2:
                            ProcessOperation2(data, results, input);
                            break;
                        default:
                            Console.WriteLine("Invalid operation");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }
            }

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private static void ProcessOperation1(Dictionary<Coord, int> data, string[] input)
        {
            var coord = new Coord(ushort.Parse(input[1]), ushort.Parse(input[2]), ushort.Parse(input[3]));
            if (data.TryGetValue(coord, out int value))
            {
                data[coord] += int.Parse(input[4]);
            }
            else
            {
                data.Add(coord, int.Parse(input[4]));
            }
        }

        private static void ProcessOperation2(Dictionary<Coord, int> data, List<int> results, string[] input)
        {
            var range = new CoordRange(
                ushort.Parse(input[1]), ushort.Parse(input[4]),
                ushort.Parse(input[2]), ushort.Parse(input[5]),
                ushort.Parse(input[3]), ushort.Parse(input[6])
            );

            var sum = data.Where(item => range.Contains(item.Key)).Sum(item => item.Value);
            results.Add(sum);
        }
    }

    class Coord
    {
        public ushort X { get; }
        public ushort Y { get; }
        public ushort Z { get; }

        public Coord(ushort x, ushort y, ushort z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    class CoordRange
    {
        public ushort MinX { get; }
        public ushort MaxX { get; }
        public ushort MinY { get; }
        public ushort MaxY { get; }
        public ushort MinZ { get; }
        public ushort MaxZ { get; }

        public CoordRange(ushort minX, ushort maxX, ushort minY, ushort maxY, ushort minZ, ushort maxZ)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
            MinZ = minZ;
            MaxZ = maxZ;
        }

        public bool Contains(Coord coord)
        {
            return coord.X >= MinX && coord.X <= MaxX &&
                   coord.Y >= MinY && coord.Y <= MaxY &&
                   coord.Z >= MinZ && coord.Z <= MaxZ;
        }
    }
}

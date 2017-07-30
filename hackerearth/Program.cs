using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerearth
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<Tuple<int, int>> uv =
                new List<Tuple<int, int>>();

            //for (int i = 0; i < n - 1; i++)
            //{
            //    string pair = Console.ReadLine();
            //    uv.Add(new Tuple<int, int>(Convert.ToInt32(pair.Split(' ')[0]), Convert.ToInt32(pair.Split(' ')[1])));
            //}
                        
            uv = new List<Tuple<int, int>>() {
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(1, 3),
                    new Tuple<int, int>(3, 4),
                    new Tuple<int, int>(3, 5) };

            //n = 16;
            //uv = new List<Tuple<int, int>> {
            //new Tuple<int, int>(12, 1),
            //new Tuple<int, int>(12, 3   ),
            //new Tuple<int, int>(12, 4   ),
            //new Tuple<int, int>(13, 5   ),
            //new Tuple<int, int>(13, 7   ),
            //new Tuple<int, int>(10, 8   ),
            //new Tuple<int, int>(2 , 9   ),
            //new Tuple<int, int>(15, 12  ),
            //new Tuple<int, int>(6 , 13  ),
            //new Tuple<int, int>(11, 6   ),
            //new Tuple<int, int>(2 , 11  ),
            //new Tuple<int, int>(15, 2   ),
            //new Tuple<int, int>(14, 15  ),
            //new Tuple<int, int>(14, 16  ),
            //new Tuple<int, int>(10, 14  ) };

            //n = 53178;
            //for (int i = 0; i < Data.pairs.Length; i++)
            //{
            //    string pair = Data.pairs[i];
            //    uv.Add(new Tuple<int, int>(Convert.ToInt32(pair.Split(' ')[0]), Convert.ToInt32(pair.Split(' ')[1])));
            //}

            //ConsoleApplication1.KingsSons.Count = n;
            //ConsoleApplication1.KingsSons.RunProg(n, uv);

            n = 5;
            //uv =
            //    new List<Tuple<int, int>>()
            //    {
            //        new Tuple<int, int>(1, 2),
            //        new Tuple<int, int>(1, 3),
            //        new Tuple<int, int>(1, 4)
            //    };

            //ConsoleApplication1.KingsSons.cities = new List<ConsoleApplication1.CityNode>();
            //ConsoleApplication1.KingsSons.Count = n;
            //ConsoleApplication1.KingsSons.RunProg(n, uv);

            SimpleKingsSons.Count = n;
            SimpleKingsSons.BuildLinks(uv);
            var res = SimpleKingsSons.Compute(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerearth
{
    public static class SimpleKingsSons
    {
        //public static int[] cities;
        public static int Count;
        public static List<int>[] LinkedCities;
        public static Ruler[] CityRulers;
        
        public static long Compute(int currentNode)
        {
            if (currentNode >= Count)
                return CheckIfGraphIsValid() ? 1 : 0;

            CityRulers[currentNode] = Ruler.B;

            var l = Compute(currentNode + 1);

            CityRulers[currentNode] = Ruler.R;

            var r = Compute(currentNode + 1);

            return l + r;
        }

        public static void BuildLinks(List<Tuple<int, int>> links)
        {
            CityRulers = new Ruler[Count];
            LinkedCities = new List<int>[Count];

            for (int i = 0; i < Count; i++)
                LinkedCities[i] = new List<int>();
            
            foreach (var link in links)
            {
                LinkedCities[link.Item1 - 1].Add(link.Item2 - 1);
            }
        }

        public static bool IsDisputed(int cityNumber)
        {
            return !LinkedCities[cityNumber].All(c => CityRulers[c - 1].Equals(GetEnemy(CityRulers[cityNumber])));
        }

        public static Ruler? GetEnemy(Ruler ruler)
        {
            switch(ruler)
            {
                case Ruler.B:
                    return Ruler.R;
                case Ruler.R:
                    return Ruler.B;
            }

            return null;
        }
        
        public static bool CheckIfGraphIsValid()
        {
            return Enumerable.Range(0, Count - 1).Any(i => IsDisputed(i));
        }
    }
}

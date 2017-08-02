using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackerearth
{
    public struct City{
        public KingsSonsGraphTraversal.Ruler ruler;
        public int cityNumber;
    }

    public static class KingsSonsGraphTraversal
    {
        public enum Ruler
        {
            N,
            B,
            R
        }

        //public static int[] cities;
        public static int Count;
        public static List<int>[] LinkedCities;
        public static Ruler[] Rulers;
        public static Dictionary<List<City>, bool> memo = new Dictionary<List<City>, bool>();

        public static void BuildLinks(List<Tuple<int, int>> links)
        {
            Rulers = new Ruler[Count];
            LinkedCities = new List<int>[Count];

            for (int i = 0; i < Count; i++)
                LinkedCities[i] = new List<int>();

            foreach (var link in links)
            {
                LinkedCities[link.Item1 - 1].Add(link.Item2 - 1);
                LinkedCities[link.Item2 - 1].Add(link.Item1 - 1);
            }
        }

        public static bool IsDisputed(int cityNumber)
        {
            var enemy = GetEnemy(Rulers[cityNumber]);
            var linkedCities = LinkedCities[cityNumber];

            foreach (var linkedCity in linkedCities)
                if (!Rulers[linkedCity].Equals(enemy))
                    return false;

            return true;
        }

        public static Ruler? GetEnemy(Ruler ruler)
        {
            switch (ruler)
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
            for (int i = 0; i < Count; i++)
                if (IsDisputed(i))
                    return false;

            return true;
        }

        //public static long Traverse(int nodeNumber, int lastNodeNumber)
        //{
             
        //}

        public static bool IsSetValid(List<City> citySet)
        {
            return citySet.Any(cs => LinkedCities[cs.cityNumber].All(lc => Rulers[lc].Equals(GetEnemy(cs.ruler))));

            //foreach(var city in citySet)
            //    //GetEnemy(city.ruler)
            //    if (LinkedCities[city.cityNumber].All)
        }
    }
}

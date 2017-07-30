using System;
using System.Collections.Generic;

namespace hackerearth
{
    public static class SimpleKingsSons
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
        
        public static long Compute(int currentNode)
        {
            if (currentNode >= Count)
                return CheckIfGraphIsValid() ? 1 : 0;

            Rulers[currentNode] = Ruler.B;

            var l = Compute(currentNode + 1);

            Rulers[currentNode] = Ruler.R;

            var r = Compute(currentNode + 1);

            return l + r;
        }

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

        public static bool AreAllNeigboursEnemies(int cityNumber)
        {
            var enemy = GetEnemy(Rulers[cityNumber]);
            var neighbours = LinkedCities[cityNumber];

            foreach (var neighbour in neighbours)
                if (!Rulers[neighbour].Equals(enemy))
                    return false;

            return true;
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
            for (int i = 0; i < Count; i++)
                if (IsDisputed(i))
                    return false;

            return true;
        }
    }
}

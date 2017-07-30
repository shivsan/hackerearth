using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum Child
    {
        None,
        Bettie,
        Reggie
    }

    public abstract class City
    {
        public int CityNumber { get; set; }

        public Child Ruler { get; set; }

        public abstract Child GetRuler();
        
        public abstract Child? GetEnemy();

        public abstract bool IsDisputed();
    }

    [DebuggerDisplay("CityNum = {CityNumber}, Ruler = {Ruler}")]
    public class CityNode: City
    {
        public new int CityNumber { get; set; }

        public List<City> Cities { get; set; }
        
        public CityNode(int cityNumber)
        {
            CityNumber = cityNumber;
            Ruler = Child.None;
            Cities = new List<City>();
        }

        public override Child GetRuler()
        {
            return Ruler;
        }

        public override Child? GetEnemy()
        {
            if (Ruler.Equals(Child.Bettie))
                return Child.Reggie;
            if (Ruler.Equals(Child.Reggie))
                return Child.Bettie;
            return null;
        }

        public override bool IsDisputed()
        {
            return !Ruler.Equals(Child.None) && Cities.All(c=>Ruler.Equals(c.GetEnemy()));
        }
    }

    public class KingsSons
    {
        public static int Count = 0;
        public static List<CityNode> cities = new List<CityNode>();
        public static readonly long mod = (long)Math.Pow(10, 9) + 7;
         
        public static List<CityNode> CreateCityNodes(int n, List<Tuple<int, int>> uv)
        {
            foreach(var road in uv)
            {                
                CityNode cityNode1 = GetCityNode(road.Item1);
                CityNode cityNode2 = GetCityNode(road.Item2);

                cityNode1.Cities.Add(cityNode2);
                cityNode2.Cities.Add(cityNode1);
            }

            return cities;
        }

        public static int RunProg(int n, List<Tuple<int, int>> uv)
        {
            CreateCityNodes(n, uv);
            var ans1 = GetNumberOfArrangements(1);
            return 0;
        }

        public static long GetNumberOfArrangements(int currentCity)
        {
            if (currentCity > Count)
                return CheckIfGraphIsValid() ? 1 : 0;

            var city = GetCityByNumber(currentCity);
            city.Ruler = Child.Bettie;

            var l = GetNumberOfArrangements(currentCity + 1);

            city.Ruler = Child.Reggie;

            var r = GetNumberOfArrangements(currentCity + 1);

            return (l + r) % mod;
        }

        private static CityNode GetCityNode(int cityNumber)
        {
            if (cities.FirstOrDefault(c => c.CityNumber.Equals(cityNumber)) != null)
            {
                return cities.FirstOrDefault(c => c.CityNumber.Equals(cityNumber));
            }

            var newCityNode = new CityNode(cityNumber);
            cities.Add(newCityNode);
            return newCityNode;
        }

        public static bool CheckIfGraphIsValid()
        {
            return !cities.Any(c=>c.IsDisputed());
        }

        public static CityNode GetCityByNumber(int cityNumber)
        {
            return cities.First(c=>c.CityNumber.Equals(cityNumber));
        }
    }
}
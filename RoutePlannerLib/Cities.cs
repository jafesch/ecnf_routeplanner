using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public int Count { get { return cities.Count; } }
        List<City> cities = new List<City>();

        public int ReadCities(string filename)
        {
            int count = 0;

                TextReader reader = File.OpenText(filename);
                
                String s;
                Char[] separator = {'\t'};
                City city;
                while ((s = reader.ReadLine()) != null)
                {
                    count++;
                    city = new City(s.Split(separator)[0], 
                        s.Split(separator)[1], 
                        int.Parse(s.Split(separator)[2]), 
                        double.Parse(s.Split(separator)[3]), 
                        double.Parse(s.Split(separator)[4])
                        );
                    cities.Add(city);
                }
                return count;
        }

        public City this[int i]{
            get
            {
                if (i < Count) { return cities[i]; } else { return null; }
            }
        }

        public List<City> FindNeighbours(WayPoint location, double distance)
        {
            List<City> citiesTemp = new List<City>();
            for (int i = 0; i < cities.Count; i++)
            {
                if (location.Distance(cities[i].Location) <= distance)
                {
                    citiesTemp.Add(cities[i]);
                }
            }

            return citiesTemp;
        }
    }
}

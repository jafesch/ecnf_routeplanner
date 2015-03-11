﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System.Globalization;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        public int Count { get { return cities.Count; } }
        List<City> cities = new List<City>();

        //Lab3 1
        public City FindCity(string cityName)
        {
            Predicate<City> predicateDelegate = delegate(City city)
            {
                return String.Compare(city.Name, cityName, true) == 0;
            };

            return cities.Find(predicateDelegate);
        }

        public int ReadCities(string filename)
        {
            int count = 0;
            using (TextReader reader = new StreamReader(filename))
            {
                IEnumerable<string[]> citiesAsStrings = reader.GetSplittedLines('\t');
                foreach (string[] cs in citiesAsStrings)
                {
                    City city = new City(
                        cs[0].Trim(),
                        cs[1].Trim(),
                        int.Parse(cs[2]),
                        double.Parse(cs[3], CultureInfo.InvariantCulture),
                        double.Parse(cs[4], CultureInfo.InvariantCulture)
                        );
                    cities.Add(city);
                    count++;
                }

            }
            return count;
        }

        public City this[int i]
        {
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

        #region Lab04: FindShortestPath helper function
        /// <summary>
        /// Find all cities between 2 cities 
        /// </summary>
        /// <param name="from">source city</param>
        /// <param name="to">target city</param>
        /// <returns>list of cities</returns>
        public List<City> FindCitiesBetween(City from, City to)
        {
            var foundCities = new List<City>();
            if (from == null || to == null)
                return foundCities;

            foundCities.Add(from);

            var minLat = Math.Min(from.Location.Latitude, to.Location.Latitude);
            var maxLat = Math.Max(from.Location.Latitude, to.Location.Latitude);
            var minLon = Math.Min(from.Location.Longitude, to.Location.Longitude);
            var maxLon = Math.Max(from.Location.Longitude, to.Location.Longitude);

            foundCities.AddRange(cities.FindAll(c =>
                c.Location.Latitude > minLat && c.Location.Latitude < maxLat
                        && c.Location.Longitude > minLon && c.Location.Longitude < maxLon));

            foundCities.Add(to);
            return foundCities;
        }
        #endregion
    }
}

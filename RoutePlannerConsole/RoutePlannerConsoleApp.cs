using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerConsole
{
    class RoutePlannerConsoleApp
    {
        static void Main(string[] args)
        {
            //Lab1 Aufgabe 1
            Console.WriteLine("Welcome to RoutePlanner (Version " + Assembly.GetExecutingAssembly().GetName().Version + ")");

            //Lab1 Aufgabe 2d
            var wayPoint = new WayPoint("Windisch", 47.479319847061966, 8.212966918945312);
            Console.WriteLine("{0}: {1}/{2}", wayPoint.Name, wayPoint.Latitude, wayPoint.Longitude);

            //Lab2 Aufgabe 1a
            Console.WriteLine(wayPoint);
            var wayPoint1 = new WayPoint("", 47.479319847061966, 8.212966918945312);
            var wayPoint2 = new WayPoint(null , 47.479319847061966, 8.212966918945312);
            Console.WriteLine(wayPoint1);
            Console.WriteLine(wayPoint2);

            //Lab2 Aufgabe 1b
            var bern = new WayPoint("Bern", 46.948342, 7.442935);
            var tripolis = new WayPoint("Tripolis", 32.808858, 13.098922);
            Console.WriteLine(bern.Distance(tripolis));
            Console.WriteLine(tripolis.Distance(bern));

            //Lab2 Aufgabe 2a
            new City("Bern", "Schweiz", 75000, 47.479319847061966, 8.212966918945312);

            //Lab2 Aufgabe 2b
            Cities cities = new Cities();
            Console.WriteLine("New cities: " + cities.ReadCities("citiesTestDataLab2.txt"));

            //Lab2 Aufgabe 2c
            /*
            for (int i = 0; i < cities.Count;i++ )
            {
                Console.WriteLine(cities[i].Name + ", " + cities[i].Country
                    + ", " + cities[i].Population 
                    + ", " + cities[i].Location.Latitude
                    + ", " + cities[i].Location.Longitude
                    );
            }
            */

            //Lab2 Aufgabe 2d
            List<City> neighbours = cities.FindNeighbours(cities[1].Location, (double)17000.0);
            for (int i = 0; i < neighbours.Count; i++)
            {
                Console.WriteLine(neighbours[i].Name + ", " + neighbours[i].Country
                    + ", " + neighbours[i].Population
                    + ", " + neighbours[i].Location.Latitude
                    + ", " + neighbours[i].Location.Longitude
                    );
            }

            //Lab3 Aufgabe 1
            City city = cities.FindCity("shanghai");
            Console.WriteLine("Name: " + city.Name + ", " + city.Country
                    + ", " + city.Population
                    + ", " + city.Location.Latitude
                    + ", " + city.Location.Longitude
                    );

            Console.ReadLine();
        }
    }
}

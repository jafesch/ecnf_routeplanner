using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util;
using System.IO;

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


            //Lab3 Aufgabe 2c
            var reqWatch = new RouteRequestWatcher();

            var routeCities = new Cities();
            cities.ReadCities("citiesTestDataLab2.txt");

            var routes = new Routes(routeCities);

            routes.RouteRequestEvent += reqWatch.LogRouteRequests;

            routes.FindShortestRouteBetween("Bern", "Zürich", TransportModes.Rail);
            routes.FindShortestRouteBetween("Bern", "Zürich", TransportModes.Rail);
            routes.FindShortestRouteBetween("Basel", "Bern", TransportModes.Rail);


            const string cityString1 = "Instance of Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.City\r\nName=\"Aarau\"\r\nCountry=\"Switzerland\"\r\nPopulation=10\r\nLocation is a nested object...\r\nInstance of Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.WayPoint\r\nName=\"Aarau\"\r\nLongitude=2.2\r\nLatitude=1.1\r\nEnd of instance\r\nEnd of instance\r\n";
            const string cityString2 = "Instance of Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.City\r\nName=\"Bern\"\r\nCountry=\"Switzerland\"\r\nPopulation=10\r\nLocation is a nested object...\r\nInstance of Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.WayPoint\r\nName=\"Bern\"\r\nLongitude=2.2\r\nLatitude=1.1\r\nEnd of instance\r\nEnd of instance\r\n";
            const string cityString = cityString1 + cityString2;
            var expectedCity1 = new City("Aarau", "Switzerland", 10, 1.1, 2.2);
            var expectedCity2 = new City("Bern", "Switzerland", 10, 1.1, 2.2);
            var stream = new StringReader(cityString);
            var reader = new SimpleObjectReader(stream);
            var city1 = reader.Next() as City;

            var city2 = reader.Next() as City;

            Console.ReadLine();
        }
    }
}

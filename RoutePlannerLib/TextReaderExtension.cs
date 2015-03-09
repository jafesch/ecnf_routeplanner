using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib.Util
{
    public static class TextReaderExtension
    {
        //public int ReadCities(this string filename)
        //{
        //    using (TextReader reader = new StreamReader(filename))
        //    {
        //        IEnumerable<string[]> citiesAsStrings = reader.GetSplittedLines('\t');

        //        //for... ??? { cities.Add(new City(cs[0].Trim(), cs[1].Trim(), int.Parse(cs[2]), double.Parse(cs[3]), double.Parse(cs[4])));
        //    }
        //}

        //public int ReadCities(string filename)
        //{
        //    int count = 0;

        //    TextReader reader = File.OpenText(filename);

        //    String s;
        //    Char[] separator = { '\t' };
        //    City city;
        //    while ((s = reader.ReadLine()) != null)
        //    {
        //        count++;
        //        city = new City(s.Split(separator)[0],
        //            s.Split(separator)[1],
        //            int.Parse(s.Split(separator)[2]),
        //            double.Parse(s.Split(separator)[3]),
        //            double.Parse(s.Split(separator)[4])
        //            );
        //        cities.Add(city);
        //    }
        //    return count;
        //}
    }
}

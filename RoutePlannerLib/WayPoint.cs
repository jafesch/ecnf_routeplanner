using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class WayPoint
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public WayPoint(string _name, double _latitude, double _longitude)
        {
            Name = _name;
            Latitude = _latitude;
            Longitude = _longitude;
        }

        public override string ToString()
        {
            if(Name == null || Name == "")
            {
                return String.Format("WayPoint: {0}/{1}", Math.Round(Latitude,2), Math.Round(Longitude,2));
            }else{
                return String.Format("WayPoint: {0} {1}/{2}", Name, Math.Round(Latitude,2), Math.Round(Longitude,2));
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Location
    {
        public Location()
        {
            this.Longitude = 0;
            this.Latitude = 0;
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}

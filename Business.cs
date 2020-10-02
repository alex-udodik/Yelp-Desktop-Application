using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Business
    {
        private readonly Location location;

        public Business()
        {
            this.BusinessID = "";
            this.Name = "";
            this.Address = "";
            this.City = "";
            this.State = "";
            this.Distance = 0;
            this.location = new Location();
            this.Latitude = 0;
            this.Longitude = 0;
            this.Stars = 0;
            this.Tips = 0;
            this.Checkins = 0;
            this.ZipCode = 0;
        }

        public string BusinessID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Distance { get; set; }
        public double Latitude
        {
            get
            {
                return this.location.Latitude;
            }

            set
            {
                this.location.Latitude = value;
            }
        }
        public double Longitude
        {
            get
            {
                return this.location.Longitude;
            }

            set
            {
                this.location.Longitude = value;
            }
        }
        public double Stars { get; set; }
        public int Tips { get; set; }
        public int Checkins { get; set; }
        public int ZipCode { get; set; }
    }
}

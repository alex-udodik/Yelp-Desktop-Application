using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class User
    {
        private readonly Location location;

        public User()
        {
            this.UserID = "";
            this.Name = "";
            this.StarAverage = 0;
            this.Fans = 0;
            this.Cool = 0;
            this.TipCount = 0;
            this.Funny = 0;
            this.TotalLikes = 0;
            this.Useful = 0;
            this.location = new Location();
            this.Latitude = 0;
            this.Longitude = 0;
            this.SignupDate = "";
        }

        public string UserID { get; set; }
        public string Name { get; set; }
        public double StarAverage { get; set; }
        public int Fans { get; set; }
        public int Cool { get; set; }
        public int TipCount { get; set; }
        public int Funny { get; set; }
        public int TotalLikes { get; set; }
        public int Useful { get; set; }
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
        public string SignupDate { get; set; }
    }
}

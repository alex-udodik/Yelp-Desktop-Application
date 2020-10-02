using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Checkin
    {
        public Checkin()
        {
            this.BusinessID = "";
            this.Year = "";
            this.Month = "";
            this.Day = "";
            this.Time = "";
        }

        public string BusinessID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}

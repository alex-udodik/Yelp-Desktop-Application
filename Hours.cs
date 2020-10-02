using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Hours
    {
        public Hours()
        {
            this.BusinessID = "";
            this.DayOfWeek = "";
            this.Close = "";
            this.Open = "";
        }

        public string BusinessID { get; set; }
        public string DayOfWeek { get; set; }
        public string Close { get; set; }
        public string Open { get; set; }
    }
}

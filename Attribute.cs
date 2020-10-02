using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Attribute
    {
        public Attribute()
        {
            this.BusinessID = "";
            this.Name = "";
            this.Value = "";
        }

        public string BusinessID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

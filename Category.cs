using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class Category
    {
        public Category()
        {
            this.BusinessID = "";
            this.Name = "";
        }

        public string BusinessID { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS451_Milestone1
{
    public class BusinessOwner
    {
        private readonly Business business;

        public BusinessOwner()
        {
            this.BusinessOwnerID = "";
            this.business = new Business();
        }

        public string BusinessOwnerID { get; set; }
        public Business Business 
        {
            get 
            {
                return this.business;
            }
        }
        public int Checkins 
        { 
            get
            {
                return this.business.Checkins;
            }
        }
        public int TipsCount
        {
            get
            {
                return this.business.Tips;
            }
        }
    }
}

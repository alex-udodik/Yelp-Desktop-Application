﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsWindow
{
    public class Tip
    {
        public Tip()
        {
            this.BusinessID = "";
            this.UserID = "";
            this.UserName = "";
            this.Date = "";
            this.Likes = 0;
            this.Text = "";
            this.City = "";
            this.Yelping = "";
        }

        public string BusinessID { get; set; }
        public string UserID { get; set; }
        public string Date { get; set; }
        public int Likes { get; set; }
        public string Text { get; set; }
        public string City { get; set; }

        public string UserName { get; set; }
        public string Yelping { get; set; }
    }
}

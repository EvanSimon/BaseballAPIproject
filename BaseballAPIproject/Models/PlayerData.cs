using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballAPIproject.Models
{
    public class PlayerData
    {

        public string ID { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PA { get; set; }
        public int SO { get; set; }
        public int SB { get; set; }
        public double SLG { get; set; }
        public double AVG { get; set; }
        

    }
}
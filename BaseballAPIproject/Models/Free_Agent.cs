//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseballAPIproject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Free_Agent
    {
        public string Name { get; set; }
        public string Pos { get; set; }
        public string Prev_Team { get; set; }

        public int Age { get; set; }
        public Nullable<double> Prev_WAR { get; set; }
        public Nullable<double> Proj_WAR { get; set; }
        public string Avg_Years { get; set; }
        public double Avg_Total { get; set; }
        public string Med_Years { get; set; }
        public double Med_Total { get; set; }
        public string QO { get; set; }
        public string Signing_Team { get; set; }
        public string Date { get; set; }
        public string Years { get; set; }
        public string Salary { get; set; }
        public string column_16 { get; set; }
        public int playerid { get; set; }
        public double SalToWar { get; set; }
    }
}

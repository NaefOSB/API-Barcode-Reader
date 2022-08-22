using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Al_AMEEN_API.Models
{
    public class Material
    {
        public string Name { get; set; }
        public string Group_Name { get; set; }
        public string Currency { get; set; }
        public string Unity { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }

        public double Price1 { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }

        public double Unit2Fact { get; set; }
        public double Unit3Fact { get; set; }

        public string Picture { get; set; }
        public int SearchedKind { get; set; }


    }
}
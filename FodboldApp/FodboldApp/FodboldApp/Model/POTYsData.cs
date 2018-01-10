using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Data
{
    class POTYsData
    {
        public string Name { get; set; }
        public string Year { get; set; }

        public static List<POTYsData> Players { get; set; } = new List<POTYsData>();
            //{
            //    List<POTYsData> players = 
            //{
            //    new POTYsData() {Name = "George Lees", Year = "1958"},
            //    new POTYsData() {Name = "Egon Henriksen", Year = "1959"},
            //    new POTYsData() {Name = "Ib Eskildsen og Søren Andersen", Year = "1960"},
            //    new POTYsData() {Name = "Birger Larsen", Year = "1961"},
            //    new POTYsData() {Name = "Kaj Hansen", Year = "1962"}
            //    };
    }
}

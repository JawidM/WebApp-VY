using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class Route
    {
    
        
        public int RouteID { get; set; }
        
        public int RouteLength { get; set; }


        public List<Station> RouteStations { get; set; }
        public  List<Train> RouteTrains { get; set; }




    }
}
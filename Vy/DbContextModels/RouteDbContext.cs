using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vy.Models;

namespace Vy.DbContextModels
{
    [Table("Routes")]

    public class RouteDbContext
    {

        [Key]
        public int RouteID { get; set; }

        public int RouteLength { get; set; }



        public virtual List<StationDbContext> RouteStations { get; set; }
        public virtual List<TrainDbContext> RouteTrains { get; set; }
        public virtual List<TicketDbContext> RouteTickets { get; set; }



    }
}
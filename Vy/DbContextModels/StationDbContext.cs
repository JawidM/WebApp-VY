using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vy.DbContextModels
{
    [Table("Stations")]

    public class StationDbContext
    {
        [Key]
        public int StationID { get; set; }
        public string StationName { get; set; }

        public virtual List<RouteDbContext> StationRoutes { get; set; }
        public virtual List<TrainScheduleDbContext> TrainSchedules { get; set; }


    }
}
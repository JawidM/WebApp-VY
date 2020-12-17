using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class Station {

        public int StationID { get; set; }

        public string StationName { get; set; }

        public virtual List<TrainSchedule> TrainSchedules { get; set; }



    }
}
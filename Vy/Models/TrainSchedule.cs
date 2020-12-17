using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class TrainSchedule
    {
        public int StationID { get; set; }
        public int TrainID { get; set; }

        public virtual Station Station { get; set; }
        public virtual Train Train { get; set; }


        public DateTime TrainArrivalTime { get; set; }
    }
}
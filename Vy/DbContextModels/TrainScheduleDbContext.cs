using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vy.DbContextModels
{
    [Table("TrainSchedules")]
    public class TrainScheduleDbContext
    {
        [Key]
        public int TrainScheduleID { get; set; }

        public int StationID { get; set; }
        public int TrainID { get; set; }

        [ForeignKey("StationID")]
        [InverseProperty("TrainSchedules")]


        public virtual StationDbContext Station { get; set; }
        [ForeignKey("TrainID")]
        [InverseProperty("TrainSchedules")]


        public virtual TrainDbContext Train { get; set; }



        public DateTime TrainArrivalTime { get; set; }
    }
}
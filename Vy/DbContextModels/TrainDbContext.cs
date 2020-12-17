using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vy.Models;

namespace Vy.DbContextModels
{
    [Table("Trains")]

    public class TrainDbContext
    {
        [Key]
        public int TrainID { get; set; }

        public virtual List<TrainScheduleDbContext> TrainSchedules { get; set; }




    }
}
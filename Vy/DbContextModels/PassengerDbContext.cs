using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vy.Models;

namespace Vy.DbContextModels
{
    [Table("Passengers")]
    public class PassengerDbContext
    {
        [Key]
        public int PassengerID { get; set; }

        public string PassengerType { get; set; }

    }
}
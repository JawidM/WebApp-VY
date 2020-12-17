using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vy.Models;

namespace Vy.DbContextModels
{
    [Table("Ticket")]

    public class TicketDbContext
    {
        [Key]
        public int TicketID { get; set; }

        public int TicketPrice { get; set; }

        public int TicketDuration { get; set; }

        public string StartStation { get; set; }

        public string EndStation { get; set; }

        public DateTime TicketPurchaseDate { get; set; }

        public DateTime TicketPurchaseTime { get; set; }

        public string OrderedBy { get; set; }

        public virtual RouteDbContext TicketRoute { get; set; }

        public virtual List<PassengerDbContext> TicketPassengers { get; set; }
    }
}
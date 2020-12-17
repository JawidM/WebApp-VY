using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class Ticket
    {

        public int TicketID { get; set; }

        public int TicketPrice { get; set; }

        public int TicketDuration { get; set; }

        [Required(ErrorMessage = "Departure station should be provided")]
        public string StartStation { get; set; }
        [Required(ErrorMessage = "Destination should be provided")]
        public string EndStation { get; set; }

        [Required(ErrorMessage = "Date should be provided")]

        public DateTime TicketPurchaseDate { get; set; }


        public DateTime TicketPurchaseTime { get; set; }

        public string OrderedBy { get; set; }

        public Route TicketRoute { get; set; }

        public List<Passenger> TicketPassengers { get; set; }


    }
}
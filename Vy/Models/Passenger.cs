using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vy.Models
{
    public class Passenger
    {
        /*public int id { get; set; }
        public string passengerName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public int contactNumber { get; set; }*/
        public string email { get; set; }
        public int ticketPrice { get; set; }
        public int ticketNumber { get; set; }
        public string ticketType { get; set; }
        public string travellingClass { get; set; }
        public int dateOfJourney { get; set; }
        public int timeOfJourney { get; set; }
        public int transportNumber {get; set;}
        public string source { get; set; }
        public string destination { get; set; }
        public int arrivalTime { get; set; }
        public int departureTime { get; set; }
        }
    }
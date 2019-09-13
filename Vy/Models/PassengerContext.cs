using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Vy.Controllers
{
    public class Passengers
    {
        /*public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }*/
        [Key]
        public string Email { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
    public class Tickets
    {
        [Key]
        public int TicketNumber { get; set; }
        public int TicketPrice { get; set; }
        public string TravellingClass { get; set; }
        public int DateOfJourney { get; set; }
        public int TimeOfJourney { get; set; }
        public virtual Transports Transports { get; set; }
        public virtual List<Passengers> Passengers { get; set; }
    }

    public class Transports
    {
        [Key]
        public int TransportNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int ArrivalTime { get; set; }
        public int DepartureTime { get; set; }
        public virtual List<Tickets> Tickets { get; set; }
    }

    public class Route
    {
        public string Start { get; set; }
        public string Target { get; set; }
    }
    public class PassengerContext : DbContext
    {
        public PassengerContext() : base("name=Passenger")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Transports> Transports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vy.DbContextModels;
using Vy.Models;

namespace Vy.DAL
{
    public class TicketDAL
    {
        // Map Ticket object to TicketDbContext object
        public TicketDbContext MapTicketToTicketDb(Ticket OneTicket)
        {
            var RouteDAL = new RouteDAL();
            using (var db = new DB())
            {
                List<PassengerDbContext> DBTicketPassengers = new List<PassengerDbContext>();
                foreach (var Passenger in OneTicket.TicketPassengers)
                {
                    var DBPassenger = new PassengerDbContext()
                    {
                        PassengerType = Passenger.PassengerType
                    };
                    DBTicketPassengers.Add(DBPassenger);
                };
                var OneRoute = db.Routes.Find(OneTicket.TicketRoute.RouteID);
                var DBTicket = new TicketDbContext()
                {
                    TicketDuration = OneTicket.TicketDuration,
                    TicketPrice = OneTicket.TicketPrice,
                    TicketPurchaseDate = OneTicket.TicketPurchaseDate,
                    TicketPurchaseTime = OneTicket.TicketPurchaseTime,
                    OrderedBy = OneTicket.OrderedBy,
                    StartStation = OneTicket.StartStation,
                    EndStation = OneTicket.EndStation,
                    TicketPassengers = DBTicketPassengers,
                    TicketRoute = OneRoute

                };
               

                return DBTicket;
            }
        }

        // Map TicketDbContext object to Ticket object
        public Ticket MapTicketDbToTicket(TicketDbContext TicketDB)
        {
            var RouteDAL = new RouteDAL();
            using (var db = new DB())
            {
                List<Passenger> TicketPassengers = new List<Passenger>();
                foreach (var Passenger in TicketDB.TicketPassengers)
                {
                    var OnePassenger = new Passenger
                    {
                        PassengerID = Passenger.PassengerID,
                        PassengerType = Passenger.PassengerType
                    };
                    TicketPassengers.Add(OnePassenger);
                }
                var OneTicket = new Ticket
                {
                    TicketID = TicketDB.TicketID,
                    TicketDuration = TicketDB.TicketDuration,
                    TicketPrice = TicketDB.TicketPrice,
                    TicketPurchaseDate = TicketDB.TicketPurchaseDate,
                    TicketPurchaseTime = TicketDB.TicketPurchaseTime,
                    OrderedBy = TicketDB.OrderedBy,
                    StartStation = TicketDB.StartStation,
                    EndStation = TicketDB.EndStation,
                    TicketRoute = RouteDAL.MapRouteDBToRoute(TicketDB.TicketRoute),
                    TicketPassengers = TicketPassengers
                };
                return OneTicket;
            }
        }

        // Return a list of all tickets
        public List<Ticket> getAllTickets()
        {
            using (var db = new DB())
            {
                List<Ticket> AllTickets = new List<Ticket>();
                List<TicketDbContext> AllTicketsFromDB = db.Tickets.ToList();
                foreach (var TicketDb in AllTicketsFromDB)
                {
                    var OneTicket = MapTicketDbToTicket(TicketDb);
                    AllTickets.Add(OneTicket);

                }
                return AllTickets;
             }
        }

        // Return one ticket by ID
        public Ticket getTicketByID(int TicketID)
        {
            using (var db = new DB())
            {
                var OneTicketFromDB = db.Tickets.Where(t => t.TicketID == TicketID).
                    SingleOrDefault();

                var OneTicket = MapTicketDbToTicket(OneTicketFromDB);
                return OneTicket;

            }
        }

        // Save ticket to database
        public int SaveTicket(Ticket t)
        {
            using (var db = new DB())
            {
                try { 
                var TicketDB = MapTicketToTicketDb(t);
                    db.Routes.Attach(TicketDB.TicketRoute);
                    db.Tickets.Add(TicketDB);

                db.SaveChanges();
                    db.Entry(TicketDB).GetDatabaseValues();
                    int id = TicketDB.TicketID;
                    return id;

                }
                catch(Exception e)
                {
                    return 0;
      
                }

            }
        }
    }
}
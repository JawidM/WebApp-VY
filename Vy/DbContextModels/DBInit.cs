using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vy.Models;

namespace Vy.DbContextModels
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {

            // Initiate the datebase with data

            var Station1 = new StationDbContext
            {
                StationName = "Oslo s"
                

            };

            var Station2 = new StationDbContext
            {
                StationName = "Nationaltheatret"
            };

            var Station3 = new StationDbContext
            {
                StationName = "Lysaker"
            };

            var Station4 = new StationDbContext
            {
                StationName = "Myrdal"
            };

            var Station5 = new StationDbContext
            {
                StationName = "Bergen"
            };

          



            List<StationDbContext> RouteStations1 = new List<StationDbContext>
            {
                Station1,
                Station2,
                Station3
            };

            List<StationDbContext> RouteStations2 = new List<StationDbContext>
            {
                Station4,
                Station5,
                Station1
            };

            var Train1 = new TrainDbContext { };
            var Train2 = new TrainDbContext { };
            var Train3 = new TrainDbContext { };
            var Train4 = new TrainDbContext { };



            List<TrainDbContext> RouteTrains1 = new List<TrainDbContext>
            {
                Train1,
                Train2
            };

            List<TrainDbContext> RouteTrains2 = new List<TrainDbContext>
            {
                Train3,
                Train4
                
            };



            var Route1 = new RouteDbContext
            {
                RouteID = 1,
                RouteLength = 15,
                RouteStations = RouteStations1,
                RouteTrains = RouteTrains1

            };

            var Route2 = new RouteDbContext
            {
                RouteID = 2,
                RouteLength = 100,
                RouteStations = RouteStations2,
                RouteTrains = RouteTrains2


            };

            List<RouteDbContext> AllRoutes = new List<RouteDbContext>
            {
                Route1,
                Route2
            };

            var TrainSchedule1 = new TrainScheduleDbContext
            {
                Train = Train1,
                Station = Station1,
                TrainArrivalTime = new DateTime(2019, 10, 20, 11, 30, 0)
            };

            var TrainSchedule2 = new TrainScheduleDbContext
            {
                Train = Train1,
                Station = Station2,
                TrainArrivalTime = new DateTime(2019, 10, 20, 11, 35, 0)
            };

            var TrainSchedule3 = new TrainScheduleDbContext
            {
                Train = Train1,
                Station = Station3,
                TrainArrivalTime = new DateTime(2019, 10, 20, 11, 45, 0)
            };
            var TrainSchedule4 = new TrainScheduleDbContext
            {
                Train = Train2,
                Station = Station1,
                TrainArrivalTime = new DateTime(2019, 10, 20, 14, 00, 0)
            };

            var TrainSchedule5 = new TrainScheduleDbContext
            {
                Train = Train2,
                Station = Station2,
                TrainArrivalTime = new DateTime(2019, 10, 20, 14, 05, 0)
            };

            var TrainSchedule6 = new TrainScheduleDbContext
            {
                Train = Train2,
                Station = Station3,
                TrainArrivalTime = new DateTime(2019, 10, 20, 14, 15, 0)
            };

            var TrainSchedule7 = new TrainScheduleDbContext
            {
                Train = Train3,
                Station = Station5,
                TrainArrivalTime = new DateTime(2019, 10, 20, 15, 00, 0)
            };

            var TrainSchedule8 = new TrainScheduleDbContext
            {
                Train = Train3,
                Station = Station4,
                TrainArrivalTime = new DateTime(2019, 10, 20, 19, 15, 0)
            };

            var TrainSchedule9 = new TrainScheduleDbContext
            {
                Train = Train3,
                Station = Station1,
                TrainArrivalTime = new DateTime(2019, 10, 20, 21, 30, 0)
            };
            var TrainSchedule10 = new TrainScheduleDbContext
            {
                Train = Train4,
                Station = Station5,
                TrainArrivalTime = new DateTime(2019, 10, 20, 23, 30, 0)
            };

            var TrainSchedule11 = new TrainScheduleDbContext
            {
                Train = Train4,
                Station = Station4,
                TrainArrivalTime = new DateTime(2019, 10, 21, 03, 45, 0)
            };

            var TrainSchedule12 = new TrainScheduleDbContext
            {
                Train = Train4,
                Station = Station1,
                TrainArrivalTime = new DateTime(2019, 10, 21, 06, 30, 0)
            };

            var AllTrainSchedules = new List<TrainScheduleDbContext>
            {
                TrainSchedule1,
                TrainSchedule2,
                TrainSchedule3,
                TrainSchedule4,
                TrainSchedule5,
                TrainSchedule6,
                TrainSchedule7,
                TrainSchedule8,
                TrainSchedule9,
                TrainSchedule10,
                TrainSchedule11,
                TrainSchedule12
            };

            var Passenger1 = new PassengerDbContext
            {
                PassengerType = "Voksen"
            };

            var Passenger2 = new PassengerDbContext
            {
                PassengerType = "Voksen"
            };

            var Passenger3 = new PassengerDbContext
            {
                PassengerType = "Student"
            };

            var PassengerList1 = new List<PassengerDbContext>
            {
                Passenger1
            };

            var PassengerList2 = new List<PassengerDbContext>
            {
                Passenger2
            };
            var PassengerList3 = new List<PassengerDbContext>
            {
                Passenger1,
                Passenger3
            };

            var Ticket1 = new TicketDbContext
            {
                TicketDuration = 60,
                TicketPassengers = PassengerList1,
                TicketPrice =50,
                TicketRoute = Route1,
                StartStation = Station1.StationName,
                EndStation = Station3.StationName,
                OrderedBy = "ole@nordmann.no",
                TicketPurchaseDate = new DateTime(2019, 9, 29),
                TicketPurchaseTime = new DateTime(2019, 9, 29, 11, 30, 0)
            };


            var Ticket2 = new TicketDbContext
            {
                TicketDuration = 60,
                TicketPassengers = PassengerList2,
                TicketPrice = 50,
                TicketRoute = Route1,
                StartStation = Station3.StationName,
                EndStation = Station1.StationName,
                OrderedBy = "kari@nordmann.no",
                TicketPurchaseDate = new DateTime(2019, 9, 29),
                TicketPurchaseTime = new DateTime(2019, 9, 29, 15, 05, 0)
            };

            var Ticket3 = new TicketDbContext
            {
                TicketDuration = 290,
                TicketPassengers = PassengerList3,
                TicketPrice = 250,
                TicketRoute = Route2,
                StartStation = Station5.StationName,
                EndStation = Station1.StationName,
                OrderedBy = "kari@nordmann.no",
                TicketPurchaseDate = new DateTime(2019, 9, 29),
                TicketPurchaseTime = new DateTime(2019, 9, 29, 15, 05, 0)
            };

            List<TicketDbContext> AllTickets = new List<TicketDbContext>
            {
                Ticket1,
                Ticket2,
                Ticket3
            };


            

            foreach (TrainScheduleDbContext ts in AllTrainSchedules)
                context.TrainSchedules.Add(ts);

           foreach (RouteDbContext r in AllRoutes)
                context.Routes.Add(r);

            foreach (TicketDbContext t in AllTickets)
                context.Tickets.Add(t);


            base.Seed(context);

        }

    }

}
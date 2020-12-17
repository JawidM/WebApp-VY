using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vy.DbContextModels;
using Vy.Models;

namespace Vy.DAL
{
    public class RouteDAL
    {
        // Map a RouteDBContext object to Route object.
        public Route MapRouteDBToRoute(RouteDbContext RouteDB)
        {

            using (var db = new DB())
            {
                List<Station> RouteStations = new List<Station>();

                foreach (var s in RouteDB.RouteStations)
                {

                    List<TrainSchedule> TrainSchedules = new List<TrainSchedule>();

                    foreach (var ts in s.TrainSchedules)
                    {
                        var OneStation = new Station
                        {
                            StationID = ts.StationID,
                            StationName = ts.Station.StationName,


                        };

                        var OneTrain = new Train
                        {
                            TrainID = ts.TrainID,

                        };

                        var OneTrainSchedule = new TrainSchedule
                        {
                            StationID = ts.StationID,
                            TrainID = ts.TrainID,
                            Station = OneStation,
                            Train = OneTrain,
                            TrainArrivalTime = ts.TrainArrivalTime


                        };

                        TrainSchedules.Add(OneTrainSchedule);
                    }


                    var OtherStation = new Station
                    {
                        StationName = s.StationName,
                        TrainSchedules = TrainSchedules
                    };



                    RouteStations.Add(OtherStation);
                }

                List<Train> RouteTrains = new List<Train>();


                foreach (var t in RouteDB.RouteTrains)
                {
                    var OneTrain = new Train
                    {
                        TrainID = t.TrainID
                    };
                    RouteTrains.Add(OneTrain);
                }


                var OneRoute = new Route
                {
                    RouteID = RouteDB.RouteID,
                    RouteLength = RouteDB.RouteLength,
                    RouteStations = RouteStations,
                    RouteTrains = RouteTrains

                };


                return OneRoute;
            }
        }
        // Return all routes
        public List<Route> GetAllRoutes()
        {
            using (var db = new DB())
            {
                var allSRoutesFromDB = db.Routes.ToList();
                List<Route> allSRoutes = new List<Route>();
                foreach (var r in allSRoutesFromDB)
                {
                    var OneRoute = MapRouteDBToRoute(r);
                    allSRoutes.Add(OneRoute);

                }

                return allSRoutes;

            }
        }

        // Get one route by ID
        public Route getRouteById(int RouteID)
        {

            using (var db = new DB())
            {
                var OneRouteFromDB = db.Routes.Where(r => r.RouteID == RouteID).
                    SingleOrDefault();

                var OneRoute = MapRouteDBToRoute(OneRouteFromDB);
                return OneRoute;

            }

        }

        // Return one RouteDbContext by ID
        public RouteDbContext getRouteDBById(int RouteID)
        {

            using (var db = new DB())
            {
                var OneRouteFromDB = db.Routes.Where(r => r.RouteID == RouteID).
                    SingleOrDefault();

                return OneRouteFromDB;

            }

        }

        // Get the route between start and end stations from ticket object.
        public Ticket getRoute(Ticket ticket)
        {
            using (var db = new DB())
            {
                var s1 = db.Stations.SingleOrDefault(s => s.StationName == ticket.StartStation);
                var s2 = db.Stations.SingleOrDefault(s => s.StationName == ticket.EndStation);
                if(s1 != null && s2 != null) { 

                foreach (var r in s1.StationRoutes)
                {
                    foreach (var r2 in s2.StationRoutes)
                    {
                        if (r.RouteID == r2.RouteID)
                        {
                            var OneRoute = getRouteById(r.RouteID);
                            ticket.TicketPrice = 0;
                            switch (OneRoute.RouteID)
                            {
                                case 1:
                                    ticket.TicketDuration = 60;
                                    
                                    foreach (var passenger in ticket.TicketPassengers)
                                    {
                                        switch (passenger.PassengerType)
                                        {
                                            case "Adult":
                                                ticket.TicketPrice += 50;
                                                break;
                                            case "Student":
                                                ticket.TicketPrice += 30;
                                                break;
                                            case "Child":
                                                ticket.TicketPrice += 10;
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    ticket.TicketDuration = 120;
                                    foreach (var passenger in ticket.TicketPassengers)
                                    {
                                        switch (passenger.PassengerType)
                                        {
                                            case "Adult":
                                                ticket.TicketPrice += 300;
                                                break;
                                            case "Student":
                                                ticket.TicketPrice += 150;
                                                break;
                                            case "Child":
                                                ticket.TicketPrice += 75;
                                                break;
                                        }
                                    }
                                    break;
                            }

                           
                            ticket.TicketRoute = OneRoute;
                            return ticket;

                        }
                    }
                }
                }

                return ticket;
            }
        }

    }
}
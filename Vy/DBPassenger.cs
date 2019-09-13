using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vy.Controllers;

namespace Vy.Models
{
    public class DBPassenger
    { 
        public List<Passenger> allPassengers()
        {
            using (var db = new PassengerContext())
            {
                List<Passenger> allPassengers = db.Passengers.Select(k => new Passenger
                {
                    email = k.Email,
                    ticketPrice = k.Ticket.TicketPrice,
                    ticketNumber = k.Ticket.TicketNumber,
                    travellingClass = k.Ticket.TravellingClass,
                    dateOfJourney = k.Ticket.DateOfJourney,
                    timeOfJourney = k.Ticket.TimeOfJourney,
                    transportNumber = k.Ticket.Transports.TransportNumber,
                    source = k.Ticket.Transports.Source,
                    destination = k.Ticket.Transports.Destination,
                    arrivalTime = k.Ticket.Transports.ArrivalTime,
                    departureTime = k.Ticket.Transports.DepartureTime
                }).ToList();
                return allPassengers;
            }
        }

        public bool savePassenger (Passenger inPassenger)
        {
            using (var db = new PassengerContext())
            {
                try
                {
                    var newPassengerRow = new Passengers();
                    newPassengerRow.Email = inPassenger.email;

                    var checkTicket = db.Tickets.Find(inPassenger.ticketNumber);
                    if (checkTicket == null)
                    {
                        var newTicketRow = new Tickets();
                        newTicketRow.TicketNumber = inPassenger.ticketNumber;
                        newTicketRow.TicketPrice = inPassenger.ticketPrice;
                        newTicketRow.TravellingClass = inPassenger.travellingClass;
                        newTicketRow.DateOfJourney = inPassenger.dateOfJourney;
                        newTicketRow.TimeOfJourney = inPassenger.timeOfJourney;

                        var checkTrain = db.Transports.Find(inPassenger.transportNumber);
                        if (checkTrain == null)
                        {
                            var newTrainRow = new Transports();
                            newTrainRow.TransportNumber = inPassenger.transportNumber;
                            newTrainRow.Source = inPassenger.source;
                            newTrainRow.Destination = inPassenger.destination;
                            newTrainRow.ArrivalTime = inPassenger.arrivalTime;
                            newTrainRow.DepartureTime = inPassenger.departureTime;
                        }
                        db.Tickets.Add(newTicketRow);
                        db.SaveChanges();

                    }
                    db.Passengers.Add(newPassengerRow);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception fail)
                {
                    return false;
                }
            }
        }
    }
}
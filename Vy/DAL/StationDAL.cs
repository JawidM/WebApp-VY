using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vy.DbContextModels;
using Vy.Models;

namespace Vy.DAL
{
    public class StationDAL
    {
        // Map StationDbContext object to Station object
        public Station MapStationDBToStation(StationDbContext StationDB)
        {
            using (var db = new DB())
            {
                List<TrainSchedule> TrainSchedules = new List<TrainSchedule>();

                foreach (var ts in StationDB.TrainSchedules)
                {
                    var OneTrainScheduleStation = new Station
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
                        Station = OneTrainScheduleStation,
                        Train = OneTrain,
                        TrainArrivalTime = ts.TrainArrivalTime


                    };

                    TrainSchedules.Add(OneTrainSchedule);
                }


                var OneStation = new Station
                {
                    StationID = StationDB.StationID,
                    StationName = StationDB.StationName,
                    TrainSchedules = TrainSchedules
                };

                return OneStation;
            }
        }

        // Return list of all stations
        public List<Station> GetAllStation()
        {
            using (var db = new DB())
            {
                List<Station> AllStations = new List<Station>();
                var StationsListFromDb = db.Stations.ToList();
                foreach (var s in StationsListFromDb)
                {
                    var OneStation = MapStationDBToStation(s);
                    AllStations.Add(OneStation);
                }
                return AllStations;
            }
        }

        // Return a list of all stations names
        public List<Station> GetAllStationsName()
        {
            using (var db = new DB())
            {
                List<Station> AllStations = new List<Station>();
                var StationsListFromDb = db.Stations.ToList();

                var StationsListFromDb1 = db.Stations.ToList();
                foreach (var s in StationsListFromDb)
                {

                    var OneStation = new Station
                    {
                        StationID = s.StationID,
                        StationName = s.StationName,
                    };
                    AllStations.Add(OneStation);
                }
                return AllStations;
            }
        }
    }

}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Vy.DbContextModels
{
    public class DB : DbContext
    {
        public DB() : base("name=DB")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
        }


        public virtual DbSet<PassengerDbContext> Passengers { get; set; }
        public virtual DbSet<RouteDbContext> Routes { get; set; }
        public virtual DbSet<StationDbContext> Stations { get; set; }
        public virtual DbSet<TicketDbContext> Tickets { get; set; }
        public virtual DbSet<TrainDbContext> Trains { get; set; }
        public virtual DbSet<TrainScheduleDbContext> TrainSchedules { get; set; }


        



    }
}
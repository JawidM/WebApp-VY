using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vy.Models;

namespace Vy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Liste()
        {
            var db = new DBPassenger();
            List<Passenger> allPassenger = db.allPassengers();
            return View(allPassenger);
        }

        public ActionResult Book(Passenger inPassenger)
        {
            return View();
        }
    }
}
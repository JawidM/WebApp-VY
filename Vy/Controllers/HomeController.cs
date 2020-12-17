using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vy.DAL;
using Vy.Models;

namespace Vy.Controllers
{
    [HandleError]

    public class HomeController : Controller
    {
        // Return Homepage
        public ActionResult Index()
        {
            Session["Ticket"] = null;
            return View();
        }

        //Return All tickets page
        public ActionResult AllTickets()
        {
            var TicketDAL = new TicketDAL();
            List<Ticket> AllTickets = TicketDAL.getAllTickets();
            return View(AllTickets);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vy.DAL;
using Vy.DbContextModels;
using Vy.Models;

namespace Vy.Controllers
{
    [HandleError]
    public class RouteController : Controller
    {

        Ticket ticket = new Ticket();
    
        //Return Route page
        [HttpGet]
        public ActionResult Index()
        {

            Ticket ticket = (Ticket)Session["Ticket"];
            if(ModelState.IsValid) { 
            var RouteDAL = new RouteDAL();
            var OneTicket = RouteDAL.getRoute(ticket);
                return View(OneTicket);

            }

            return RedirectToAction("Index", "Home");
        }
        // Receive the ticket object from the home page
        [HttpPost]
        public ActionResult Index(Ticket t)
        {
            var RouteDAL = new RouteDAL();
            var OneTicket = RouteDAL.getRoute(t);
            Session["Ticket"] = OneTicket;
            return RedirectToAction("Index","Route");

        }

        // Make the ticket object available to JavaScript
        public string RouteJSON()
        {
            
            Ticket ticket = (Ticket)Session["Ticket"];
            var RouteDAL = new RouteDAL();
            var OneTicket = RouteDAL.getRoute(ticket);

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(OneTicket);
            return json;
        }


        }

}
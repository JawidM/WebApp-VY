using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vy.Models;
using Vy.DAL;


namespace Vy.Controllers
{
    public class ReceiptController : Controller
    {
        // Save the ticket to database
        [HttpPost]
        public ActionResult getReceipt(Ticket t)
        {

            var TicketDAL = new TicketDAL();

            int newTikcetID = TicketDAL.SaveTicket(t);
            if (newTikcetID != 0)
            {
                return Json(new { id = newTikcetID, newurl = Url.Action("getReceipt") });


            }
            return View();

        }
        // Return one ticket by ID
        [HttpGet]
        public ActionResult getReceipt(int id)
        {
            var TicketDAL = new TicketDAL();
            var t = TicketDAL.getTicketByID(id);
            return View(t);
        }

    }
}
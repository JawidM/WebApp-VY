using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vy.Controllers
{
    public class ErrorController : Controller
    {
        // Return not found error page
        public ActionResult pageNotFound()
        {
            return View();
        }

        // Return  server error page
        public ActionResult serverError()
        {
            return View();
        }
    }
}
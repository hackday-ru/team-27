using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntegrationServer.Controllers
{
    public class InputController : Controller
    {
        // GET: Input
        public ActionResult Mobile(string deviceId, string number, long ticks)
        {
            return Content(deviceId + " " + number + " " + new DateTime(ticks).ToString());
        }
    }
}
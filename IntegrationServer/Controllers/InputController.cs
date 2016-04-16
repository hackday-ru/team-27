using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntegrationServer.Models;
using IntegrationServer.Workflow;

namespace IntegrationServer.Controllers
{
    public class InputController : Controller
    {
        // GET: Input
        public ActionResult Mobile(string deviceId, string number, long ticks)
        {
            using (var ctx = new MessagesBase())
            {
                var message = new Message()
                {
                    DeviceSerial = deviceId,
                    SignalId = number,
                    ReceiveTime = DateTime.Now,
                    EventTime = new DateTime(ticks)
                };
                ctx.Messages.Add(message);
                ctx.SaveChanges();


                WorkflowService.ExecuteWorkflow(message, ctx);

            }
            return Content("OK");
        }
    }
}
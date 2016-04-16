using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegrationServer.Models;

namespace IntegrationServer.Workflow
{
    public class WorkflowService
    {

        internal static void ExecuteWorkflow(Message message, MessagesBase ctx)
        {
            var device = ctx.Devices.AsNoTracking().FirstOrDefault(d => d.Serial == message.DeviceSerial);
            if(device!=null)
            {
                Activity wf=null;
                if (device.WorkflowName == "TimingWorkflow")
                    wf = new TimingWorkflow();
                if (device.WorkflowName == "NotificationWorkflow")
                    wf = new NotificationWorkflow();
                if (wf != null) {
                    Dictionary<string, object> inputs = new Dictionary<string, object>();
                    inputs["Id"] = message.Id;
                    inputs["Device"] = device;
                    inputs["Message"] = message;

                    WorkflowInvoker.Invoke(wf, inputs);
                }
            }
        }
    }
}
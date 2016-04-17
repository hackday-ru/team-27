using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegrationServer.TrackMeProControl;

namespace IntegrationServer.ActivityActions
{
    public class TrackMeProConnector
    {
        public static void SendResult(int controlPointId, string startNumber, DateTime time)
        {
            var service = new ControlPointClient();
            service.SendTimeControl(controlPointId, startNumber, time);
        }
    }
}
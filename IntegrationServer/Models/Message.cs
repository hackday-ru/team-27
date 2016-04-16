using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationServer.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime ReceiveTime { get; set; }
        public string DeviceSerial { get; set; }
        public string SignalId { get; set; }
        public DateTime EventTime { get; set; }

        public DateTime? ProcessingFinish { get; set; }
        public DateTime? ProcessingStart { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationServer.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string WorkflowName { get; set; }

        public int ExternalId { get; set; }
    }
}
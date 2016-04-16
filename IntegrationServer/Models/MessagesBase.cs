using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IntegrationServer.Models
{
    public class MessagesBase : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Device> Devices { get; set; } 
    }
}
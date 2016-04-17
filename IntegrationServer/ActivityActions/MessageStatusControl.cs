using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntegrationServer.Models;

namespace IntegrationServer.ActivityActions
{
    public class MessageStatusControl
    {
        public static void MarkProcessing(int id)
        {
            using(var ctx = new MessagesBase() )
            {
                var item = ctx.Messages.First(m => m.Id == id).ProcessingStart = DateTime.UtcNow;
                ctx.SaveChanges();
            }
        }

        public static void MarkProcessed(int id)
        {
            using (var ctx = new MessagesBase())
            {
                var item = ctx.Messages.First(m => m.Id == id).ProcessingFinish = DateTime.UtcNow;
                ctx.SaveChanges();
            }
        }
    }
}
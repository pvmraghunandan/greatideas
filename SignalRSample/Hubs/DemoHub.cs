using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRSample.Hubs
{
    
    public class DemoHub: Hub
    {

        public String SendMessage(String pstrMessage)
        {
            Clients.All.SendMsg(pstrMessage);
            return "Sent Message";
        }

    }
}
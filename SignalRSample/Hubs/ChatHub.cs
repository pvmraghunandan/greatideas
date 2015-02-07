using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalRSample.Hubs
{
    public class ChatHub:Hub
    {
        public void BroadcastMessage(String fromuser,String message)
        {
            Clients.All.writeMessage(fromuser, message);
            Clients.All.alertMe();

            //sending messages to clients outside of hubs. For Example from WebAPI when something happened

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.alertMe();
        }
        public String MyMethod(DateTemp dt)
        {
            return "Hit the code";
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Debug.WriteLine("New connection : " + Context.ConnectionId);
            return base.OnConnected();
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stop)
        {
            Debug.WriteLine("Disconnection : " + Context.ConnectionId);
            return base.OnDisconnected(stop);
        }
        public override System.Threading.Tasks.Task OnReconnected()
        {
            Debug.WriteLine("Reconnection : " + Context.ConnectionId);
            return base.OnConnected();
        }

    }

    public class DateTemp
    {
       public  String id { get; set; }
    }
}
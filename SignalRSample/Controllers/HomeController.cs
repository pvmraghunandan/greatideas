using Microsoft.AspNet.SignalR;
using SignalRSample.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //sending messages to clients outside of hubs. For Example from WebAPI when something happened

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.alertMe();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
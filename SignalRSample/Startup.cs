using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Data.SqlClient;

namespace SignalRSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var connectionString = "Endpoint=sb://raghusb-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kyKCR0FtVokW+malQMS3hQEBRzBJxcQ52CcZNqenKec=";
            //var appname = "SignalRScaleOut";
            //GlobalHost.DependencyResolver.UseServiceBus(connectionString, appname);
            var pwd = "EOXO7r92ZQA181hSON7GKXjAx6+roUJ+FMtYhVOF/No=";
            var host = "raghucache.redis.cache.windows.net";
            GlobalHost.DependencyResolver.UseRedis(host, 6379, pwd, "MySignalR");
           


            // Using SQL Server as Backplane

            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = "";
            //builder.UserID = "";
            //builder.Password = "";
            //builder.InitialCatalog = "";

            //GlobalHost.DependencyResolver.UseSqlServer(builder.ToString());

            app.MapSignalR();
        }
    }
}
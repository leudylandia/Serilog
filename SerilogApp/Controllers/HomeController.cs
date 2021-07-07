using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerilogApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/logs/log-{Date}.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341/")
                .CreateLogger();
           
            Environment.SetEnvironmentVariable("USERNAME", "Leudy");
            Log.Information("Hello from Index!");
            Log.Information("Hello from Index {Valor}", TypeLog.Information);
            int a = 10, b = 0;
            Log.Debug("Dividiendo entre {A} by {B}", a, b);
            Log.Error("Somthing went wrong");
            Log.Debug("Getting started");
            Log.Information("Hello {Name} age: {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), 30);
            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });

            Log.Fatal("Fatal Error");
            Log.Warning("Warning Error");
            Log.CloseAndFlush();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void WriteLog()
        {

        }
    }

    public enum TypeLog
    {
        Error,
        Warning,
        Information,
        Debug,
        Fatal
    }
}
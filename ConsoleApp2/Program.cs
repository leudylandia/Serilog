using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/myapp-{DATE}.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
            Environment.SetEnvironmentVariable("USERNAME", "Leudy");
            Log.Information("Hello, world!");
            int a = 10, b = 0;
            Log.Debug("Dividiendo entre {A} by {B}", a, b);
            Log.Error( "Somthing went wrong");
            Log.Debug("Getting started");
            Log.Information("Hello {Name} age: {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), 30);
            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });

            Log.Fatal("Fatal Error");
            Log.Warning("Warning Error");
            //Log.CloseAndFlush();

            Console.ReadLine();
            Console.WriteLine("Hola leudy");
            Console.ReadLine();

            Log.Information("Hello, world!");
            Log.Debug("Dividiendo entre {A} by {B}", a, b);
            Log.Error("Somthing went wrong");
            Log.Debug("Getting started");
            Log.Information("Hello {Name} age: {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), 30);
            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });

            Log.Fatal("Fatal Error");
            Log.Warning("Warning Error");
            Log.CloseAndFlush();
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog.Sinks.Rollbar.TestConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var log = new LoggerConfiguration()
                   .MinimumLevel.Verbose()
                   .WriteTo.RollbarSink("apikey", "dev")
                   .CreateLogger();

      try
      {
        log.Verbose("This is a verbose message!");
        log.Debug("This is a debug message!");
        log.Information("This is an information message!");
        log.Warning("This is a warning message!");
        log.Error("This is an error message!");
        throw new Exception("This is an exception!");
      }
      catch (Exception exception)
      {
        log.Fatal(exception, "Exception caught in Main.");
      }
    }
  }
}

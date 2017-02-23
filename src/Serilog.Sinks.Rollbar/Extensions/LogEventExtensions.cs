using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollbarDotNet;
using Serilog.Events;

namespace Serilog.Sinks.Rollbar.Extensions
{
  public static class LogEventExtensions
  {
    public static ErrorLevel ToErrorLevel(this LogEvent logEvent)
    {
      switch (logEvent.Level)
      {
        case LogEventLevel.Debug:
          return ErrorLevel.Debug;
        case LogEventLevel.Warning:
          return ErrorLevel.Warning;
        case LogEventLevel.Information:
          return ErrorLevel.Info;
        case LogEventLevel.Error:
          return ErrorLevel.Error;
        case LogEventLevel.Fatal:
          return ErrorLevel.Critical;
        case LogEventLevel.Verbose:
          return ErrorLevel.Critical;
      }

      return ErrorLevel.Debug;    //Default
    }
  }
}

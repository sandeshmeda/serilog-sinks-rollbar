using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Configuration;
using Serilog.Sinks.Rollbar.Sinks.Rollbar;

namespace Serilog.Sinks.Rollbar
{
  public static class RollbarSinkExtensions
  {
    public static LoggerConfiguration RollbarSink(this LoggerSinkConfiguration loggerConfiguration,
                  string accessToken,
                  string environment)
    {
      return loggerConfiguration.Sink(new RollbarSink(accessToken, environment));
    }
  }
}

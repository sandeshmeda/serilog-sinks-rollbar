using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RollbarDotNet;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Rollbar.Extensions;

namespace Serilog.Sinks.Rollbar.Sinks.Rollbar
{
  public class RollbarSink : ILogEventSink
  {
    private string _accessToken;
    private string _environment;
    IFormatProvider _formatProvider;

    public RollbarSink(string accessToken, string environment)
    {
      _accessToken = accessToken;
      _environment = environment;

      _ConfigureRollbar();
    }

    private void _ConfigureRollbar()
    {
      RollbarDotNet.Rollbar.Init(new RollbarConfig
      {
        AccessToken = _accessToken,
        Environment = _environment
      });
    }

    public void Emit(LogEvent logEvent)
    {
      var message = (logEvent.RenderMessage(_formatProvider));
      RollbarDotNet.Rollbar.Report(message, logEvent.ToErrorLevel());
    }
  }
}

using System;
using Microsoft.Extensions.Logging;

namespace HackingDisposable.Measurements
{
    public class LogMeasurement
    {
        private readonly ILogger<LogMeasurement> _logger;

        public LogMeasurement(ILogger<LogMeasurement> logger)
        {
            _logger = logger;
        }

        public IDisposable Run() => Measurement.Run(timeSpan => _logger.LogTrace($"Measured time: {timeSpan}"));
    }
}

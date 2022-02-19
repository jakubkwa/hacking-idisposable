using System;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace HackingDisposable.Tests
{
    public class LogMeasurementTests
    {
        [Fact]
        public async Task ShouldLogExecutionTime()
        {
            var testLogger = new TestLogger();
            var subject = new LogMeasurement(testLogger);

            using (subject.Run())
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            testLogger
                .LogBuilder.ToString()
                .Should().StartWith("Measured time: 00:00:01.00");
        }

        private class TestLogger : ILogger<LogMeasurement>
        {
            public readonly StringBuilder LogBuilder = new();

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter) =>
                LogBuilder.AppendLine(state?.ToString());

            public bool IsEnabled(LogLevel logLevel) => throw new NotImplementedException();

            public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
        }
    }
}
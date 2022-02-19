using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace HackingDisposable.Tests
{
    public class MeasurementTests
    {
        [Fact]
        public async Task ShouldMeasureExecutionTime()
        {
            var measuredTime = TimeSpan.Zero;
            var stopwatch = Stopwatch.StartNew();

            using (Measurement.Run(timeSpan => measuredTime = timeSpan))
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            stopwatch.Elapsed.Should().BeCloseTo(measuredTime, TimeSpan.FromMilliseconds(1));
        }
    }
}
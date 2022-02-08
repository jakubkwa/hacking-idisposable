using System;
using System.Diagnostics;

namespace HackingDisposable
{
    public class Measurement
    {
        public static IDisposable Run(Action<TimeSpan> afterMeasuredAction = null) => new Timer(afterMeasuredAction);

        private class Timer : IDisposable
        {
            private readonly Action<TimeSpan> _afterMeasuredAction;
            private readonly Stopwatch _stopwatch;

            public Timer(Action<TimeSpan> afterMeasuredAction)
            {
                _afterMeasuredAction = afterMeasuredAction ?? (_ => { });
                _stopwatch = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                _stopwatch.Stop();
                _afterMeasuredAction.Invoke(_stopwatch.Elapsed);
            }
        }
    }
}
using System;

namespace nothinbutdotnetstore.core
{
    public interface ICanMonitorTime
    {
        void Start();
        void Stop();
        TimeSpan Elapsed { get; }
    }
}
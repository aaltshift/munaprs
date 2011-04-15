using System;

namespace nothinbutdotnetstore.core
{
    public interface ICanStopwatch
    {
        void Start();
        void Stop();
        TimeSpan Elapsed { get; }
    }
}
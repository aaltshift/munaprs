using nothinbutdotnetstore.core;

namespace nothinbutdotnetstore.web.core
{
    public class LogTimingCommand : IEncapsulateApplicationSpecificFunctionality
    {
        IEncapsulateApplicationSpecificFunctionality _innerCommand;
        ICanMonitorTime _stopWatch;
        ILogMessages _logger;

        public LogTimingCommand(
            IEncapsulateApplicationSpecificFunctionality innerCommand,
            ICanMonitorTime stopWatch,
            ILogMessages logger)
        {
            _innerCommand = innerCommand;
            _stopWatch = stopWatch;
            _logger = logger;
        }

        public void process(IContainRequestDetails request)
        {
            _stopWatch.Start();
            _innerCommand.process(request);
            _stopWatch.Stop();
            var milliseconds = _stopWatch.Elapsed.TotalMilliseconds;
            _logger.informational(string.Format("{0} ms", milliseconds));
        }
    }
}
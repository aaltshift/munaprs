using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.core;
using Machine.Fakes;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

using System.Diagnostics;

namespace nothinbutdotnetstore.specs
{
       public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                           LogTimingCommand>
        {
        }

        [Subject(typeof(LogTimingCommand))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                the_request = fake.an<IContainRequestDetails>();
                inner_command = depends.on<IEncapsulateApplicationSpecificFunctionality>();
                logger = depends.on<ILogMessages>();
                stop_watch = depends.on<ICanMonitorTime>();
                stop_watch.setup(x => x.Elapsed).Return(new TimeSpan(0, 0, 0, 0, 1));
            };

            Because of = () => sut.process(the_request);

            It should_invoke_inner_command = 
                () => inner_command.received(x => x.process(the_request));

            It should_start_and_stop_stopwatch = () =>
            {
                stop_watch.received(x => x.Start());
                stop_watch.received(x => x.Stop());
            };

            It should_log_timing_in_milliseconds = () => logger.informational("1 ms");

            static IEncapsulateApplicationSpecificFunctionality inner_command;
            static IContainRequestDetails the_request;
            static ILogMessages logger;
            static ICanMonitorTime stop_watch;
        }
}
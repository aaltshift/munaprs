using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public delegate ReportModel Query<out ReportModel>(IContainRequestDetails request);
}
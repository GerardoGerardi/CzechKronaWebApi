using Quartz;
using Quartz.Spi;

namespace lab3.Jobs;

public class JobFactory : IJobFactory
{
    protected readonly IServiceProvider _provider;

        
    public JobFactory(IServiceProvider provider)
    {
        _provider= provider;
    }

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        return new JobWrapper(_provider, bundle.JobDetail.JobType);

    }

    public void ReturnJob(IJob job)
    {
        (job as IDisposable)?.Dispose();
    }
}
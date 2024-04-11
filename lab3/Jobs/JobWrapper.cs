using Common.Interfaces;
using Quartz;

namespace lab3.Jobs;

public class JobWrapper:IJob,IDisposable
{
    private readonly IServiceScope _serviceScope;
    private readonly IJob _job;
    
    public JobWrapper(IServiceProvider serviceProvider, Type jobType)
    {
        _serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        _job=ActivatorUtilities.CreateInstance(_serviceScope.ServiceProvider,jobType) as IJob;
        
    }

    public Task Execute(IJobExecutionContext context)
        => _job.Execute(context);
    

    public void Dispose()
    {
        _serviceScope.Dispose();
    }
}
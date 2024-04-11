using System.Globalization;
using Quartz;
using Quartz.Impl;

namespace lab3.Jobs;

public static class JobStarter
{
    static async Task SyncSchedulerStarter(IServiceProvider serviceProvider,string timeToStart)
    {
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
        await scheduler.Start();
        var startDate = DateTime.ParseExact(timeToStart, "HH:mm", CultureInfo.InvariantCulture);
        IJobDetail jobDetail = JobBuilder.Create<SyncJob>().Build();
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("DailyTrigger", "default")
            .StartAt(startDate)
            .WithSimpleSchedule(x => x
                .WithIntervalInHours(24)
                .RepeatForever())
            .Build();

        await scheduler.ScheduleJob(jobDetail, trigger);
    }
    
    static async Task StashSchedulerStarter(IServiceProvider serviceProvider)
    {
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
        await scheduler.Start();
        IJobDetail jobDetail = JobBuilder.Create<StashJob>().Build();
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("StashTrigger", "default")
            .StartAt(DateTimeOffset.Now.AddSeconds(120))
            .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(2)
                .RepeatForever())
            .Build();

        await scheduler.ScheduleJob(jobDetail, trigger);
    }
    public static async void Start(IServiceProvider serviceProvider,string timeToStart)
    {
        await SyncSchedulerStarter(serviceProvider, timeToStart);
        await StashSchedulerStarter(serviceProvider);
    }
}
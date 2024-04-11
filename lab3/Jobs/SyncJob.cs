using Common.Interfaces;
using Quartz;

namespace lab3.Jobs;

public class SyncJob:IJob
{
    private ISyncManager _syncManager;

    public SyncJob(ISyncManager syncManager)
    {
        _syncManager = syncManager;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _syncManager.SyncDaily();
    }
}
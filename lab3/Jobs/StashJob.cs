using Common.Interfaces;
using Quartz;

namespace lab3.Jobs;

public class StashJob:IJob
{
    private ISyncManager _syncManager;

    public StashJob(ISyncManager syncManager)
    {
        _syncManager = syncManager;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _syncManager.SyncStash();
    }
}
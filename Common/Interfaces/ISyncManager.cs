using System;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces;

public interface ISyncManager
{
    Task SyncDaily();
    Task SyncStash();
    void AddToStash(DateTime startDate, DateTime endDate, Valutes valute);
    void AddToStash(DateTime startDate, DateTime endDate);
    Task SyncPeriod(DateTime startDate, DateTime endDate,Valutes? val=null);
}
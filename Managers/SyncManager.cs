using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CnbConnector;
using Common;
using Common.Interfaces;
using Common.Models;
using Db;
using Quartz;

namespace Managers;

public class SyncManager:ISyncManager
{
    private IDbManager _dbManager;
    private IApiClient _client;
    private Valutes[] _valutes;
    private IStashManager _stashManager;
    public SyncManager(IDbManager dbManager, IApiClient client,IStashManager stashManager,Valutes[] valutes)
    {
        _dbManager = dbManager;
        _client = client;
        _valutes=valutes;
        _stashManager = stashManager;
    }

    public void AddToStash(DateTime startDate, DateTime endDate, Valutes valute)
        => _stashManager.AddToStash(startDate, endDate, valute);

    public void AddToStash(DateTime startDate, DateTime endDate)
    {
        foreach(var valute in _valutes)
            _stashManager.AddToStash(startDate, endDate, valute);
    }

    public async Task SyncStash()
    {

        if (!_stashManager.IsClearingInProgress)
        {
            _stashManager.IsClearingInProgress = true;
            new FileLogger().Write($"Зачистка стэша начата задач - {_stashManager.Stash.Length}");
            Console.WriteLine("Выполняется очистка stash");
            foreach (var task in _stashManager.Stash)
                await SyncPeriod(task.Item1, task.Item2, task.Item3);
            _stashManager.ClearStash();
            new FileLogger().Write($"Зачистка стэша закончена задач - {_stashManager.Stash.Length}");
        }
    }

    public async Task SyncDaily()
    {
        Console.WriteLine($"Началась ежедневная синхронизация {DateTime.Now}");
        var newData = _client.GetDataDaily(DateTime.Now).Where(_=>_valutes.Any(x=>x==_.Code));
        await _dbManager.AddDailyData(newData);
    }
    
    async Task ProceedOneYear(int year,Valutes val)
    {
        new FileLogger().Write($"Синхронизация {year} {val}");
        if (!await _dbManager.CheckFullYearRecord(year, val))
        {
            new FileLogger().Write($"Синхронизация {year} {val} будет выполнена");
            var yearData = _client.GetDataByYear(year).Select(_ => _.ToDailyRates());
            foreach (var dat in yearData)
            {
                var collection = dat.Value.Where(_ => val == _.Code);
                await _dbManager.AddDailyData(collection);
            }
            await _dbManager.AddFullYearRecord(year, val);
            new FileLogger().Write($"Синхронизация {year} {val} завершена");
        }
        else
        {
            new FileLogger().Write($"Синхронизация {year} {val} не будет выполнена данные есть в бд");
        }
    }


    public async Task SyncPeriod(DateTime startDate,DateTime endDate,Valutes? val=null)//ускорить
    {
        
        for (int i = 0; i <= endDate.Year - startDate.Year; i++)
        {
            if (val == null)
                for(int j=0;j<_valutes.Length;j++)
                    await ProceedOneYear(startDate.Year + i, _valutes[j]);
            else
                await ProceedOneYear(startDate.Year + i, (Valutes)val);
        }

    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Interfaces;
using Common.Models;

namespace Managers;

public class StashManager : IStashManager
{
    private Dictionary<Tuple<DateTime,DateTime,Valutes>,object> _stash;
    private static object _stashLocker = new object();
    private bool _isClearingInProgress;
    private Dictionary<Tuple<DateTime,DateTime,Valutes>,object> _subStash;
    public StashManager()
    {
        _stash = new Dictionary<Tuple<DateTime, DateTime, Valutes>, object>();
        _subStash=new Dictionary<Tuple<DateTime, DateTime, Valutes>, object>();
        _isClearingInProgress = false;
    }
    
    public void AddToStash(DateTime startDate,DateTime endDate,Valutes valute)
    {
        lock (_stashLocker)
        {
            new FileLogger().Write($"Добавление в стэш задачи {startDate.Date}-{endDate.Date} {valute}");
            if (_isClearingInProgress)
                _subStash.TryAdd(Tuple.Create(startDate, endDate, valute), new object());
            else
                _stash.TryAdd(Tuple.Create(startDate, endDate, valute), new object());
        }
    }
    public bool IsClearingInProgress 
    {
        get
        {
            return _isClearingInProgress;
        }
        set
        {
            _isClearingInProgress = value;
        }
    }

    public void ClearStash()
    {
        lock(_stashLocker)
            if (_stash.Count != 0)
            {
                _stash = _subStash;
                _subStash = new Dictionary<Tuple<DateTime, DateTime, Valutes>, object>();
                IsClearingInProgress = false;
            }
    }

    public Tuple<DateTime, DateTime, Valutes>[] Stash => _stash.Keys.ToArray();
}
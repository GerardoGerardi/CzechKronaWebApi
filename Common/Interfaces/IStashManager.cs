using System;
using Common.Models;

namespace Common.Interfaces;

public interface IStashManager
{
    Tuple<DateTime, DateTime, Valutes>[] Stash { get; }

    public void AddToStash(DateTime startDate, DateTime endDate, Valutes valute);

    public void ClearStash();
    bool IsClearingInProgress { get; set; }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces;

public interface IDbManager
{
    Task<bool> AddDailyData(IEnumerable<DailyRate> newData);
    Task<bool> CheckFullPeriod(DateTime startDate, DateTime endDate, Valutes val);
    Task<bool> AddFullYearRecord(int year, Valutes code);
    Task<bool> CheckFullYearRecord(int year, Valutes code);
    Task<Dictionary<Valutes, DailyRate[]>> GetDataForPeriod(DateTime startDate, DateTime endDate, Valutes[] valutes);
}
using System;
using Common.Models;

namespace Common.Interfaces;

public interface IApiClient
{
    RatesForPeriod[] GetDataByYear(int year);
    DailyRate[] GetDataDaily(DateTime date);
}
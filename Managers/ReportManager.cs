using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Db;

namespace Managers;

public class ReportManager : IReportManager
{
    private IDbManager _dbManager;
    private double _periodPercent;
    private Valutes[] _valutes;

    public ReportManager(IDbManager dbManager, Valutes[] valutes)
    {
        _dbManager = dbManager;
        _valutes = valutes;
    }
    
    public async Task<Dictionary<Valutes,ReportElem>> GetReport(DateTime startDate, DateTime endDate)
    {
        var dataForReport = await _dbManager.GetDataForPeriod(startDate, endDate, _valutes);
        var result = new Dictionary<Valutes,ReportElem>();
        foreach (var valute in dataForReport.Keys)

            if (await _dbManager.CheckFullPeriod(startDate, endDate, valute))
                result.Add(valute, new ReportElem()
                {
                    Code = valute,
                    Average = dataForReport[valute].Length == 0 ? -1 : dataForReport[valute].Average(_ => _.Rate),
                    Min = dataForReport[valute].Length == 0 ? -1 : dataForReport[valute].Min(_ => _.Rate),
                    Max = dataForReport[valute].Length == 0 ? -1 : dataForReport[valute].Max(_ => _.Rate)
                });
            else
                result.Add(valute, null);
        return result;
    }

}
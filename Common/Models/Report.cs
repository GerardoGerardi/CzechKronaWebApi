using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Common.Models;

public class Report
{
    public ReportElem[] ValutesReport =>_elems.Values.Where(_ => _ is not null).ToArray();  
    public string Comment
    {
        get
        {
            if (_elems.Values.Any(_ => _ is null))
                return $"Некоторые из валют не имеют достаточной репрезентации {String.Join(',', _elems.Where(_ => _.Value is null).Select(_ => _.Key))}. Мы уже выполняем синхронизацию этих данных, повторите свой запрос через 10-20 минут";
            if (_elems.Values.Any(_ => _.Average == -1))
                return
                    $"Для валют {String.Join(',', _elems.Where(_ => _.Value.Average == -1).Select(_ => _.Key))} нет данных внутри чешского апи на данный период";
            return "Отчет сформирован";
        }
    }

    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    private Dictionary<Valutes, ReportElem> _elems;
    public Report(Dictionary<Valutes,ReportElem> elems,DateTime startDate,DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
        _elems = elems;
    }

    public bool GotNotReadyData => _elems.Values.Any(_ => _ is null);
}

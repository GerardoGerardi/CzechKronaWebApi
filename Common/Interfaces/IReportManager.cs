using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces;

public interface IReportManager
{
    Task<Dictionary<Valutes, ReportElem>> GetReport(DateTime startDate, DateTime endDate);
}
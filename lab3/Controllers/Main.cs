using System.Globalization;
using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers;

[ApiController]
public class Main : Controller
{
    private ISyncManager _syncManager;
    private IReportManager _reportManager;

    public Main(ISyncManager syncManager, IReportManager reportManager)
    {
        _reportManager = reportManager;
        _syncManager = syncManager;
    }
    
    [HttpGet]
    [Route("SyncForPeriod")]
    public async Task<IActionResult> SyncForPeriod(string startDate, string endDate)
    {
        try
        {
            var start=DateTime.ParseExact(startDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var end=DateTime.ParseExact(endDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //await _syncManager.SyncPeriod( start, end);
            _syncManager.AddToStash(start,end);
            return StatusCode(StatusCodes.Status200OK, "синхронизация выполнена");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
    }

    [HttpGet]
    [Route("GetReport")]
    public async Task<IActionResult> GetReport(string startDate, string endDate)
    {
        try
        {
            var start=DateTime.ParseExact(startDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var end=DateTime.ParseExact(endDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var result = await _reportManager.GetReport(start, end);
            foreach(var res in result.Where(_=>_.Value is null))
                _syncManager.AddToStash(start,end,res.Key);
            var report = new Report(result, start, end);
            return StatusCode(StatusCodes.Status200OK,report);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status102Processing);
        }
            

        
    }
}
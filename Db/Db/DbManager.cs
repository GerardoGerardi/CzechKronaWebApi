using Common;
using Common.Interfaces;
using Common.Models;
using Db;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class DbManager:IDbManager
{
    private DataContext _context;

    public DbManager(DataContext context)
    {
        _context = context; 
    }

    public async Task<bool> AddDailyData(IEnumerable<DailyRate> newData) 
    {
        try
        {
            await _context.DaylyRates.AddRangeAsync(newData);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            new FileLogger().Write(ex.Message);
            if(ex.InnerException!= null)
                new FileLogger().Write(ex.InnerException.Message);
            return false;
        }
    }
    
    public async Task<bool> AddFullYearRecord(int year, Valutes code)
    {
        var record=new YearValuteFullData()
        {
            Year = year,
            Code = code
        };
        _context.YearValuteFullData.Add(record);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckFullYearRecord(int year, Valutes code)
    {
        return await _context.YearValuteFullData.AnyAsync(_ => _.Code == code && _.Year == year);
    }
    
    public async Task<bool> CheckFullPeriod(DateTime startDate, DateTime endDate, Valutes val)
    {
        for (int i = 0; i <= endDate.Year - startDate.Year; i++)
            if (!await CheckFullYearRecord(startDate.Year + i, val))
                return false;
        return true;
    }
    

    public async Task<Dictionary<Valutes, DailyRate[]>> GetDataForPeriod(DateTime startDate, DateTime endDate,Valutes[] valutes)
    {
        var result = new Dictionary<Valutes, DailyRate[]>();
        foreach(var valute in valutes)
            result.Add( 
                valute,
                await _context.DaylyRates.Where(_ =>
                    _.Date >= DateTime.SpecifyKind(startDate, DateTimeKind.Utc) && _.Date <= DateTime.SpecifyKind(endDate, DateTimeKind.Utc) && valute==_.Code)
                .ToArrayAsync());
        return result;
    }

}
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Db;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts)
    {
    }

    public DbSet<DailyRate> DaylyRates => Set<DailyRate>();
    public DbSet<YearValuteFullData> YearValuteFullData => Set<YearValuteFullData>();

    protected override void OnConfiguring(DbContextOptionsBuilder optsNuilder)
        => optsNuilder.UseNpgsql(x => x.MigrationsHistoryTable("Migrations", "Lab3Scheme"));
}


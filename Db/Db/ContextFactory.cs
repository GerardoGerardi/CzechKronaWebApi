using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Db;

public class ContextFactory: IDesignTimeDbContextFactory<DataContext>
{
    // dotnet ef migrations add Initial --  --Args 'connextionString'
    // dotnet ef database update -- "connectionString"
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql(args[0]);
        return new DataContext(optionsBuilder.Options);
    }
}
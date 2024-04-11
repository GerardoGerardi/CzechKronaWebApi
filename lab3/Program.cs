using CnbConnector;
using Common.Interfaces;
using Common.Models;
using Db;
using lab3.Jobs;
using Managers;
using Microsoft.EntityFrameworkCore;


namespace lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContextFactory<DataContext>(opts=>opts.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));
            builder.Services.AddSingleton<IStashManager, StashManager>();
            builder.Services.AddScoped<IDbManager, DbManager>();
            builder.Services.AddTransient<IApiClient, CnbClient>();
            builder.Services.AddScoped<ISyncManager, SyncManager>(opts =>
                new SyncManager(
                    opts.GetRequiredService<IDbManager>(),
                    opts.GetRequiredService<IApiClient>(),
                    opts.GetRequiredService<IStashManager>(),
                    builder.Configuration.GetSection("Settings").GetSection("Valutes").Get<string[]>().ToValutes()
                    ));
            builder.Services.AddTransient<IReportManager, ReportManager>(opts=>
                new ReportManager(
                    opts.GetRequiredService<IDbManager>(),
                    builder.Configuration.GetSection("Settings").GetSection("Valutes").Get<string[]>().ToValutes())
            );
           
            builder.Services.AddTransient<JobFactory>();
            //builder.Services.AddScoped<SyncJob>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            JobStarter.Start(
                app.Services.CreateScope().ServiceProvider,
                builder.Configuration.GetSection("Settings").GetValue<string>("SyncTime")
                );
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
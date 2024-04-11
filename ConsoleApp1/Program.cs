using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using CnbConnector;
using Common;

using Common.Models;
using Db;
using Managers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new CnbClient();
           /* foreach (var em in client.GetDataByYear(2022))
                em.Print();*/
            
            /*var time = DateTime.ParseExact("00:01", "hh:mm", CultureInfo.InvariantCulture);
            Console.WriteLine($"{time.Hour}:{time.Minute}");*/
            var startDate = DateTime.ParseExact("01.01.1991", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("08.04.2024", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var valutes = new Valutes[]
            {
                Valutes.SEK,
                Valutes.CHF,
                Valutes.THB,
                Valutes.TRY,
                Valutes.GBP,
                Valutes.USD,
            };
            var context = new ContextFactory().CreateDbContext(new string[]{ "Host=127.0.0.1;Port=5433;Database=Lab3;Username=root;Password=secret;timezone=Europe/Moscow;" });
            var syncManager = new SyncManager(new DbManager(context), client);
            var task=syncManager.SyncPeriod(valutes,startDate,endDate);
            task.Wait();
            /*var reportManager = new ReportManager(new DbManager(context), 0.5);
            var result = reportManager.GetReport(valutes,startDate,endDate).Result;
            foreach(var res in result)
                if(res.Value!=null)
                    Console.WriteLine($"Валюта - {res.Value.Code} Среднее - {res.Value.Average} Минимальное - {res.Value.Min} Максимальное - {res.Value.Max}");
*/


        }
    }
}
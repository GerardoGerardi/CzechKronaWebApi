using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace CnbConnector
{
    public static class Extensions
    {
        internal static RatesForPeriod[] ToRatesForYear(this string source)
        {
            var tables = source.Split("Date", StringSplitOptions.RemoveEmptyEntries);
            var result = new RatesForPeriod[source.Count(_ => _=='\n')-tables.Length];
            int delta = 0;
            for (int j = 0; j < tables.Length; j++)
            {
                var rows = tables[j].Split('\n', StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                var valutes = rows[0].Split('|').Skip(1).ToArray();
                rows = rows.Skip(1).ToArray();
                for (int i = 0; i < rows.Length; i++)
                    result[i+delta] = new RatesForPeriod()
                    {
                        date = DateTime.Parse(rows[i].Split('|')[0]),
                        Rates = rows[i].ToRate(valutes)
                    };
                delta += rows.Length;

            }
            return result;
        }

        internal static Dictionary<Valutes,decimal> ToRate(this string source, string[] valutes)
        {
            var result = new Dictionary<Valutes, decimal>();
            var rateArr = source.Split('|').Skip(1).ToArray();
            for (int i = 0; i < valutes.Length; i++)
            {
                decimal amount = int.Parse(valutes[i].Split()[0]);
                decimal value = decimal.Parse(rateArr[i], CultureInfo.GetCultureInfo("en-US"));
                if (amount > 1)
                    value = value / amount;
                result.Add(valutes[i].Split()[1].ToValute(), value);
            }
            return result;
        }

        public static Valutes ToValute(this string source) =>
            (Valutes)Enum.Parse(typeof(Valutes), source);



        internal static DailyRate[] ToDailyRates(this string source)
        => source.Split('\n', StringSplitOptions.RemoveEmptyEntries).Skip(2).Select(_ => _.ToDailyRate()).ToArray();
        
        internal static DailyRate ToDailyRate(this string source)
        {
            var fields = source.Split('|');
            var result = new DailyRate();

            result.Country = fields[0];
            result.Currency = fields[1];
            result.Code = fields[3].ToValute();
            result.Rate = int.Parse(fields[2]) > 1 ? decimal.Parse(fields[4], CultureInfo.GetCultureInfo("en-US")) / decimal.Parse(fields[2]) : decimal.Parse(fields[4], CultureInfo.GetCultureInfo("en-US"));
            result.Date=DateTime.Now.Date;
            return result;
            
        }
    }
}

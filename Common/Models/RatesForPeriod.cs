using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class RatesForPeriod
    {
        public DateTime date { get; set; }
        public Dictionary<Valutes, decimal> Rates { get; set; }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine($"{date.Day}.{date.Month}.{date.Year}");
            foreach (var item in Rates)
                Console.WriteLine($"{item.Key} {item.Value}");
        }

        public KeyValuePair<DateTime,DailyRate[]> ToDailyRates()
        {
            return new KeyValuePair<DateTime,DailyRate[]>(date, Rates.Select(_ => new DailyRate()
            {
                Code = _.Key,
                Currency = CurrenciesAndCountries.CurrencyByVal[_.Key],
                Country=CurrenciesAndCountries.CountryByVal[_.Key],
                Date = date,
                Rate = _.Value
            }).ToArray());
        }
    }
}

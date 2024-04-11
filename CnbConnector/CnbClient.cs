using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;


namespace CnbConnector
{
    public class CnbClient:IApiClient
    {

        string _baseAddress;
        public CnbClient()
        {
            _baseAddress = "https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/";
        }
        
        public CnbClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }
        string Get(string url)
        {
            string content;
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                var result = client.GetAsync(url).Result;
                if (result.IsSuccessStatusCode)
                    content= result.Content.ReadAsStringAsync().Result;
                else
                    throw new Exception(result.StatusCode.ToString());
            }
            return content;
        }

        public RatesForPeriod[] GetDataByYear(int year)
        {
            string url = $"year.txt?year={year}";
            var result=Get(url).ToRatesForYear();
            return result;
        }
        public DailyRate[] GetDataDaily(DateTime date)
        {
            string url = $"daily.txt?date={date.ToString("dd.MM.yyyy")}";
            return Get(url).ToDailyRates();
        }
    }
}

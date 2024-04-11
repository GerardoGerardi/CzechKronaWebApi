namespace Common.Models;

public class ReportElem
{
    public Valutes Code { get; set; }
    public string ValuteName
    {
        get => $"{CurrenciesAndCountries.CurrencyByVal[Code]} {Code}";
    }

    public string Country
    {
        get => CurrenciesAndCountries.CountryByVal[Code];
    }
    
    public decimal? Min { get; set; }
    public decimal? Max { get; set; }
    public decimal? Average { get; set; }
}


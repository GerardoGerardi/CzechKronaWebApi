﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public enum Valutes
    {
        AUD,
        BGN,
        BRL,
        CAD,
        CHF,
        CNY,
        DKK,
        EUR,
        GBP,
        HKD,
        HRK,
        HUF,
        IDR,
        ILS,
        INR,
        ISK,
        JPY,
        KRW,
        MXN,
        MYR,
        NOK,
        NZD,
        PHP,
        PLN,
        RON,
        RUB,
        SEK,
        SGD,
        THB,
        TRY,
        USD,
        XDR,
        ZAR,
        LTL,
        ATS,
        BEF,
        DEM,
        ESP,
        FIM,
        FRF,
        GRD,
        IEP,
        ITL,
        LUF,
        NLG,
        PTE,
        SKK,
        XEU,
        SIT,
        CYP,
        EEK,
        LVL,
        MTL,
        ROL,
        TRL,
        BEC,
        YUD,
        XCU
    };

    public static class CurrenciesAndCountries
    {
        public static Dictionary<Valutes, string> CountryByVal = new Dictionary<Valutes, string>
        {
            { Valutes.ATS, "Australia"},
            {Valutes.AUD,"Australia"},
            {Valutes.BRL,"Brazil"},
            {Valutes.BGN,"Bulgaria"},
            {Valutes.CAD,"Canada"},
            {Valutes.CNY,"China"},
            {Valutes.HRK,"Croatia"},
            {Valutes.DKK,"Denmark"},
            {Valutes.EUR,"EMU"},
            {Valutes.HKD,"Hongkong"},
            {Valutes.HUF,"Hungary"},
            {Valutes.ISK,"Iceland"},
            {Valutes.XDR,"IMF"},
            {Valutes.INR,"India"},
            {Valutes.IDR,"Indonesia"},
            {Valutes.ILS,"Israel"},
            {Valutes.JPY,"Japan"},
            {Valutes.MYR,"Malaysia"},
            {Valutes.MXN,"Mexico"},
            {Valutes.NZD,"New Zealand"},
            {Valutes.NOK,"Norway"},
            {Valutes.PHP,"Philippines"},
            {Valutes.PLN,"Poland"},
            {Valutes.RON,"Romania"},
            {Valutes.RUB,"Russia"},
            {Valutes.SGD,"Singapore"},
            {Valutes.ZAR,"South Africa"},
            {Valutes.KRW,"South Korea"},
            {Valutes.SEK,"Sweden"},
            {Valutes.CHF,"Switzerland"},
            {Valutes.THB,"Thailand"},
            {Valutes.TRY,"Turkey"},
            {Valutes.GBP,"United Kingdom"},
            {Valutes.USD,"USA"},
            {Valutes.LTL,"Lithuania"},
            {Valutes.BEF,"Belgium"},
            {Valutes.DEM,"Germany"},
            {Valutes.ESP,"Spain"},
            {Valutes.FIM,"Finland"},
            {Valutes.FRF,"France"},
            {Valutes.GRD,"Greece"},
            {Valutes.IEP,"Ireland"},
            {Valutes.ITL,"Italy"},
            {Valutes.LUF,"Luxembourg"},
            {Valutes.NLG,"Netherlands"},
            {Valutes.PTE,"Portugal"},
            {Valutes.SKK,"Slovakia"},
            {Valutes.XEU,"EMS"},
            {Valutes.SIT,"Slovenia"},
            {Valutes.CYP,"Cyprus"},
            {Valutes.EEK,"Estonia"},
            {Valutes.LVL,"Latvia"},
            {Valutes.MTL,"Malta"},
            {Valutes.ROL,"Romania"},
            {Valutes.TRL,"Turkey"},
            {Valutes.BEC,"Belgium"},
            {Valutes.YUD,"SFRJ"},
            {Valutes.XCU,"Slovakia"}
        };

        public static Dictionary<Valutes, string> CurrencyByVal = new Dictionary<Valutes, string>()
        {
            {Valutes.AUD,"dollar"},
            {Valutes.BRL,"real"},
            {Valutes.BGN,"lev"},
            {Valutes.CAD,"dollar"},
            {Valutes.CNY,"renminbi"},
            {Valutes.HRK,"kuna"},
            {Valutes.DKK,"krone"},
            {Valutes.EUR,"euro"},
            {Valutes.HKD,"dollar"},
            {Valutes.HUF,"forint"},
            {Valutes.ISK,"krona"},
            {Valutes.XDR,"SDR"},
            {Valutes.INR,"rupee"},
            {Valutes.IDR,"rupiah"},
            {Valutes.ILS,"new shekel"},
            {Valutes.JPY,"yen"},
            {Valutes.MYR,"ringgit"},
            {Valutes.MXN,"peso"},
            {Valutes.NZD,"dollar"},
            {Valutes.NOK,"krone"},
            {Valutes.PHP,"peso"},
            {Valutes.PLN,"zloty"},
            {Valutes.RON,"leu"},
            {Valutes.RUB,"rouble"},
            {Valutes.SGD,"dollar"},
            {Valutes.ZAR,"rand"},
            {Valutes.KRW,"won"},
            {Valutes.SEK,"krona"},
            {Valutes.CHF,"franc"},
            {Valutes.THB,"baht"},
            {Valutes.TRY,"lira"},
            {Valutes.GBP,"pound"},
            {Valutes.USD,"dollar"},
            {Valutes.LTL,"litas" },
            {Valutes.ATS, "schilling"},
            {Valutes.BEF, "frac"},
            {Valutes.DEM,"mark"},
            {Valutes.ESP,"peseta"},
            {Valutes.FIM,"mark"},
            {Valutes.FRF,"franc"},
            {Valutes.GRD,"drachma"},
            {Valutes.IEP,"pound"},
            {Valutes.ITL,"lira"},
            {Valutes.LUF,"franc"},
            {Valutes.NLG,"guilder"},
            {Valutes.PTE,"escudo"},
            {Valutes.SKK,"koruna"},
            {Valutes.XEU,"ECU"},
            {Valutes.SIT,"tolar"},
            {Valutes.CYP,"pound"},
            {Valutes.EEK,"kroon"},
            {Valutes.LVL,"lats"},
            {Valutes.MTL,"lira"},
            {Valutes.ROL,"leu"},
            {Valutes.TRL,"lira"},
            {Valutes.BEC,"franc"},
            {Valutes.YUD,"dinar"},
            {Valutes.XCU,"cl. ECU"},
        };
    }
}

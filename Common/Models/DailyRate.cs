using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Common.Models
{
    [Table("DailyRates",Schema = "Lab3Scheme"),Index(nameof(Date),nameof(Code))]
    public class DailyRate
    {
        private DateTime _date;
        [Key, Column("id"), NotNull]
        public long? Id { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public Valutes Code { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date
        {
            get => _date ;
            set => _date =DateTime.SpecifyKind(value, DateTimeKind.Utc) ;
        }


        public void PrintCountry()
        {
            Console.WriteLine("{Valutes."+Code+","+'"'+Country+'"'+"},");
        }
        
        public void PrintCurrency()
        {
            Console.WriteLine("{Valutes."+Code+","+'"'+Currency+'"'+"},");
        }
    }
}

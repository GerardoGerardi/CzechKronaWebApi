using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Common.Models;
[Table("YearValuteFullData",Schema = "Lab3Scheme"),Index(nameof(Year),nameof(Code))]
public class YearValuteFullData
{
    [Key, Column("Id"), NotNull]
    public long? Id { get; set; }
    public Valutes Code { get; set; }
    public int Year { get; set; }
}
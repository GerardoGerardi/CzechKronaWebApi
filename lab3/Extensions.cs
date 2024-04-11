using Common.Models;

namespace lab3;

public static class Extensions
{
    public static Valutes[] ToValutes(this string[] source)
    {
        var result = new Valutes[source.Length];
        for (int i = 0; i < source.Length; i++)
            if (Valutes.TryParse(source[i], out Valutes a))
                result[i] = a;
            else
            {
                Console.WriteLine($"Код валюты {source[i]} не был распознан и не будет учитываться ни в отчетах ни в синхронизациях");
            }
        return result;
    }
}
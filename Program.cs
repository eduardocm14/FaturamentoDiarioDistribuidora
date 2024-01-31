using System;
using System.Collections.Generic;
using System.Globalization;

namespace FaturamentoDiarioDistribuidora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randNum = new();
            var listaResultado = new List<double>();

            DateTime dataInicial = DateTime.Now;
            DateTime dataFinal = new(2024, 12, 31);

            var diasAno = dataFinal.DayOfYear;

            var diaMesAno = dataInicial;

            for (int i = 0; i < dataFinal.Subtract(dataInicial).Days; i++)
            {
                var numeroAleatorio = randNum.Next(100, 20000);
                listaResultado.Add(numeroAleatorio);

                if (diaMesAno.DayOfWeek != DayOfWeek.Saturday && diaMesAno.DayOfWeek != DayOfWeek.Sunday)
                {
                    //Console.WriteLine(diaMesAno.DayOfWeek + " - " + DayOfWeek.Saturday);
                    Console.WriteLine(diaMesAno.ToString("dd/MM/yyyy") + "(" + diaMesAno.DayOfWeek + ") - " + numeroAleatorio.ToString("F"));
                }

                diaMesAno = diaMesAno.AddDays(1);

                //dataInicial.AddDays(1);

                //Console.WriteLine($"Hoje é {dataFinal}");

                //CultureInfo pt = new CultureInfo("pt-PT", false);
                //string dateFormatString = pt.DateTimeFormat.LongDatePattern;
                //string data = DateTime.Now.ToString(dateFormatString, new CultureInfo("pt-PT"));
                //Console.WriteLine(data);

                //Console.WriteLine("Difference in days: " + dataFinal.Subtract(dataInicial).Days);

                //Console.WriteLine("{0:d}: day {1} of {2} {3}", dec31,
                //                  dec31.DayOfYear,
                //                  dec31.Year,
                //                  DateTime.IsLeapYear(dec31.Year) ? "(Leap Year)" : "");
            }

            //Console.WriteLine($"Quantidade de dias:{diasAno} do ano: {dataFinal.Year} ");
        }
    }
}

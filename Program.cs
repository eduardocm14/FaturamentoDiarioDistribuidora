using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FaturamentoDiarioDistribuidora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randNum = new();
            //var listaResultado = new List<double>();

            DateTime dataInicial = DateTime.Now;
            DateTime dataFinal = new(2024, 12, 31);

            var diasAno = dataFinal.DayOfYear;
            var diaMesAno = dataInicial;
            var quantidadeDiasUteis = 0;
            //FaturamentoDiario[] vetorFaturamentoDiario = new FaturamentoDiario[dataFinal.Subtract(dataInicial).Days];
            List<FaturamentoDiario> listagem =  new();
            List<double> listaAleatorios = new();

            Console.WriteLine("*******************Inicío Faturamento Anual*******************");

            for (int i = 0; i < dataFinal.Subtract(dataInicial).Days; i++)
            {
                FaturamentoDiario faturamentoDiario = new();
                var numeroAleatorio = randNum.Next(100, 50000);
                listaAleatorios.Add(numeroAleatorio);

                if (diaMesAno.DayOfWeek != DayOfWeek.Saturday && diaMesAno.DayOfWeek != DayOfWeek.Sunday)
                {
                    faturamentoDiario.data = diaMesAno;
                    faturamentoDiario.valor = numeroAleatorio;

                    listagem.Add(faturamentoDiario);

                    Console.WriteLine($"Data: {faturamentoDiario.data:dd/MM/yyyy} " +
                                      $"Dia da Semana: {diaMesAno.DayOfWeek} " +
                                      $"Valor: {faturamentoDiario.valor:n2}");

                    quantidadeDiasUteis ++;
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

            Console.WriteLine("*******************Fim Faturamento Anual*******************");

            double valorMediaAnual = 0;
            double maiorValor = 0;
            double menorValor = 0;
            DateTime dataMenorValor = DateTime.Now;
            DateTime dataMaiorValor = DateTime.Now;

            //foreach (var item in listaAleatorios)
            //{
            //    Console.WriteLine($"Números Aleatorios: {item}");
            //}

            var contDiasFatDiarioMaiorMediaAnual = 0;

            foreach (var item in listagem)
            {
                if (item != null)
                {
                    valorMediaAnual += item.valor;

                    if (menorValor == 0)
                        menorValor = item.valor;

                    if (maiorValor == 0)
                        maiorValor = item.valor;

                    if (menorValor > item.valor)
                    {
                        menorValor = item.valor;
                        dataMenorValor = item.data;
                    }

                    if (maiorValor < item.valor)
                    {
                        maiorValor = item.valor;
                        dataMaiorValor = item.data;
                    }

                    if (item.valor > valorMediaAnual / quantidadeDiasUteis)
                    {
                        contDiasFatDiarioMaiorMediaAnual ++;
                    }
                }
            }
               
            Console.WriteLine($"Faturamento Anual: {valorMediaAnual:n2}");
            Console.WriteLine($"Faturamento Média Anual: {valorMediaAnual / quantidadeDiasUteis:n2}");
            Console.WriteLine($"Faturamento >> Maior Valor: {maiorValor:n2} - dia: {dataMaiorValor}");
            Console.WriteLine($"Faturamento >> Menor Valor: {menorValor:n2} - dia: {dataMenorValor}");
            Console.WriteLine($"Número de dias no ano em que o valor de faturamento diário foi superior à média anual: {contDiasFatDiarioMaiorMediaAnual}");
            Console.WriteLine($"Quantidade de dias:{diasAno} / dias uteis:{quantidadeDiasUteis} do ano: {dataFinal.Year} ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaisOperadoresLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Mes> allMonths = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            // 1) Pegar o primeiro trimnestre
            var threeFirstMonthsQuery = allMonths.Take(3); //Obter elementos
            CreateSpaces("3 PRIMEIROS MESES");
            foreach (var months in threeFirstMonthsQuery)
            {
                Console.WriteLine(months.NomeMes);
            }

            //2) Pegar os meses depois do primeiro trimestre
            var monthsAfterThreeFirstMonths = allMonths.Skip(3); //Ignora uma quantidade de elementos em uma lista
            CreateSpaces("MESES APÓS O PRIMEIRO TRIMESTRE");
            foreach (var months in monthsAfterThreeFirstMonths)
            {
                Console.WriteLine(months.NomeMes);
            }

            // 3) Pegar os meses do terceiro trimestre - Julho, Agosto, Setembro
            var threeMonthsOfThirdQuarter = allMonths.Skip(6).Take(3);
            CreateSpaces("MESES DO TERCEIRO TRIMESTRE");
            foreach (var months in threeMonthsOfThirdQuarter)
            {
                Console.WriteLine(months.NomeMes);
            }

            // 4) Pegar os meses até que o mês comece com a letra 'S'
            //var queryResult = allMonths.Where(x => !x.NomeMes.StartsWith('S')).SkipLast(3); //Má consulta, pois nem sempre saberei quantos elementos preciso 'skippar' ao final
            var queryResult = allMonths.TakeWhile(x => !x.NomeMes.StartsWith('S')); //Consulta mais correta
            CreateSpaces("OBTENDO MESES ATÉ QUE UM MÊS COMECE COM A LETRA 'S'");
            foreach (var months in queryResult)
            {
                Console.WriteLine(months.NomeMes);
            }

            // 5) Pular os meses até que o mês comece com a letra 'S'
            var queryResult2 = allMonths.SkipWhile(x => !x.NomeMes.StartsWith('S'));
            CreateSpaces("PULANDO MESES ATÉ QUE UM MÊS COMECE COM A LETRA 'S'");
            foreach (var months in queryResult2)
            {
                Console.WriteLine(months.NomeMes);
            }
        }

        /// <summary>
        /// Cria espaços para o formato dos resultados no console
        /// </summary>
        /// <param name="description"></param>
        public static void CreateSpaces(string description)
        {
            Console.WriteLine();
            Console.WriteLine($"{description}: ");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}

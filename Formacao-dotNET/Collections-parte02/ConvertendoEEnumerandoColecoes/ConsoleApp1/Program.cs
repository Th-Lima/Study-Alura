using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var meses = new string[]
            {
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro",
            };

            foreach(var mes in meses)
            {
                meses[0] = meses[0].ToUpper();
                Console.WriteLine(mes);
            }
        }
    }
}

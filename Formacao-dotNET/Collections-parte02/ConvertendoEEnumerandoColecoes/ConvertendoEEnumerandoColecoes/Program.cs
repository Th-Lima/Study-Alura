using System;
using System.Collections.Generic;

namespace ConvertendoEEnumerandoColecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String para object");
            string teste = "agajhdsga";
            object obj = teste;

            Console.WriteLine(obj);

            Console.WriteLine("List<string> para List<object>");
            List<string> listaMeses = new List<string>()
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

            //IList<object> listaObj = listaMeses;
            Console.WriteLine();

            Console.WriteLine("string[] para string[object]");
            string[] meses = new string[]
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

            object[] arrayObj = meses; //COVARIÂNCIA
            foreach (var item in arrayObj)
            {
                Console.WriteLine(item);
            }

            arrayObj[0] = "Primeiro mês";
            Console.WriteLine(arrayObj[0]);
            Console.WriteLine();

            //arrayObj[0] = 12345;
            //Console.WriteLine(arrayObj[0]);

            Console.WriteLine("List<string> para IEnumerable<object>");
            IEnumerable<object> enumObj = listaMeses; //COVARIÂNCIA

            foreach (var item in enumObj)
            {
                Console.WriteLine(item);
            }

            //enumObj[0] = 123456;
        }
    }
}

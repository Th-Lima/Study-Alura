using System;
using System.Collections.Generic;

namespace CSharpCollections.ListaLigada
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frutas = new List<string>
            {
                "Abacate",
                "Banana",
                "Caqui",
                "Morango"
            };

            foreach (var fruta in frutas)
            {
                Console.WriteLine(fruta);
            }

            //Instanciando uma lista ligada
            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("Quarta-feira");
            Console.WriteLine("d4.Value: " + d4.Value);
            var d2 = dias.AddBefore(d4, "Segunda-feira");
            var d3 = dias.AddAfter(d2, "Terça-feira");
            var d6 = dias.AddAfter(d4, "Sexta-feira");
            var d7 = dias.AddAfter(d6, "Sabádo");
            var d5 = dias.AddBefore(d6, "Quinta-feira");
            var d1 = dias.AddBefore(d2, "Domingo");

            //LINKEDLIST não da suporte ao acesso de índice: dias[0]
            //Por isso podemos fazer um laço foreach e não um for
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            //var quarta = dias.Find("Quarta-feira");

            //Console.WriteLine(quarta.Value);

            //Para remover um elemento, podemos tanto
            //remover pelo valor quanto pela
            //referência do LinkedListNode
            //dias.Remove("quarta") ou dias.Remove(d4)
            dias.Remove("Quarta-feira");
            //dias.Remove(d4);

            Console.WriteLine("---------------------------");
            Console.WriteLine("DIAS SEM QUARTA FEIRA: ");
            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

        }
    }
}

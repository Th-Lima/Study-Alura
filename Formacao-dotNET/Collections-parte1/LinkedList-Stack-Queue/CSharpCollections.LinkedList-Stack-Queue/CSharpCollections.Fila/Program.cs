using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Fila
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("FIFO (First-in Firt-Out)");
            Enfileirar("van");
            Enfileirar("Kombi");
            Enfileirar("Guincho");
            Enfileirar("PickUp");
            Desenfileirar();
        }

        private static void Desenfileirar()
        {
            var veiculoNaFila = pedagio.Peek();

            if (pedagio.Any())
            {
                Console.WriteLine($"{veiculoNaFila} está fazendo o pagamento");

                var veiculo = pedagio.Dequeue();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Saiu da fila : " + veiculo);
                ImprimirFila();
            }
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine();
            Console.WriteLine($"Entrou na fila : {veiculo}");

            pedagio.Enqueue(veiculo);
            ImprimirFila();
        }

        private static void ImprimirFila()
        {
            Console.WriteLine("FILA: ");

            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }
        }
    }
}

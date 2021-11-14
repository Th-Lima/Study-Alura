using ByteBank.Modelos;
using System;

namespace ByteBank.SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaCorrente = new ContaCorrente(2135,156464);
            Console.WriteLine(contaCorrente.Saldo);

            string nome = "Thales";
            contaCorrente.Sacar(20);
        }
    }
}

using System;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente c1 = new ContaCorrente();
            c1.titular = "Thales";
            c1.agencia = 362;
            c1.numero = 362456;
            c1.saldo = 100.0;

            Console.WriteLine(c1.titular);
            Console.WriteLine("Agência: " + c1.agencia);
            Console.WriteLine("Número: " + c1.numero);
            Console.WriteLine("Saldo: " + c1.saldo);
        }
    }
}

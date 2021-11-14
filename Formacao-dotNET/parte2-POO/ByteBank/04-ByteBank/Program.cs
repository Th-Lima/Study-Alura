using System;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente c1 = new ContaCorrente();
            
            c1.Sacar(50.00);
            c1.Depositar(100.00);

            ContaCorrente c2 = new ContaCorrente();
            c1.Tranferir(100.00, c2);
            c2.Tranferir(50.00, c1);

            Console.WriteLine("Saldo conta 1: " + c1.saldo);
            Console.WriteLine("Saldo conta 2: " + c2.saldo);
        }
    }
}

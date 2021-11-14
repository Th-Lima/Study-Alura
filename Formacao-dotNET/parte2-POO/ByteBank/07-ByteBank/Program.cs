using System;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(867, 1225856);

            ContaCorrente conta2 = new ContaCorrente(867, 1235468);

            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);
            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);
        }
    }
}

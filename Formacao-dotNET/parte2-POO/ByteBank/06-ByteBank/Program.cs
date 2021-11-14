using System;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente c1 = new ContaCorrente();
            Cliente cliente = new Cliente();

            cliente.Nome = "Thales";
            cliente.CPF = "1645.005.367-01";
            cliente.Profissao = "Desenvolvedor";

            c1.Saldo = -10;
            c1.Titular = cliente;

            Console.WriteLine(c1.Titular.Nome);
            Console.WriteLine(c1.Saldo);
        }
    }
}

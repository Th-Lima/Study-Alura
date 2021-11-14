using System;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente Thales = new Cliente();
            //Thales.Nome = "Thales Lima";
            //Thales.Profissao = "Software Developer";
            //Thales.CPF = "164.005.367-01";

            ContaCorrente c1 = new ContaCorrente();
            //c1.Titular = Thales;
           // c1.Titular = new Cliente();
            //c1.Titular.Nome = "Thales Lima Ricardo";
            //c1.Titular.CPF = "164.005.367-01";
            //c1.Titular.Profissao = "Software Developer";
            
            c1.Saldo = 5000.00;
            c1.Numero = 123456789;
            c1.Agencia = 12345789;

            if(c1.Titular == null)
            {
                Console.WriteLine("Referência Nula");
            }


            Console.WriteLine(c1.Titular.Nome);
            Console.WriteLine(c1.Titular.Profissao);
            Console.WriteLine(c1.Titular.CPF);
        }
    }
}

using ByteBank.Modelos;
using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsandoStreamReader(string[] args)
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fs = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fs))
            {
                while (!leitor.EndOfStream)
                {
                    var readLine = leitor.ReadLine();

                    var contaCorrente = ConverterStringParaContaCorrente(readLine);

                    var msg = $"Conta Corrente \n " +
                        $"Titular: {contaCorrente.Titular.Nome} | " +
                        $"Número: {contaCorrente.Numero} | " +
                        $"Agência: {contaCorrente.Agencia} | " +
                        $"Saldo: {contaCorrente.Saldo.ToString("C")} \n";

                    Console.WriteLine(msg);

                }
            }

            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace(".", ",");
            var nometitular = campos[3];

            var numeroInt = int.Parse(agencia);
            var agenciaInt = int.Parse(numero);
            double saldoDouble = double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nometitular;

            var resultado = new ContaCorrente(agenciaInt, numeroInt);

            resultado.Depositar(saldoDouble);
            resultado.Titular = titular;

            return resultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using(var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(14565); //Número da agência
                escritor.Write(777777); //Número da conta
                escritor.Write(4000.50); //Saldo da conta
                escritor.Write("Gustavo Braga"); //Titular

            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numero = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var nomeTitular = leitor.ReadString();

                Console.WriteLine($"Agencia {agencia} | Número {numero} | Saldo {saldo.ToString("C")} | Titular {nomeTitular}");
            }
        }
    }
}

using ByteBank.Modelos;
using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            var bytes = File.ReadAllBytes("contas.txt");
            Console.WriteLine(bytes.Length);

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
            }


            UsarStreamDeEntrada();

            Console.ReadLine();
        }
    }
}

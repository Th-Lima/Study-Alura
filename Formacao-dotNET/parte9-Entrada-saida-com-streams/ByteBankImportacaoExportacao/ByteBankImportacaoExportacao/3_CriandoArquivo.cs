using ByteBank.Modelos;
using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456,233,1200.00,Gustavo Santos";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);


                fs.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fs = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fs, Encoding.UTF8))
            {
                escritor.Write("888,8520,4100.0,Thales");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using (var fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fs, Encoding.UTF8))
            {
                for(int i = 0; i < 100000; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                   
                    escritor.Flush(); //Despeja o buffer para o Stream

                    Console.WriteLine($"Linha {i} foi escrita no arquivo tecle enter para adicionar outra linha");
                    Console.ReadLine();
                }
            }
        }
    }
}

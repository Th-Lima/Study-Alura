using ByteBankImportacaoExportacao.Modelos;
using System;
using System.IO;
using System.Text;


namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fs = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; //1kb

                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fs.Read(buffer, 0, 1024);

                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
            }
        }
        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = Encoding.Default;

            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach(var myByte in buffer)
            //{
            //    Console.Write(myByte);
            //    Console.Write(" ");
            //}
        }
    }
}
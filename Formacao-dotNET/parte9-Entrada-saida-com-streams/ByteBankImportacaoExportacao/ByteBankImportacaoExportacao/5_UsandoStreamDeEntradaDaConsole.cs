using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {

        static void UsarStreamDeEntrada()
        {
            using (var fs = Console.OpenStandardInput())
            using(var fileStrem = new FileStream("EntradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var bytesLidos = fs.Read(buffer, 0, 1024);
                    
                    fileStrem.Write(buffer, 0, bytesLidos);
                    fileStrem.Flush();

                    Console.WriteLine($"Bytes Lidos da Console {bytesLidos}");
                }
            }
        }
    }
}

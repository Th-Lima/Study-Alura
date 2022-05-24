using AluraTunes.Data;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ZXing;
using ZXing.Common;

namespace AluraTunes.Aula4
{
    /// <summary>
    /// LINQ PARALELO COM AsParallel() 
    /// </summary>
    public static class Aula4Video1
    {
        private const string Imagens = "Imagens";

        public static void Principal()
        {
            var barcodeWriter = new BarcodeWriter();

            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new EncodingOptions
            {
                Width = 100,
                Height = 100
            };

            barcodeWriter.Write("Meu Teste").Save("QRCode.jpg", ImageFormat.Jpeg);

            if (!Directory.Exists(Imagens))
                Directory.CreateDirectory(Imagens);

            using (var contexto = new AluraTunesEntities())
            {
                var queryFaixas =
                from f in contexto.Faixas
                select f;

                Stopwatch stopwatch = Stopwatch.StartNew();

                var listaFaixas = queryFaixas.ToList();

                var queryCodigos =

                listaFaixas
                .AsParallel()
                .Select(x => new
                {
                    Arquivo = string.Format("{0}\\{1}.jpg", Imagens, x.FaixaId),
                    Imagem = barcodeWriter.Write(string.Format("aluratunes.com/faixa/{0}", x.FaixaId))
                });

                var contagem = queryCodigos.Count();

                stopwatch.Stop();
                                                                                                                                        
                Console.WriteLine("Códigos gerados: {0} em {1} segundos.", contagem, stopwatch.ElapsedMilliseconds / 1000.0); //2,084   //AsParallel() ==> //0,611

                foreach (var item in queryCodigos)
                {
                    item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg);
                }
            }
        }
    }
}

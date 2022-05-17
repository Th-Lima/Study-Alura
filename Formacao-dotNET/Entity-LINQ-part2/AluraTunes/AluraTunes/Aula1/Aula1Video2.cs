using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunes.Aula1
{
    /// <summary>
    /// SUBCONSULTA
    /// </summary>
    public static class Aula1Video2
    {
        public static void Principal()
        {
            using (var contexto = new AluraTunesEntities())
            {
                decimal queryMedia = contexto.NotaFiscals.Average(x => x.Total);

                var query =
                from nf in contexto.NotaFiscals
                where nf.Total > queryMedia
                orderby nf.Total descending
                select new
                {
                    Numero = nf.NotaFiscalId,
                    Data = nf.DataNotaFiscal,
                    Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                    Valor = nf.Total
                };

                foreach (var nf in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", nf.Numero, nf.Data, nf.Cliente, nf.Valor);
                }

                Console.WriteLine($"A média é {queryMedia}");
            }
        }
    }
}

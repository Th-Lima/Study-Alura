using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunesAula1
{
    class Program
    {
        static void Main(string[] args)
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

    /// <summary>
    /// LINQ TO ENTITIES PAGINADO
    /// </summary>
    public static class Aula1Video1
    {
        private const int TAMANHO_PAGINA = 10;
       
        public static void Principal()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var numeroNotasFiscais = contexto.NotaFiscals.Count();
                var numeroPaginas = Math.Ceiling((decimal)numeroNotasFiscais / TAMANHO_PAGINA);

                for (int p = 1; p <= numeroPaginas; p++)
                {
                    ImprimirPagina(contexto, p);
                }

            }
        }

        private static void ImprimirPagina(AluraTunesEntities contexto, int numeroPagina)
        {
            var query =
            from nf in contexto.NotaFiscals
            orderby nf.NotaFiscalId
            select new
            {
                Numero = nf.NotaFiscalId,
                Data = nf.DataNotaFiscal,
                Cliente = nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome,
                ValorTotal = nf.Total
            };

            int numeroDePulos = (numeroPagina - 1) * TAMANHO_PAGINA;

            query = query.Skip(numeroDePulos);

            query = query.Take(TAMANHO_PAGINA);

            Console.WriteLine();
            Console.WriteLine($"Página {numeroPagina}");

            foreach (var nf in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", nf.Numero, nf.Data, nf.Cliente, nf.ValorTotal);
            }
        }
    }

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

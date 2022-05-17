using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunes.Aula1
{
    /// <summary>
    /// CLIENTES COMPRARAM PRODUTO MAIS VENDIDO
    /// </summary>
    public static class Aula1Video3
    {
        public static void Principal()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query =
                    from f in contexto.Faixas
                    where f.ItemNotaFiscals.Count() > 0
                    let TotalVendas = f.ItemNotaFiscals.Sum(x => x.Quantidade * f.PrecoUnitario)
                    orderby TotalVendas descending
                    select new
                    {
                        f.FaixaId,
                        f.Nome,
                        Total = TotalVendas
                    };

                var produtoMaisVendido = query.First();

                Console.WriteLine("{0}\t{1}\t{2}", produtoMaisVendido.FaixaId, produtoMaisVendido.Total, produtoMaisVendido.Nome);

                var queryClientes =
                    from nf in contexto.ItemNotaFiscals
                    where nf.FaixaId == produtoMaisVendido.FaixaId
                    select new
                    {
                        Cliente = nf.NotaFiscal.Cliente.PrimeiroNome + " " + nf.NotaFiscal.Cliente.Sobrenome
                    };

                foreach (var item in queryClientes)
                {
                    Console.WriteLine(item.Cliente);
                }
            }
        }
    }
}

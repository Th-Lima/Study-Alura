using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunes.Aula2
{
    /// <summary>
    /// SELF JOIN
    /// ANÁLISE DE AFINIDADE
    /// </summary>
    public static class Aula2Video1
    {
        public static void Principal()
        {
            var nomeDaMusica = "Smells Like Teen Spirit";

            using (var contexto = new AluraTunesEntities())
            {
                var faixaIds =
                    contexto.Faixas
                        .Where(f => f.Nome == nomeDaMusica)
                        .Select(f => f.FaixaId);

                var query =
                  from comprouItem in contexto.ItemNotaFiscals
                  join comprouTambem in contexto.ItemNotaFiscals on comprouItem.NotaFiscalId equals comprouTambem.NotaFiscalId
                  where faixaIds.Contains(comprouItem.FaixaId) && comprouItem.FaixaId != comprouTambem.FaixaId
                  select comprouTambem;

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.NotaFiscalId, item.Faixa.Nome);
                }
            }
        }
    }
}

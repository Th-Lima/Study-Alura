using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraTunesEntities())
            {

                var vendaMedia = contexto.NotaFiscals.Average(nf => nf.Total);
                Console.WriteLine("Venda Média: " + vendaMedia);

                var query = from nf in contexto.NotaFiscals
                            select nf.Total;

                decimal mediana = Mediana(query);

                Console.WriteLine("Mediana: " + mediana);

                //Extension Method in LinqExtensions class
                var vendaMediana = contexto.NotaFiscals.Mediana(nf => nf.Total);

                Console.WriteLine("Mediana (com método de extensão): {0}", vendaMediana);
            }
        }

        private static decimal Mediana(IQueryable<decimal> query)
        {
            var contagem = query.Count();

            var queryOrdenada = query.OrderBy(total => total);

            var elementoCentral1 = queryOrdenada.Skip(contagem / 2).First();

            var elementoCentral2 = queryOrdenada.Skip((contagem - 1) / 2).First();

            var mediana = (elementoCentral1 + elementoCentral2) / 2;
            
            return mediana;
        }

        static string BuscaSegundoElementoDaListaComUmMetodoDeExtensao()
        {
            var tipos = new List<string>()
            {
                "TIPO A",
                "TIPO B",
                "TIPO C",
            };

            //EXTENSION METHOD QUE BUSCA O SEGUNDO ELEMENTO
            var segundoTipo = tipos.Second();

            return segundoTipo;
        }
        static void MaxMinAvgEmUmaConsulta()
        {
            using (var contexto = new AluraTunesEntities())
            {
                //var maiorVenda = contexto.NotaFiscals.Max(nf => nf.Total);
                //var menorVenda = contexto.NotaFiscals.Min(nf => nf.Total);
                //var media = contexto.NotaFiscals.Average(nf => nf.Total);

                var vendas =
                    (from nf in contexto.NotaFiscals
                     group nf by 1 into agrupado
                     select new
                     {
                         MaiorVenda = agrupado.Max(nf => nf.Total),
                         MenorVenda = agrupado.Min(nf => nf.Total),
                         Media = agrupado.Average(nf => nf.Total),

                     }).Single();

                Console.WriteLine($"A maior venda é de R$: {vendas.MaiorVenda}");
                Console.WriteLine($"A menor venda é de R$: {vendas.MenorVenda}");
                Console.WriteLine($"A média de vendas é de R$: {vendas.MenorVenda}");
            }
        }
        static void ExercicioUtilizarVariavelLet()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query =
                from inf in contexto.ItemNotaFiscals
                where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                group inf by inf.Faixa.Album into agrupado
                let total = agrupado.Sum(a => a.PrecoUnitario * a.Quantidade)
                orderby total descending
                select new
                {
                    Album = agrupado.Key.Titulo,
                    Valor = total,
                    NumeroVendas = agrupado.Count()
                };

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.Album, item.Valor, item.NumeroVendas);
                }
            }
        }
        static void ExercicioTrazerQuantidadeDeAlbunsAgrupadoPorArtista()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var artistaEQtdAlbum =
                    from alb in contexto.Albums
                    group alb by alb.Artista into agrupado
                    select new
                    {
                        Artista = agrupado.Key.Nome,
                        QuantidadeAlbum = agrupado.Count()
                    };



                foreach (var item in artistaEQtdAlbum)
                {
                    Console.WriteLine("{0}\t{1}", item.Artista.PadRight(100), item.QuantidadeAlbum);
                }
            }
        }
        static void UtilizandoGroupBy()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query =
                    from inf in contexto.ItemNotaFiscals
                    where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                    group inf by inf.Faixa.Album into agrupado
                    let vendasPorAlbum = agrupado.Sum(x => x.Quantidade * x.PrecoUnitario)
                    orderby vendasPorAlbum descending
                    select new
                    {
                        tituloDoAlbum = agrupado.Key.Titulo,
                        totalPorAlbum = vendasPorAlbum
                    };


                foreach (var agrupado in query)
                {
                    Console.WriteLine("{0}\t{1}",
                        agrupado.tituloDoAlbum.PadRight(40),
                        agrupado.totalPorAlbum);
                }
            }
        }
        static void TotalizandoValorNotasFiscaisDoArtistas()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query =
                    from inf in contexto.ItemNotaFiscals
                    where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                    select new { totalDoItem = inf.Quantidade * inf.PrecoUnitario };

                var total = query.Sum(x => x.totalDoItem);

                Console.WriteLine($"Total do Artista R$: {total}");
            }
        }
        static void BuscaQuantidadeDeFaixasDeUmArtista()
        {
            //Quantas faixas existem para cada determinado artista
            using (var contexto = new AluraTunesEntities())
            {
                Console.WriteLine("Digite o nome do artista que retornarei a quantidade de músicas que temos dele: ");
                var nomeArtista = Console.ReadLine();

                var query =
                    from f in contexto.Faixas
                    where f.Album.Artista.Nome == nomeArtista
                    select f;

                nomeArtista = query.Select(x => x.Album.Artista.Nome).FirstOrDefault();
                var quantidadeMusicas = query.Count();

                Console.WriteLine();
                Console.WriteLine("{0}\t{1}", "Músicas", "Artistas");
                Console.WriteLine("{0}\t{1}", quantidadeMusicas, nomeArtista);
            }
        }
        static void ListaTotalNotaFiscalOrdenadoPeloMaiorValor()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query2 =
                    contexto.NotaFiscals.OrderByDescending(x => x.Total).ThenBy(nf => nf.Cliente.PrimeiroNome + " " + nf.Cliente.Sobrenome);

                foreach (var item in query2)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.Total, item.Cliente.PrimeiroNome, item.Cliente.Sobrenome);
                }
            }
        }
        static void ModificandoQuery()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var query1 = from f in contexto.Faixas
                             where f.Album.Artista.Nome == "Led Zeppelin"
                             select f;


                //var query2 = query1.Where(x => x.Album.Titulo.Contains("Graffiti"));
                var query2 =
                    from f in query1
                    where f.Album.Titulo.Contains("Graffiti")
                    select f;

                foreach (var faixa in query1)
                {
                    Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
                }

                Console.WriteLine();
                Console.WriteLine("======================================================");

                Console.WriteLine("Albuns do Led Zeppelin que contém a palavra Graffiti");

                Console.WriteLine("======================================================");
                foreach (var faixa in query2)
                {
                    Console.WriteLine(faixa.Album.Titulo);
                }
            }
        }
        static void GetFaixas()
        {
            using (var contexto = new AluraTunesEntities())
            {
                Console.WriteLine("Digite o nome do Artista");
                string nomeArtista = Console.ReadLine();

                Console.WriteLine("Digite o nome do album");
                string nomeAlbum = Console.ReadLine();

                var query =
                     from f in contexto.Faixas
                     where f.Album.Artista.Nome.Contains(nomeArtista)
                     && (!string.IsNullOrEmpty(nomeAlbum) ? f.Album.Titulo.Contains(nomeAlbum) : true)
                     orderby f.Album.Titulo, f.Nome 
                     select f;

                //query = query.OrderBy(x => x.Album.Titulo).ThenBy(x => x.Nome);

                

                foreach (var faixa in query)
                {
                    Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
                }
            }
        }
        static void Video1()
        {
            using (var contexto = new AluraTunesEntities())
            {
                //Console.WriteLine("Listar todos os generos");
                //Console.WriteLine();
                //var query = 
                //    from g in contexto.Generos
                //    select g;

                //foreach (var genero in query)
                //{
                //    Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
                //}

                Console.WriteLine();
                Console.WriteLine("Listar todas as músicas junto com seus generos");
                var generoMusicaQuery =
                    from g in contexto.Generos
                    join f in contexto.Faixas on g.GeneroId equals f.GeneroId
                    select new { Genero = g.Nome, Musica = f.Nome };

                //Pegar somente 10 itens
                generoMusicaQuery = generoMusicaQuery.Take(10);

                contexto.Database.Log = Console.WriteLine;

                foreach (var generoMusica in generoMusicaQuery)
                {
                    Console.WriteLine("{0}\t{1}", generoMusica.Genero, generoMusica.Musica);
                }
            }
        }
        static void Video2SintaxeSQL()
        {
            using (var contexto = new AluraTunesEntities())
            {
                string textoBusca = "Led";

                var query =
                    from a in contexto.Artistas
                    where a.Nome.Contains(textoBusca)
                    select a;

                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

            }
        }
        static void Video2SintaxeMetodo()
        {
            using (var contexto = new AluraTunesEntities())
            {
                string textoBusca = "Led";

                var query = contexto.Artistas.Where(a => a.Nome.Contains(textoBusca));

                foreach (var artista in query)
                {
                    Console.WriteLine("{0}\t{1}", artista.ArtistaId, artista.Nome);
                }

            }
        }
        static void JoinAndNavigationProperties()
        {
            using (var contexto = new AluraTunesEntities())
            {
                string textoBusca = "Led";
                
                //Com Join
                var query =
                    from a in contexto.Artistas
                    join alb in contexto.Albums
                        on a.ArtistaId equals alb.ArtistaId
                    where a.Nome.Contains(textoBusca)
                    select new
                    {
                        NomeArtista = a.Nome,
                        NomeAlbum = alb.Titulo
                    };

                Console.WriteLine("============================== COM JOIN ====================================");
                foreach (var artistaAlbum in query)
                {
                    Console.WriteLine("{0}\t{1}", artistaAlbum.NomeArtista, artistaAlbum.NomeAlbum);
                }

                Console.WriteLine();
                Console.WriteLine();

                //Navigation Properties
                var query2 =
                    from alb in contexto.Albums
                    where alb.Artista.Nome.Contains(textoBusca)
                    select new { NomeArtista = alb.Artista.Nome, NomeAlbum = alb.Titulo };

                Console.WriteLine("============================= SEM JOIN <Navigation Properties> ========================================");
                foreach (var album in query2)
                {
                    Console.WriteLine("{0}\t{1}", album.NomeArtista, album.NomeAlbum);
                }
            }
        }
    }
}

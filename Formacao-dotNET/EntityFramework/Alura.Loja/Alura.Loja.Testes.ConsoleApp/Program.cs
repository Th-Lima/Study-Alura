using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LojaContext())
            {
                var cliente = context.Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();
               
                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");


                var produto = context
                    .Produtos
                    .Where(p => p.Id == 3002)
                    .FirstOrDefault();

                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"Mostrando compras do produto {produto.Nome}");
                foreach(var item in produto.Compras)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }
        
        static void ExibeProdutosDaPromocao()
        {
            using (var context2 = new LojaContext())
            {
                var promocao = context2.Promocoes
                    //Outra abordagem é usar a sobrecarga do método include, como abaixo
                    //.Include("Produtos.Produto")
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                Console.WriteLine("\n Mostrando os produtos da promoção");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }
        static void IncluirPromocao()
        {
            using (var context = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima total Janeiro 2021";
                promocao.DataInicio = new DateTime(2021, 1, 1);
                promocao.DataTermino = new DateTime(2021, 1, 31);

                var produtos = context.Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                context.Promocoes.Add(promocao);

                ExibirEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
            }
        }
        static void UmPraUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = "12",
                Logradouro = "Rua dos inválidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var context = new LojaContext())
            {
                context.Clientes.Add(fulano);

                context.SaveChanges();
            }
        }
        static void MuitosParaMuitos()
        {
            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            var p1 = new Produto()
            {
                Nome = "Suco de Laranja",
                Categoria = "Bebidas",
                Unidade = "Litros",
                PrecoUnitario = 8.00
            };

            var p2 = new Produto()
            {
                Nome = "Café",
                Categoria = "Bebidas",
                Unidade = "Gramas",
                PrecoUnitario = 12.00
            };

            var p3 = new Produto()
            {
                Nome = "Macarrão",
                Categoria = "Alimentos",
                Unidade = "Gramas",
                PrecoUnitario = 4.00
            };


            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);


            using (var context = new LojaContext())
            {
                //context.Promocoes.Add(promocaoDePascoa);

                var promocao = context.Promocoes.Find(1);
                context.Promocoes.Remove(promocao);
                ExibirEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
            }
        }

        static void ExibirEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("------------------");
            foreach (var entrie in entries)
            {
                Console.WriteLine(entrie.Entity.ToString() + " - " + entrie.State);
            }
        }
    }
}

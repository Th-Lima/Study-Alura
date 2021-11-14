using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(100,1000),
                null,
                new ContaCorrente(105,1003),
                new ContaCorrente(103,1007),
                null,
                new ContaCorrente(102,1010),
                null,
                new ContaCorrente(1001,1001),
            };

            //Chama a implementação dada em IComparable
            //contas.Sort();
            //contas.Sort(new Comparadores.ComparadorContaCorrentePorAgencia());

           

            IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
               Console.WriteLine(conta);
            }

            Console.WriteLine("/////////////////////////////");


            var idades = new List<int>();

            idades.Add(10);
            idades.Add(5);
            idades.Add(11);
            idades.Add(78);
            idades.Add(105);
            idades.Add(23);

            idades.AdicionarVarios(15, 12, 13, 55);
            idades.AdicionarVarios(99, -1);

            idades.Sort();
            
            idades.Remove(10);

            for(int i = 0; i < idades.Count; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
            //int soma = SomarVarios(1,2,3,101,200);
            //Console.WriteLine(soma);
            Console.ReadKey();
        }

        static void TestaMetodoSort()
        {
            var nomes = new List<string>()
            {
                "Thales",
                "Matheus",
                "Lucas",
                "Ana",
                "José"
            };


            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }
        static void TestandoListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();
            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.AdicionarVarios(20, 23, 60, 65);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }
        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }
        static void TestandoArraysDeContCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
        {
                new ContaCorrente(2151, 65465),
                new ContaCorrente(21, 65),
                new ContaCorrente(254, 465)
        };

            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta {i}: {contaAtual}");
            }
        }
        static void ComecandoComArray()
        {
            //ARRAY DE INT COM 5 POSIÇÕES
            int[] idades = null;
            idades = new int[6];


            idades[0] = 15;
            idades[1] = 20;
            idades[2] = 38;
            idades[3] = 50;
            idades[4] = 46;
            idades[5] = 60;

            int media = 0;

            //Alternativa com foreach
            //foreach(int idade in idades)
            //{
            //    media += idade / idades.Length;
            //}

            for (int i = 0; i < idades.Length; i++)
            {
                media += idades[i] / idades.Length;
            }

            Console.WriteLine($"Média de idades: {media}");
        }
        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();


            ContaCorrente contaThales = new ContaCorrente(1111111, 1111111);


            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaThales,
                new ContaCorrente(211564, 777546),
                new ContaCorrente(211564, 12316)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                 contaThales,
                 new ContaCorrente(211564, 777546),
                 new ContaCorrente(211564, 12316)
                 );

            for (int i = 0; i < lista.Tamanho; i++)
            {

                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }


            lista.Remover(contaThales);

            Console.WriteLine("Após remover o item");

            lista.EscreverListaNaTela();

            Console.ReadLine();
        }
    }
}

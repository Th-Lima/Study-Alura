using ByteBank.Modelos;
using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>();

            idades.Adicionar(10);
            idades.AdicionarVarios(55, 32, 74, 12);


            for(int i = 0; i < idades.Tamanho; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
            //int soma = SomarVarios(1,2,3,101,200);
            //Console.WriteLine(soma);
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

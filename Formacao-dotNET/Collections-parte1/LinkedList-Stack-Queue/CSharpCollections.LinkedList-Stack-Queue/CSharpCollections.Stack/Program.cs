using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Pilha
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("LIFO (Last-in Firt-Out)");
            var navegador = new Navegador();
            navegador.NavegarPara("google.com");
            navegador.NavegarPara("caelum.com.br");
            navegador.NavegarPara("alura.com.br");

            Console.WriteLine();
            Console.WriteLine("Anterior <------------------");
            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();
            Console.WriteLine("<------------------");

            Console.WriteLine();
            Console.WriteLine("Próximo ------------------>");
            navegador.Proximo();
            navegador.Proximo();
            Console.WriteLine("------------------>");
        }
    }

    internal class Navegador
    {
        private string atual = "vazia";
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();

        public Navegador()
        {
            Console.WriteLine("Página atual: " + atual);
        }

        internal void Anterior()
        {
            if(historicoAnterior.Count != 0 || historicoAnterior.Any())
            {
                historicoProximo.Push(atual);
                atual =  historicoAnterior.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }

        internal void NavegarPara(string url)
        {
            historicoAnterior.Push(atual);
            atual = url;
            Console.WriteLine("Página atual: " + atual);
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual);
                atual = historicoProximo.Pop();
                Console.WriteLine("Página atual: " + atual);
            }
        }
    }
}

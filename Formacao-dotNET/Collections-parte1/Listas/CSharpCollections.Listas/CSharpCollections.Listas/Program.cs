using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            string aulaIntro = "Introdução a coleções";
            string aulaModelando = "Modelando a classe aula";
            string aulaSets = "Trabalhando com Conjuntos";

            //List<string> aulas = new List<string>
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};


            List<string> aulas = new List<string>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            Imprimir(aulas);

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Primeiro elemento da Lista: ");
            Console.WriteLine(aulas.First()); // -> Sem LINQ - Console.WriteLine(aulas[0]);
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("Ultimo elemento da Lista: ");
            Console.WriteLine(aulas.Last()); // -> Sem LINQ - Console.WriteLine(aulas[aulas.Count - 1]);
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("Trocando o nome da primeira aula: ");
            aulas[0] = "Trabalhando com listas";
            Imprimir(aulas);

            Console.WriteLine("----------------------------");

            Console.WriteLine("A primeira aula 'Trabalhando' é : " + aulas.First(x => x.Contains("Trabalhando")));
            Console.WriteLine("A ultima aula 'Trabalhando' é : " + aulas.Last(x => x.Contains("Trabalhando")));
            Console.WriteLine("A ultima aula 'Conclusão' é : " + aulas.FirstOrDefault(x => x.Contains("Conslusão")));

            Console.WriteLine("----------------------------");
            Console.WriteLine("Trocando a ordem da lista: ");

            aulas.Reverse();

            Imprimir(aulas);

            aulas.Reverse();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Trocando novamente a ordem da lista: ");

            Imprimir(aulas);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Removendo o último elemento da lista: ");
            aulas.RemoveAt(aulas.Count - 1);
            Imprimir(aulas);


            Console.WriteLine("----------------------------");
            Console.WriteLine("Adicionando mais um elemento na lista: ");
            aulas.Add("Conclusão");
            Imprimir(aulas);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Ordenando em ordem alfabética: ");
            aulas.Sort();
            Imprimir(aulas);


            Console.WriteLine("----------------------------");
            Console.WriteLine("Fazendo uma cópia da lista: ");
            List<string> copia = aulas.GetRange(aulas.Count - 2, 2);
            Imprimir(copia);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Fazendo um clone da lista: ");
            List<string> clone = new List<string>(aulas);
            Imprimir(clone);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Removendo os dois últimos elementos do lista clone:");
            clone.RemoveRange(clone.Count - 2, 2);
            Imprimir(clone);
        }

        private static void Imprimir(List<string> aulas)
        {
            //foreach(var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            //for (int i = 0; i < aulas.Count; i++)
            //{
            //    Console.WriteLine($"({i + 1}): {aulas[i]}");
            //}

            aulas.ForEach(aula =>
            {
                Console.WriteLine(aula);
            });
        }
    }
}

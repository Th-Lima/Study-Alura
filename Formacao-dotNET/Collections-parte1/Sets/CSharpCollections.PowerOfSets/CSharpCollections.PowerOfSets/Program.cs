using System;
using System.Collections.Generic;

namespace CSharpCollections.PowerOfSets
{
    class Program
    {
        static void Main(string[] args)
        {
            //SETS - Conjusntos
            ISet<string> alunos = new HashSet<string>();

            alunos.Add("Vanessa");
            alunos.Add("Ana");
            alunos.Add("Rafael");

            Console.WriteLine(string.Join(" , ", alunos));

            alunos.Add("Priscila");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio");

            Console.WriteLine(string.Join(" , ", alunos));

            //Remover um aluno e adicionar outro
            alunos.Remove("Ana");
            alunos.Add("Marcelo Oliveira");
            Console.WriteLine(string.Join(" , ", alunos));

            //Adicionar aluno que já existe
            alunos.Add("Fabio");
            Console.WriteLine(string.Join(" , ", alunos));

            //Vantagem de usar um conjunto e não uma lista / look-up

            //HashSet possui maior escalabilidade e um pnto fraco é o consumo de memória

            //Ordenar o conjunto
            //Copiar um conjunto para uma lista
            List<string> alunosEmLista = new List<string>(alunos);
            alunosEmLista.Sort();
            Console.WriteLine("Ordenados: " + string.Join(" , ", alunosEmLista));
        }
    }
}

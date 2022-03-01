using System;
using System.Collections.Generic;

namespace ColecoesOrdenadas
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();

            //alunos.Add("VT", new Aluno("Vanessa", 1126345));
            //alunos.Add("AL", new Aluno("Ana", 498445));
            //alunos.Add("RN", new Aluno("Rafael", 1185235));
            //alunos.Add("WM", new Aluno("Wanderson", 1854120));

            //foreach (var aluno in alunos)
            //{
            //    Console.WriteLine(aluno);
            //}

            //alunos.Remove("AL");

            //alunos.Add("MO", new Aluno("Marcelo", 45620));

            //Console.WriteLine("-------------------------");
            //foreach (var aluno in alunos)
            //{
            //    Console.WriteLine(aluno);
            //}


            //Dicionário ordenado => SortedList
            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();

            sorted.Add("VT", new Aluno("Vanessa", 1126345));
            sorted.Add("AL", new Aluno("Ana", 498445));
            sorted.Add("RN", new Aluno("Rafael", 1185235));
            sorted.Add("WM", new Aluno("Wanderson", 1854120));

            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using ColecoesOrdenadas;
using System;
using System.Collections.Generic;

namespace SortedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>();

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

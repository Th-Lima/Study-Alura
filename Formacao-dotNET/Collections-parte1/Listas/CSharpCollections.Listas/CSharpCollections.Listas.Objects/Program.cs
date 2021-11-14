using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections.Listas.Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var aulaIntro = new Aula("Introdução a coleções", 10);
            var aulaModelando = new Aula("Modelando a classe aula", 30);
            var aulaSets = new Aula("Trabalhando com Conjuntos", 20);

            List<Aula> aulas = new List<Aula>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);
            //aulas.Add(new Aula("Conclusão", 50));
            Imprimir(aulas);

            aulas.Sort();
            Imprimir(aulas);

            aulas.Sort((thiss, other) => thiss.Tempo.CompareTo(other.Tempo));
            Imprimir(aulas);
        }

        static void Imprimir(IEnumerable<Aula> aulas)
        {
            Console.Clear();
            foreach(var aula in aulas)
            {
                Console.WriteLine(aula.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Priscila Stuani"
            };

            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            alunos.Add("Fabio Gushiken"); //Ignorado pela classe ComparadorMinusculo
            alunos.Add("FABIO GUSHIKEN"); //Ignorado pela classe ComparadorMinusculo


            ISet<string> outroConjunto = new HashSet<string>();

            //Este conjunto é subconjunto do outro ? IsSubsetOf
            var isSubsetOf = alunos.IsSubsetOf(outroConjunto);

            // Este conjunto é superconjunto do outro ? IsSupersetOf
            var isSuperSetOf = alunos.IsSupersetOf(outroConjunto);

            // Os conjuntos contêm os mesmo elementos ? SetEquals
            var isEqual = alunos.SetEquals(outroConjunto);

            // Subtrai os elementos da outra coleção que também estão no outro conjunto. - ExceptWith
            alunos.ExceptWith(outroConjunto);

            // Intersecção dos conjuntos - IntersectWith
            alunos.IntersectWith(outroConjunto);

            // Somente em um ou outro conjunto - SymmetricExceptWith
            alunos.SymmetricExceptWith(outroConjunto);

            // União de conjuntos - UnionWith
            alunos.UnionWith(outroConjunto);

            //Console.WriteLine(isSubsetOf);
            //Console.WriteLine(isSuperSetOf);
            //Console.WriteLine(isEqual);

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }
}

using System;
using System.Linq;

namespace OperadoresDeConjuntosLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            Console.WriteLine("Concatenando duas seqências");
            var consulta = seq1.Concat(seq2);
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("União de duas sequências");
            var consulta2 = seq1.Union(seq2);
            {
            foreach (var item in consulta2)
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("União de duas sequencias com comparador");
            var consulta3 = seq1.Union(seq2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in consulta3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Intersecção de duas sequencias");
            var consulta4 = seq1.Intersect(seq2);
            foreach (var item in consulta4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Exceto: elementos de sq1 que não estão no seq2");
            var consulta5 = seq1.Except(seq2, StringComparer.InvariantCultureIgnoreCase);
            foreach (var item in consulta5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            string[] dias = { "segunda", "terça", "quarta", "quinta", "sexta", "sábado", "domingo", "teste" };
            var consulta6 = dias.Skip(4).Take(3);
            foreach (var item in consulta6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}

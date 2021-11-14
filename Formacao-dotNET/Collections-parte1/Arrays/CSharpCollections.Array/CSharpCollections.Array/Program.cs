using System;

namespace CSharpCollections.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string aulaInfo = "Introdução a coleções";
            string aulaModelando = "Modelando a classe aula";
            string aulaSets = "Trabalhando com conjuntos";

            //string[] aulas = new string[]
            //{
            //    aulaInfo,
            //    aulaModelando,
            //    aulaSets
            //};

            string[] aulas = new string[3];

            aulas[0] = aulaInfo;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            //UMA FORMA COM O for(), se quiser o índice por exemplo.
            //for (int i = 0; i < aulas.Length; i++)
            //{
            //    Console.WriteLine($"Aula({i + 1}) = {aulas.GetValue(i)}");
            //}

            ImprimirTodos(aulas);

            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[aulas.Length - 1]);

            aulas[0] = "Trabalhando com arrays";
            ImprimirTodos(aulas);

            Console.WriteLine($"A aula modelando está no índice " + Array.IndexOf(aulas, aulaModelando));
            Console.WriteLine($"A aula modelando está no índice " + Array.LastIndexOf(aulas, aulaModelando));

            Console.WriteLine("Invertendo a ordem");
            Array.Reverse(aulas);
            ImprimirTodos(aulas);

            Console.WriteLine("Invertendo a ordem novamente");
            Array.Reverse(aulas);
            ImprimirTodos(aulas);

            Console.WriteLine("Redimensionando o tamanho do array");
            Array.Resize(ref aulas, 2);
            ImprimirTodos(aulas);

            Array.Resize(ref aulas, 3);
            ImprimirTodos(aulas);

            aulas[aulas.Length - 1] = "Conclusão";
            ImprimirTodos(aulas);

            Array.Sort(aulas);
            ImprimirTodos(aulas);

            string[] copia = new string[2];
            Array.Copy(aulas, 1, copia, 0, 2);
            ImprimirTodos(copia);

            string[] clone = aulas.Clone() as string[];
            ImprimirTodos(clone);

            Array.Clear(clone, 1, 2);  
            ImprimirTodos(clone);
        }

        private static void ImprimirTodos(string[] aulas)
        {
            //foreach (var aula in aulas)
            //{
            //    Console.Write(aula);
            //}
            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine($"Aula({i + 1}) = {aulas[i]}");
            }
        }
    }
}

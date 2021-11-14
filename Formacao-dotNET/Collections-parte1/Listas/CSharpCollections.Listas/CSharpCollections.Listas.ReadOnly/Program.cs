using System;
using System.Collections.Generic;

namespace CSharpCollections.Listas.ReadOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso csharpColecoes = new Curso("C# Collections", "Thales Lima");
            csharpColecoes.Adiciona(new Aula("Trabalhando com listas", 21));

            Imprimir(csharpColecoes.Aulas);

            //adicionar 2 aulas
            csharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com coleções", 10));

            Imprimir(csharpColecoes.Aulas);

            //ordenar a lista de aulas
            //csharpColecoes.Aulas.Sort();

            //copiar a lista para outra lista
            List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);
            
            //ordernar a cópia
            aulasCopiadas.Sort();

            Imprimir(aulasCopiadas);

            //Totalizar o tempo do curso
            Console.WriteLine(csharpColecoes.TempoTotal);

            Console.WriteLine(csharpColecoes.ToString());
        
        }

        static void Imprimir(IList<Aula> aulas)
        {
            Console.Clear();
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula.ToString());
            }
        }
    }
}

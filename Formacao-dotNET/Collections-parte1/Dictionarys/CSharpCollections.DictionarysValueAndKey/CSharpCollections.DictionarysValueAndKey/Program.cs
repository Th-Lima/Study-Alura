using System;

namespace CSharpCollections.DictionarysValueAndKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");

            csharpColecoes.Adiciona(new Aula("Trabalhando com lista", 20));
            csharpColecoes.Adiciona(new Aula("Trabalhando com conjuntos", 25));
            csharpColecoes.Adiciona(new Aula("Trabalhando com array", 19));

            Aluno aluno1 = new Aluno("Vanessa", 121564);
            Aluno aluno2 = new Aluno("Ana", 54987425);
            Aluno aluno3 = new Aluno("Rafael", 8741230);

            csharpColecoes.Matricula(aluno1);
            csharpColecoes.Matricula(aluno2);
            csharpColecoes.Matricula(aluno3);

            Console.WriteLine("Imprimindo os alunos matriculados: ");
            foreach(var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine($"O Aluno {aluno1.Nome} está matriculado ou não ?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(aluno1));

            Aluno vanessa = new Aluno("Vanessa", 121564);
            Console.WriteLine("Vanessa está matriculada ? " + csharpColecoes.EstaMatriculado(vanessa));
            Console.WriteLine("---------------------");
            Console.WriteLine("aluno1 == a vanessa ?");
            Console.WriteLine(aluno1 == vanessa);

            Console.WriteLine("---------------------");

            Console.WriteLine("aluno1 é equals a vanessa?");
            Console.WriteLine(aluno1.Equals(vanessa));

            Console.Clear();

            Console.WriteLine("Quem é o aluno com a matrícula 121564 ? ");
            Aluno aluno121564 = csharpColecoes.BuscaMatriculado(121564);
            Console.WriteLine("aluno 121564: " + aluno121564);

            Console.WriteLine("---------------------");

            Console.WriteLine("Quem é o aluno 5618 ?");
            Console.WriteLine(csharpColecoes.BuscaMatriculado(5618));

            Console.WriteLine("---------------------");

            Console.WriteLine("Adicionando outro aluno com a mesma chave : ");
            Aluno thales = new Aluno("Thales", 121564);
            //csharpColecoes.Matricula(thales);
            csharpColecoes.SubstituiAlunos(thales);
            Console.WriteLine("Agora, quem tem tem a matrícula 121564: ");
            Console.WriteLine(csharpColecoes.BuscaMatriculado(121564));
        }
    }
}

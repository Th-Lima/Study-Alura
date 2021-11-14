using System.Collections.Generic;

namespace Web
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "C# Orientado a Objetos", 50.99m));
            livros.Add(new Livro("002", "C# SOLID", 35.00m));
            livros.Add(new Livro("003", "C# TDD", 45.00m));

            return livros;
        }
    }
}

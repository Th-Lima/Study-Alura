using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> Livros { get; set; }

        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();

            var livro = repo.Todos.First(l => l.Id == id).Detalhes();

            return livro;
        }

        /// <summary>
        /// Amarra a chegada da requisição com o código de atendimento, com a resposta que vamos escrever
        /// Este método é do tipo RequestDelegate
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;

            return View("ListaLivros");
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;

            return View("ListaLivros");
        }

        public IActionResult Lido()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lidos.Livros;

            return View("ListaLivros");
        }

        public string Teste()
        {
            return "Nova implementação funcionando!!";
        }
    }
}

using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
       
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return "Livro Adicionado com sucesso!";
        }

        public IActionResult ExibeFormulario()
        {
            var html = new ViewResult { ViewName = "Formulario" };
            //var html = HtmlUtils.CarregaArquivoHTML("Formulario");            
            return html;
        }
    }
}

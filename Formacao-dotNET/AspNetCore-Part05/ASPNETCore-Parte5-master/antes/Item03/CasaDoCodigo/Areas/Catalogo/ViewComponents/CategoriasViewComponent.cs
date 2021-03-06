using CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CategoriasViewComponent : ViewComponent
    {
        private const int TAMANHO_DA_PAGINA = 4;


        public IViewComponentResult Invoke(IList<Produto> produtos)
        {
            var categorias = produtos
                .Select(m => m.Categoria)
                .Distinct().ToList();

            return View("Default",
                new CategoriasViewModel(categorias, produtos, TAMANHO_DA_PAGINA));
        }
    }
}

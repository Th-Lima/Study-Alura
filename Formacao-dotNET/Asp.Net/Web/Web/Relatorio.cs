using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web
{
    public class Relatorio : IRelatorio
    {
        private readonly ICatalogo Catalogo;

        public Relatorio(ICatalogo catalogo)
        {
            Catalogo = catalogo;
        }

        public async Task ImprimeRelatorio(HttpContext context)
        {
            if (Catalogo.GetLivros().Count > 0)
            {
                foreach (var catalogo in Catalogo.GetLivros())
                {
                    await context.Response.WriteAsync($"{catalogo.Codigo,-10} | {catalogo.Nome,-40} | {catalogo.Preco.ToString("C"),10} \r\n");
                }
            }
            else
            {
                await context.Response.WriteAsync($"Não tem livros");
            }
        }
    }
}

using CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public interface IRelatorioHelper
    {
        Task GerarRelatorio(Pedido pedido);
    }

    public class RelatorioHelper : IRelatorioHelper
    {
        private const string RelativeUri = "api/relatorio";
        
        private IConfiguration _configuration;

        private readonly HttpClient _httpClient;

        //Problema: não detecta mudanças no DNS
        //private static HttpClient httpClient;

        public RelatorioHelper(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        
        public async Task GerarRelatorio(Pedido pedido)
        {
            string linhaRelatorio = await GetLinhaRelatorio(pedido);
            
            //EXAUSTAO DE SOCKET
            //using (HttpClient httpClient = new HttpClient())
            //using (HttpClient httpClient = HttpClientFactory.Create())
            //{
                // O Texto do conteúdo (JSON)
                var json = JsonConvert.SerializeObject(linhaRelatorio);
                // O Conteúdo que irá empacotar no formato application/json (HttpContent)
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                // URI
                //endereço base: http://localhost:49192
                //endreço relativo: api/relatorio
                Uri baseUri = new Uri(_configuration["RelatorioWebApiUrl"]);
                Uri uri = new Uri(baseUri, RelativeUri);

                var httpResponseMessage = await _httpClient.PostAsync(uri, httpContent);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new ApplicationException(httpResponseMessage.ReasonPhrase);
                }
            //}
        }

        private async Task<string> GetLinhaRelatorio(Pedido pedido)
        {
            StringBuilder sb = new StringBuilder();
            string templatePedido =
                    await System.IO.File.ReadAllTextAsync("TemplatePedido.txt");

            string templateItemPedido =
                await System.IO.File.ReadAllTextAsync("TemplateItemPedido.txt");

            string linhaPedido =
                string.Format(templatePedido,
                    pedido.Id,
                    pedido.Cadastro.Nome,
                    pedido.Cadastro.Endereco,
                    pedido.Cadastro.Complemento,
                    pedido.Cadastro.Bairro,
                    pedido.Cadastro.Municipio,
                    pedido.Cadastro.UF,
                    pedido.Cadastro.Telefone,
                    pedido.Cadastro.Email,
                    pedido.Itens.Sum(i => i.Subtotal));

            sb.AppendLine(linhaPedido);

            foreach (var i in pedido.Itens)
            {
                string linhaItemPedido =
                    string.Format(
                        templateItemPedido,
                        i.Produto.Codigo,
                        i.PrecoUnitario,
                        i.Produto.Nome,
                        i.Quantidade,
                        i.Subtotal);

                sb.AppendLine(linhaItemPedido);
            }
            sb.AppendLine($@"=============================================");

            return sb.ToString();
        }
    }
}
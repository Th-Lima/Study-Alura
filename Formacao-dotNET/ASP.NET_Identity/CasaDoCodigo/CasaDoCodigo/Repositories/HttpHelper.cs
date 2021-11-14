using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CasaDoCodigo
{
    //MELHORIA: 8) dados do cadastro gravados na sessão
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        public IConfiguration Configuration { get; }
        private UserManager<AppIdentityUser> _userManager;

        public HttpHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration, UserManager<AppIdentityUser> userManager)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
            _userManager = userManager;
        }

        private string GetClienteId()
        {
            var claimsPrincipal = contextAccessor.HttpContext.User;
            
            var clienteId = _userManager.GetUserId(claimsPrincipal);

            return clienteId;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{GetClienteId()}");
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }

        public void SetCadastro(Cadastro cadastro)
        {
            string json = JsonConvert.SerializeObject(cadastro.GetClone());
            contextAccessor.HttpContext.Session.SetString("cadastro", json);
        }

        public Cadastro GetCadastro()
        {
            string json = contextAccessor.HttpContext.Session.GetString("cadastro");
            if (string.IsNullOrWhiteSpace(json))
                return new Cadastro();

            return JsonConvert.DeserializeObject<Cadastro>(json);
        }
    }

}

using Microsoft.AspNetCore.Identity;

namespace CasaDoCodigo.Areas.Identity.Data
{
    public class AppIdentityUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}

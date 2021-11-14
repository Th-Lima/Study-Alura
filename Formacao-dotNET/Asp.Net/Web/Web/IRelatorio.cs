using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web
{
    public interface IRelatorio
    {
        Task ImprimeRelatorio(HttpContext context);
    }
}
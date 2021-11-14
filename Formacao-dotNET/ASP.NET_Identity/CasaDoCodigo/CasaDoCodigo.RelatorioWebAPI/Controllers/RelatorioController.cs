using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.RelatorioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : Controller
    {
        private static readonly List<string> _relatorio = new List<string>() 
        {
            "Primeiro pedido",
            "Segundo pedido"
        };
        
        // GET: RelatorioController
        [HttpGet]
        public string Get()
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in _relatorio)
            {
                stringBuilder.AppendLine(item);
            }

            return stringBuilder.ToString();
        }

        // POST api/relatorio
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _relatorio.Add(value);
        }
    }
}

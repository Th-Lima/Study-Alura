using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        public string URL { get; }
        private readonly string  _argumentos;

        public ExtratorValorDeArgumentosURL(string url)
        {
            if(String.IsNullOrEmpty(url) || String.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("O argumento url não pode ser uma string vazia ou nula.", nameof(url));
            }

            URL = url;
            
            int interrogacao = url.IndexOf('?');
            _argumentos = url.Substring(interrogacao + 1);
        }

        //moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToUpper(); //VALOR
            string argumentoEmCaixaAlta = _argumentos.ToUpper();//MOEDAORIGEM=REAL&MOEDADESTINO=DOLAR
           
            string termo = nomeParametro + "="; //moedaDestino=
            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo); //x
           
            string resultado = _argumentos.Substring(indiceTermo + termo.Length); //dolar
            int indiceEComercial = resultado.IndexOf('&');

            if(indiceEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indiceEComercial);
        }
    }
}

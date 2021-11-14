using ByteBank.Modelos;
using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            //object conta = new ContaCorrente(2124654, 15646);
            //string contaToString = conta.ToString();


            //Console.WriteLine(contaToString);
            //Console.WriteLine(conta);


            //ContaCorrente conta2 = new ContaCorrente(154564,464654);

            //Cliente carlos = new Cliente();
            //carlos.Nome = "Carlos";
            //carlos.CPF = "164.005.367-01";
            //carlos.Profissao = "Dev";

            //Cliente carlos2 = new Cliente();
            //carlos2.Nome = "Carlos";
            //carlos2.CPF = "164.005.367-01";
            //carlos2.Profissao = "Dev";

            //if(carlos.Equals(carlos2))
            //{
            //    Console.WriteLine("São iguais");
            //}
            //else
            //{
            //    Console.WriteLine("Não são iguais");
            //}

            TestandoStringAulaCinco();

        }

        static void TestandoStringAulaCinco()
        {
            //Olá meu nome é Thales e você pode entra em contato comigo através do número 1234-5789;
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //string padraoNovo = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //string padraoNovo = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padraoNovo = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Thales e você pode 98204-5789 entra em contato comigo através do número ";

            Match resultado = Regex.Match(textoDeTeste, padraoNovo);

            Console.WriteLine(resultado.Value);
            Console.ReadLine();


            //string urlTeste = "https://www.bytebank.com/cambio";
            //int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");
            //Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            //Console.WriteLine(urlTeste.EndsWith("cambio"));
            //Console.WriteLine(urlTeste.Contains("bytebank"));
            //Console.ReadLine();

            ////moedaOrigem = real & moedaDestino = dolar
            //string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            //ExtratorValorDeArgumentosURL extratorValorDeArgumentosURL = new ExtratorValorDeArgumentosURL(urlParametros);

            //string valorMoedaOrigem = extratorValorDeArgumentosURL.GetValor("moedaOrigem");
            //Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);

            //string valorMoedaDestino = extratorValorDeArgumentosURL.GetValor("moedaDestino");
            //Console.WriteLine("Valor de moedaDestino: " + valorMoedaDestino);
            //Console.WriteLine(extratorValorDeArgumentosURL.GetValor("VALOR"));


            //Console.ReadLine();




            //// pagina?argumentos
            //// 012345678

            //string textoVazio = "";
            //string textoNulo = null;
            //string textoQualquer = "kjhfsdjhgsdfjksdf";

            //string mesagemDeBusca = "PALAVRA";
            //string termoBusca = "ra";


            //Console.WriteLine(mesagemDeBusca.ToLower().IndexOf(termoBusca.ToLower()));
            //Console.ReadLine();





            ////TESTANDO O MÉTODO REMOVE();
            ////string testeRemocao = "primeiraParte&parteParaRemover";
            ////int indiceEComercial = testeRemocao.IndexOf("&");
            ////Console.WriteLine(testeRemocao.Remove(indiceEComercial));

            ////<nome:=<valor>
            //string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
            //string nomeArgumento = "moedaDestino=";

            //int indice = palavra.IndexOf(nomeArgumento);
            //Console.WriteLine("string original: " + palavra);
            //Console.WriteLine("string com IndexOf de nomeArgumento: " + indice);
            //Console.WriteLine("Tamanho da string moedaDestino: " + nomeArgumento.Length);

            //Console.WriteLine("string com a substring de palavra e indice: " + palavra.Substring(indice));
            //Console.WriteLine("string com a substring de palavra e indice + nomeArgumento.Length + 1 : " + palavra.Substring(indice + nomeArgumento.Length));



            ////Testando o IsNullOrEmpty
            //Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            //Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            //Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
            //Console.ReadLine();

            //ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

            //string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            //int indiceInterrogacao = url.IndexOf('?');

            //Console.WriteLine(indiceInterrogacao);

            //Console.WriteLine(url);
            //string argumentos = url.Substring(indiceInterrogacao + 1);
            //Console.WriteLine(argumentos);


            //Console.ReadLine();
        }
    }


}

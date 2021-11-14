using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //CalcularBonificacao();
            UsarSistema();
        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor Roberta = new Diretor("159.753.398-04");
            Roberta.Nome = "Roberta";
            Roberta.Senha = "123";

            GerenteDeConta Camila = new GerenteDeConta("326.985.628-89");
            Camila.Nome = "Camila";
            Camila.Senha = "abc";

            ParceiroComercial parceiroComercial = new ParceiroComercial();
            parceiroComercial.Senha = "123456";

            sistemaInterno.Logar(Roberta, "123");
            sistemaInterno.Logar(Camila, "abc");
            sistemaInterno.Logar(parceiroComercial, "123456");
        }
        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Designer Pedro = new Designer("833.222.048-39");
            Pedro.Nome = "Pedro";

            Diretor Roberta = new Diretor("159.753.398-04");
            Roberta.Nome = "Roberta";

            Auxiliar Igor = new Auxiliar("981.198.778-53");
            Igor.Nome = "Igor";

            GerenteDeConta Camila = new GerenteDeConta("326.985.628-89");
            Camila.Nome = "Camila";

            Desenvolvedor Thales = new Desenvolvedor("164.005.367.01");
            Thales.Nome = "Thales";

            gerenciadorBonificacao.Registrar(Pedro);
            gerenciadorBonificacao.Registrar(Roberta);
            gerenciadorBonificacao.Registrar(Igor);
            gerenciadorBonificacao.Registrar(Camila);
            gerenciadorBonificacao.Registrar(Thales);

            Console.WriteLine("Total de bonificação pór mês " + gerenciadorBonificacao.GetTotalBonificacao());
        }
    }
}

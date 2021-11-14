using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no método Main");
            }
        }

        private static void CarregarContas()
        {
            using (LeitorDeArquivos leitor = new LeitorDeArquivos("teste.txt"))
            {
                leitor.LerProximaLinha();
            }
                        
            //-------------------------------

        //    LeitorDeArquivos leitor = null;
        //    try
        //    {
        //        leitor = new LeitorDeArquivos("contasl.txt");
        //        leitor.LerProximaLinha();
        //    }
        //    finally
        //    {
        //        Console.WriteLine("executando finally");
        //        if(leitor != null)
        //        {
        //            leitor.Fechar();
        //        }
        //    }
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente c1 = new ContaCorrente(121, 1564984);
                ContaCorrente c2 = new ContaCorrente(211, 156749874);

                //c.Transferir(10000, c2);
                c1.Sacar(10000);

            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //Console.WriteLine("Informações da InnerException (exceção interna): ");
                //Console.WriteLine(e.InnerException.Message);
                //Console.WriteLine(e.InnerException.StackTrace);
            }

            Console.WriteLine("Execução Finalizada!");
        }

        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        //private static void Metodo()
        //{
        //    TestaDivisao(0);
        //}

        //private static void TestaDivisao(int divisor)
        //{
        //    try
        //    {
        //        int resultado = Dividir(10, divisor);
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        Console.WriteLine("Fui capturado pelo (NullReferenceExeption e)");
        //        Console.WriteLine(e.StackTrace);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Fui capturado pelo (Exception e)");
        //        Console.WriteLine(e.StackTrace);
        //    }
        //}

        //private static int Dividir(int numero, int divisor)
        //{
        //    try
        //    {
        //        return numero / divisor;
        //    }
        //    catch (DivideByZeroException)
        //    {
        //        Console.WriteLine("Não é possível dividir po 0 --- número: " + numero + "divisor " + divisor);
        //        throw;
        //    }
        //}
    }
}

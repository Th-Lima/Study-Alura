using AluraTunes.Data;
using System;
using System.Linq;

namespace AluraTunes.Aula3
{
    /// <summary>
    /// EXECUÇÃO ADIADA E EXECUÇÃO IMEDIATA
    /// </summary>
    public static class Aula3Video1
    {
        public static void Principal()
        {
            using (var contexto = new AluraTunesEntities())
            {
                var mesAniversario = 1;

                while (mesAniversario <= 12)
                {
                    Console.WriteLine("Mês: {0}", mesAniversario);

                    var lista =
                         (from f in contexto.Funcionarios
                          where f.DataNascimento.Value.Month == mesAniversario
                          orderby f.DataNascimento.Value.Month, f.DataNascimento.Value.Day
                          select f).ToList();

                    mesAniversario++;

                    foreach (var item in lista)
                    {
                        Console.WriteLine("{0:dd/MM}\t{1} {2}", item.DataNascimento, item.PrimeiroNome, item.Sobrenome);
                    }
                }
            }
        }
    }
}

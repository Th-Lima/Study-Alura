using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> listaDeInteiros, params T[] itens)
        {
            foreach (T item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }

        static void Teste()
        {

            List<int> lista = new List<int>();


            lista.Add(10);
            lista.Add(10);
            lista.Add(10);
            lista.Add(10);
            lista.Add(10);
          
            lista.AdicionarVarios(10, 10, 11, 50, 23, 85);

            //ListExtensoes<int>.AdicionarVarios(lista, 111, 101, 103, 102, 105, 106);


            List<string> nomes = new List<string>();
            nomes.Add("Thales");

            //ListExtensoes<string>.AdicionarVarios(nomes, "Lucas", "Matheus");

            nomes.AdicionarVarios("Lucas", "João");
        }
    }
}

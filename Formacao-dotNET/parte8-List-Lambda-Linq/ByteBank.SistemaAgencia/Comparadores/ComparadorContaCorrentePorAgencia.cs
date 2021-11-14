using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x != null && y != null)
            {
                return x.Agencia.CompareTo(y.Agencia);
            }

            throw new NullReferenceException();

            //if (x != null && y != null)
            //{
            //    if (x.Agencia < y.Agencia)
            //    {
            //        return -1; //X na frente de Y
            //    }

            //    if (x.Agencia == y.Agencia)
            //    {
            //        return 0; //São equivalentes
            //    }

            //    return 1; //Y fica na frente de X
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Cap3
{
    public class EstadoDoContrato
    {
        public Contrato Contrato { get; private set; }

        public EstadoDoContrato(Contrato contrato)
        {
            Contrato = contrato;
        }
    }
}

using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    class GerenteDeConta : FuncionarioAutenticavel
    {
        public GerenteDeConta(string cpf) : base(4000.00, cpf)
        {
        }
        public override double GetBonificacao()
        {
            return Salario * 0.25;
        }
        public override void AumentarSalarario()
        {
            Salario *= 1.05;
        }
    }
}

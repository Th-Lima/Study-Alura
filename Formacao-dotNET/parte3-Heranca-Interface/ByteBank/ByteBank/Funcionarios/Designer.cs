using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    class Designer : Funcionario
    {
        public Designer(string cpf) : base(3000.00, cpf)
        {
        }
        public override double GetBonificacao()
        {
            return Salario * 0.17;
        }
        public override void AumentarSalarario()
        {
            Salario *= 1.11;
        }
    }
}

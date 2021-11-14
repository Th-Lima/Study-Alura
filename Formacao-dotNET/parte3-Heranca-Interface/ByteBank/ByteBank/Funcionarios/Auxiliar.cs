using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf) : base(2000.00, cpf)
        {
        }
        public override double GetBonificacao()
        {
            return Salario * 0.2;
        }
        public override void AumentarSalarario()
        {
            Salario *= 1.1;
        }
    }
}

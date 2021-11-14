using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    class Diretor : FuncionarioAutenticavel
    {
        public Diretor(string cpf) : base(5000.00, cpf)
        {
            Console.WriteLine("Criando diretor");
        }
        public override double GetBonificacao()
        {
            return Salario * 0.5;
        }
        public override void AumentarSalarario()
        {
            Salario *= 1.15;
        }
    }
}

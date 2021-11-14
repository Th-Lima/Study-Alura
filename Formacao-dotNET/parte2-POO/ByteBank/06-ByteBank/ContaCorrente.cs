using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ByteBank
{
    class ContaCorrente
    {
        private double _saldo = 100.00;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }

        public bool VerificaValorSaldo(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Sacar(double valor)
        {
            VerificaValorSaldo(valor);

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            VerificaValorSaldo(valor);
            
            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _05_ByteBank
{
    class ContaCorrente
    {
        public Cliente Titular;
        public int Agencia;
        public int Numero;
        public double Saldo = 100.00;

        public bool VerificaValorSaldo(double valor)
        {
            if (this.Saldo < valor)
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
            this.VerificaValorSaldo(valor);
            this.Saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            this.VerificaValorSaldo(valor);
            
            this.Saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04_ByteBank
{
    class ContaCorrente
    {
        public string titular;
        public int agencia;
        public int numero;
        public double saldo = 100.00;

        public bool VerificaValorSaldo(double valor)
        {
            if (this.saldo < valor)
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
            this.saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            this.VerificaValorSaldo(valor);
            
            this.saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
       
        public int ContadorTranferenciasNaoPermitidas { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }

        public int Agencia { get; }

        public int Numero { get; }


        private double _saldo = 100;

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


        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if (numeroAgencia <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(numeroAgencia));
            }
            if (numeroConta <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numeroConta));
            }
            Agencia = numeroAgencia;
            Numero = numeroConta;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque: ", nameof(valor));
            }
            
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência: ", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTranferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("OPERAÇÃO INVÁLIDA", ex);
            }

            contaDestino.Depositar(valor);
        }
    }
}

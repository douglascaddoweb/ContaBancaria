using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria
{
    public class Conta
    {
        public string Nome { get; private set; }

        public TipoConta TipoConta { get; private set; }

        public int NumeroConta { get; private set; }

        public decimal Saldo { get; private set; }

        private decimal _limite = 300;

        public decimal Limite { get; private set; }

        public decimal SaldoTotal => Saldo < 0 ? Limite : Saldo + Limite;

        public Conta(string nome, byte tipoConta, int numeroConta, decimal saldo)
        {
            Nome = nome;
            TipoConta = (TipoConta)tipoConta;
            NumeroConta = numeroConta;
            Saldo = saldo;
            Limite = _limite;
        }

        public string GetTipoConta()
        {
            if (TipoConta == TipoConta.PessoaFisica)
                return "Pessoa Física";

            return "Pesso Jurídica";
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            // Saldo = Saldo + valor;
        }

        public bool Sacar(decimal valor)
        {
            if (SaldoTotal < valor)
                return false;

            Saldo -= valor;

            if (Saldo < 0)
            {
                Limite += Saldo;
                // Limite = Limite + Saldo
            }

            return true;
        }

        public void Transferir(decimal valor, Conta conta)
        {
            Sacar(valor);

            conta.Depositar(valor);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Tipo Conta: {GetTipoConta()}, Numero Conta: {NumeroConta}, Saldo: {Saldo}, Limite: {Limite}, Saldo Total: {SaldoTotal}";
        }
    }
}

using System;
using System.Collections.Generic;

namespace ContaBancaria
{
    class Program
    {
        private static List<Conta> _conta { get; set; }

        static void Main(string[] args)
        {
            _conta = new List<Conta>();

            MontarMenu();
            Console.ReadKey();
        }

        public static void MontarMenu()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("             Menu            ");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine("Selecione uma opção:");

            Console.WriteLine("1 - Cadastrar Conta");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Transferir");
            Console.WriteLine("5 - Saldo");
            Console.WriteLine("6 - Listar Contas");
            Console.WriteLine();

            Console.Write("Digite a opção: ");

            int opcao = Convert.ToInt32(Console.ReadLine());
            SelecionarOpcao(opcao);
        }

        public static void SelecionarOpcao(int opcao)
        {
            switch(opcao)
            {
                case 1:
                    CadastrarConta();
                    break;
                case 2:
                    Sacar();
                    break;
                case 3:
                    Depositar();
                    break;
                case 4:
                    Transferir();
                    break;
                case 5:
                    Saldo();
                    break;
                case 6:
                    ListarContas();
                    break;
                default:
                    Console.WriteLine("Opção selecionada é inválida.");
                    MontarMenu();
                    break;
            }

        }

        public static void CadastrarConta()
        {
            Console.WriteLine();
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Tipo de Conta (1-PF, 2-PJ): ");
            byte tipoConta = Convert.ToByte(Console.ReadLine());

            Console.Write("Digite o saldo Inicial: ");
            decimal saldo = Convert.ToDecimal(Console.ReadLine());

            int numeroConta = _conta.Count + 1;

            Conta conta = new Conta(nome, tipoConta, numeroConta, saldo);

            _conta.Add(conta);
            Console.WriteLine();
            Console.WriteLine("Conta criada com sucesso.");
            MontarMenu();
        }

        public static void ValidarContas(int qtd, string msg = "Não exitem contas cadastradas")
        {
            if (_conta.Count == qtd)
            {
                Console.WriteLine(msg);
                MontarMenu();
            }
        }

        public static void Sacar()
        {
            ValidarContas(0, "teste");

            Console.Write("Digite o numero da conta: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o valor: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            Conta conta = _conta.Find(i => i.NumeroConta == numero);

            bool sacou = conta.Sacar(valor);

            if (sacou)
                Console.WriteLine(conta.ToString());
            else
                Console.WriteLine("Você não possui saldo suficiente para sacar.");
            MontarMenu();
        }

        public static void Depositar()
        {
            ValidarContas(0);

            Console.Write("Digite o numero conta: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o Valor: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            Conta conta = _conta.Find(i => i.NumeroConta == numero);

            conta.Depositar(valor);

            Console.WriteLine(conta.ToString());

            MontarMenu();

        }

        public static void ListarContas()
        {
            ValidarContas(0);

            Console.WriteLine();
            foreach(Conta conta in _conta)
            {
                Console.WriteLine(conta.ToString());
            }
            Console.WriteLine();
            MontarMenu();
        }

        public static void Transferir()
        {
            ValidarContas(1);

            Console.Write("Digite a sua conta: ");
            int numeroConta = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a conta do favorecido: ");
            int numeroFavorecido = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o valor: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            Conta conta = _conta.Find(i => i.NumeroConta == numeroConta);

            Conta contaFavorecido = _conta.Find(i => i.NumeroConta == numeroFavorecido);

            conta.Transferir(valor, contaFavorecido);

            Console.WriteLine(conta.ToString());
            Console.WriteLine(contaFavorecido.ToString());

            MontarMenu();
        }

        public static void Saldo()
        {
            ValidarContas(0);

            Console.Write("Digite o numero da conta: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Conta conta = _conta.Find(i => i.NumeroConta == numero);

            Console.WriteLine(conta.ToString());
            MontarMenu();

        }
    }
}
 
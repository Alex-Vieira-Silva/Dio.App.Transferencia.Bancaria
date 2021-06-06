using System;
using System.Collections.Generic;

namespace Dio.App.Transferencia.Bancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = obterContaUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						TransferirConta();
						break;
					case "4":
						SacarConta();
						break;
					case "5":
						DepositarConta();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = obterContaUsuario();
          
            }

                Console.WriteLine("Obrigado por utilizar os nossos serviços.");
                Console.ReadLine();
        }

        private static void DepositarConta()
        {
            Console.Write("Digite o número da conta: ");
            int _numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double _valorDepositado = double.Parse(Console.ReadLine());

            listaContas[_numeroConta].Depositar(_valorDepositado);
        }

        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Sacar(valorSaque);

        }

        private static void TransferirConta()
        {
            Console.Write("Digite o número da conta de origem: ");
            int _contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int _contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double _valorTransferido = double.Parse(Console.ReadLine());

            listaContas[_contaOrigem].Transferir(_valorTransferido, listaContas[_contaDestino]);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            Console.WriteLine();
 
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Conta não cadastrada.");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("# {0} ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("-------Abrir um nova conta!--------");
            Console.WriteLine();
            Console.Write("Digite 1 para conta fisica e 2 para conta jurídica. ");
            int opcaoDesejada = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o nome do cliente: ");
            string obterNome = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Digite o saldo inicial: ");
            double obterSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Digite o crédito: ");        
            double obterCredito = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Conta novaConta = new Conta(_TipoConta: (TipoConta)opcaoDesejada,
                                         _nome: obterNome,
                                         _credito: obterCredito,
                                         _saldo: obterSaldo);

            listaContas.Add(novaConta);


        }

        private static string obterContaUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("--------Sistema Bancário----------");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada!");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

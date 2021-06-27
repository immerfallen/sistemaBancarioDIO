using System;
using System.Collections.Generic;

namespace DIO_Bank
{
    class Program
    {

        
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario();

          while(opcaoUsuario.ToUpper() != "X"){
              switch (opcaoUsuario){
                  case "1":
                    ListarContas();
                    break;
                   case "2":
                   InserirConta();
                    break;
                   case "3":
                    //Transferir();
                    break;
                   case "4":
                    Sacar();
                    break;
                   case "5":
                    //Depositar();
                    break;
                   case "C":
                   Console.Clear();
                    break;
                    default:
                       throw new ArgumentOutOfRangeException();
              }
              opcaoUsuario = ObterOpcaoUsuario();
          }
          Console.WriteLine("Obrigado por utilizar nossos serviços.");
          Console.ReadLine();
        }

        
        private static void InserirConta(){
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta física ou 2 para conta jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente ");
            string  entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial ");
            double  entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito ");
            double  entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, nome:entradaNome,
            saldo: entradaSaldo, credito: entradaCredito);
            listaContas.Add(novaConta);
        }

        public static void ListarContas(){
            Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
            for(int i =0; i <listaContas.Count;i++){
                Conta conta = listaContas[i];
                Console.Write($"{i} - ");
                Console.WriteLine(conta);
            }
        }

        public static void Sacar(){
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");



            string opcaoUsuario  = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
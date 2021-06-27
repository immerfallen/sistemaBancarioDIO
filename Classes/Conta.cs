using System;


namespace DIO_Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set;}
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito){
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;

           
        }

         public bool Sacar(double valorSaque){
             //Validacao de saldo
             if(this.Saldo - valorSaque <(this.Credito*-1)){
                 Console.WriteLine("Saldo insuficiente!!!");
                 return false;
             }
             this.Saldo -= valorSaque;

             Console.WriteLine($"Seu saldo atual é de R$ {this.Saldo}.");     

             return true; 
                
         }
        
        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;

             Console.WriteLine($"Seu saldo atual é de R$ {this.Saldo}.");  

        }

        public void Transferir(double valorTranferencia, Conta contaDestino){
            if(this.Sacar(valorTranferencia)){
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de conta " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Credito: R$ " + this.Credito;

            return retorno;
        }
    }
}
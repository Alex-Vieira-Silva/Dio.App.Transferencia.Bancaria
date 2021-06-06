using System;

namespace Dio.App.Transferencia.Bancaria
{
    public class Conta 
    {
        private TipoConta TipoConta{get; set;}
        private string nome{get; set;}
        private double saldo{get; set;}
        private double credito{get; set;}
        
        public Conta(TipoConta _TipoConta, string _nome, double _saldo, double _credito)
        {
            this.TipoConta = _TipoConta;
            this.nome = _nome;
            this.saldo = _saldo;
            this.credito = _credito;
        }

        public Conta()
        {
        }

        public bool Sacar(double valorSacar)
        {
            if(this.saldo - valorSacar < (this.credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            
                this.saldo -= valorSacar;
                Console.WriteLine("O saldo da conta de {0} é {1}", this.nome, this.saldo);
                return true;
        
        }

        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;
            Console.WriteLine("O Saldo da conta de {0} é {1}", this.nome, this.saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Credito " + this.credito + " | ";
            return retorno;

        } 

    }
}
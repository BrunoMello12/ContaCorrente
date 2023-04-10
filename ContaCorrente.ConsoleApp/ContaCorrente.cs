using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public decimal saldo;
        public int numero;
        public bool ehEspecial;
        public decimal limite;
        public ArrayList movimentacoes = new ArrayList();

        public decimal Sacar(int quantidade)
        {
            if(quantidade > limite + saldo)
            {
                Console.WriteLine("Não foi possível fazer o saque!");
            }
            else
            {
                saldo -= quantidade;
                movimentacoes.Add($"Saque de: {quantidade}");
                movimentacoes.Add($"Saldo Atual: {saldo}");
            }
            return saldo;
        }

        public decimal Depositar(int quantidade)
        {
            saldo += quantidade;
            movimentacoes.Add($"Deposito de: {quantidade}");
            movimentacoes.Add($"Saldo Atual: {saldo}");
            return saldo;
            
        }

        public decimal TransferirPara(ContaCorrente conta, int quantidade)
        {
            conta.Depositar(quantidade);
            movimentacoes.Add($"Transferência de: {quantidade}");
            movimentacoes.Add($"Saldo Atual: {saldo-quantidade}");
            return saldo;
        }

        public void MostrarExtrato(string conta)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Extrato {conta}: ");
            Console.WriteLine("------------------------------------------------");
            foreach (string extrato in movimentacoes)
            {
                Console.WriteLine(extrato);
            }
        }
    }
}

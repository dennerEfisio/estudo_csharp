using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Produto
    {
        private static int id;
        private string nome;
        private int quantidadeDisponivel;
        private double valor;

        public Produto(string nome, int quantidade, double valor)
        {
            this.nome = nome;
            this.quantidadeDisponivel = quantidade;
            this.valor = valor;
            id = id + 1;

        }

        public string Nome { get => nome; set => nome = value; }
        public int QuantidadeDisponivel { get => quantidadeDisponivel; set => quantidadeDisponivel = value; }
        public double Valor { get => valor; set => valor = value; }
    }
}

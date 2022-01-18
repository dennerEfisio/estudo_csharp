using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Venda
    {
        private static int id;
        private Produto produtoVendido;
        private Cliente comprador;
        private int desconto;
        private double valor;

        public Venda(Produto produtoVendido, Cliente comprador, int quantidade)
        {
            if(produtoVendido.QuantidadeDisponivel > quantidade)
            {
                this.ProdutoVendido = produtoVendido;
                this.Comprador = comprador;
                this.valor = produtoVendido.Valor * quantidade;
                id = id + 1;
            }
            else
            {
                Console.WriteLine("Não possuímos esta quantidade de produtos no estoque");
                return;  //refator para exception
            }
        }

        public Venda(Produto produtoVendido, Cliente comprador, int quantidade, int desconto)
        {
          if(desconto > 0 && desconto < 30)
            {
                if (produtoVendido.QuantidadeDisponivel > quantidade)
                {
                    this.ProdutoVendido = produtoVendido;
                    this.Comprador = comprador;
                    this.Valor = (produtoVendido.Valor * quantidade) - ((produtoVendido.Valor * quantidade) * (desconto/100));
                    id = id + 1;
                }
                else
                {
                    Console.WriteLine("Não possuímos esta quantidade de produtos no estoque");
                    return;  //refator para exception
                }
            }
          else
            {
                Console.WriteLine("Desconto requisitado não cumpre as regras de negocio");
                return; //refatorar para exception
            }

        }

        public int Desconto { get => desconto; set => desconto = value; }
        public double Valor { get => valor; set => valor = value; }
        internal Produto ProdutoVendido { get => produtoVendido; set => produtoVendido = value; }
        internal Cliente Comprador { get => comprador; set => comprador = value; }
    }
}

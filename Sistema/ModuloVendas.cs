using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ModuloVendas
    {
        public void MenuVendas(List<Cliente> listaCliente, List<Produto> listaProdutos, List<Venda> listaVendas)
        {
            int opcao;

            while (true)
            {
                Console.WriteLine("Modulo de vendas:");
                Console.WriteLine("Digite 1 para cadastrar uma nova venda");
                Console.WriteLine("Digite 2 para para listar as vendas cadastradas");
                Console.WriteLine("Digite 3 para deletar uma venda");
                Console.WriteLine("Digite 4 para editar uma venda");
                Console.WriteLine("Digite 0 voltar ao menu principal \n");

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    throw;
                }

                switch (opcao)
                {
                    case 1:

                        AdicionarVenda(listaCliente, listaProdutos, listaVendas);
                        break;

                    case 2:
                        //ListarVendas(listaCliente, listaProdutos);
                        break;

                    case 3:
                        //RemoverVenda(listaCliente, listaProdutos);
                        break;

                    case 4:
                        //AtualizarVenda(listaCliente, listaProdutos);
                        break;

                    default:
                        Console.WriteLine("Retornando ao menu principal...");
                        break;
                }
                if (opcao == 0)
                {
                    return; //um jeito mais elegante?
                }
            }
        }
        void AdicionarVenda(List<Cliente> listaCliente, List<Produto> listaProduto, List<Venda> listaVenda)
        {
            int desconto, quantidade;
            double valor;
            string nomeProduto, nomeCliente, houveDesconto;

            Console.WriteLine("Digite o nome do Produto vendido:");
            nomeProduto = Console.ReadLine();

            var produto = listaProduto.FirstOrDefault(x => x.Nome == nomeProduto);
            if (produto == null)
            {
                Console.WriteLine("Produto nulo ou não encontrado, retornando ao menu... \n"); //melhorar isso aqui
                return;
            }

            Console.WriteLine("Digite o nome do Cliente que comprou:");
            nomeCliente = Console.ReadLine();

            var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);
            if (produto == null)
            {
                Console.WriteLine("Cliente nulo ou não encontrado, retornando ao menu... \n"); //melhorar isso aqui
                return;
            }

            Console.WriteLine("Digite a quantidade do produto vendido:");
            try
            {
                quantidade = Convert.ToInt32(Console.ReadLine());

                if (quantidade < produto.QuantidadeDisponivel)
                {
                    Console.WriteLine("O produto não possui esta quantidade em estoque, retorenando ao menu"); //melhorar isso aqui
                }
            }
            catch
            {
                throw;
            }

            Console.WriteLine("Digite o valor do produto vendido:");
            try
            {
                valor = float.Parse(Console.ReadLine());
            }
            catch
            {
                throw;
            }

            Console.WriteLine("Houve desconto na venda? S/N");
            houveDesconto = Console.ReadLine();

            if (houveDesconto == "S")
            {
                Console.WriteLine("Qual o valor do desconto em %?");
                try
                {
                    desconto = Convert.ToInt32(Console.ReadLine());
                    Venda venda = new Venda(produto,cliente,quantidade,desconto);
                    listaVenda.Add(venda);
                }
                catch
                {
                    throw;
                }


            }
            else if (houveDesconto == "N")
            {
                Venda venda = new Venda(produto, cliente, quantidade);
                listaVenda.Add(venda);
            }
            else
            {
                Console.WriteLine("Valor digitado incorreto (deve ser S ou N), retornando ao menu...");
                return;
            }

        }

    }
}

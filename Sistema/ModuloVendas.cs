using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ModuloVendas
    {
        public void MenuVendas(List<Cliente> listaCliente, List<Produto> listaProdutos, List<Venda> listaVenda)
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

                        AdicionarVenda(listaCliente, listaProdutos, listaVenda);
                        break;

                    case 2:
                        ListarVendas(listaVenda);
                        break;

                    case 3:
                        RemoverVenda(listaCliente, listaProdutos, listaVenda);
                        break;

                    case 4:
                        AtualizarVenda(listaCliente, listaProdutos, listaVenda);
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

        void RemoverVenda(List<Cliente> listaCliente, List<Produto> listaProduto, List<Venda> listaVenda)
        {
            string nomeProduto, nomeCliente;

            Console.WriteLine("Digite o nome do cliente que comprou o produto:");
            nomeCliente = Console.ReadLine();

            var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);

            Console.WriteLine("Digite o nome do produto vendido:");
            nomeProduto = Console.ReadLine();

            var produto = listaProduto.FirstOrDefault(x => x.Nome == nomeProduto);

            var venda = listaVenda.FirstOrDefault( v => v.Comprador.Nome == nomeCliente && v.ProdutoVendido.Nome == nomeProduto);

            if (venda != null)
            {
                listaVenda.Remove(venda);
                Console.WriteLine("Venda removida com sucesso! \n");
            }
            else
                Console.WriteLine("Venda nulo ou não encontrada \n");
        }

        void ListarVendas(List<Venda> listaVenda)
        {
            Console.WriteLine("Listando produtos:");
            foreach (Venda venda in listaVenda)
            {
                Console.WriteLine($"Produto {venda.ProdutoVendido} vendido ao cliente {venda.Comprador}");
            }
            Console.WriteLine("Fim da listagem \n");
        }

        void AtualizarVenda(List<Cliente> listaCliente, List<Produto> listaProduto, List<Venda> listaVenda)
        {
            string nomeProduto, nomeCliente;
            float valor;

            Console.WriteLine("Digite o nome do produto vendido que será atualizado:");
            nomeProduto = Console.ReadLine();

            Console.WriteLine("Digite o nome do cliente comprador que será atualizado:");
            nomeCliente = Console.ReadLine();

            var venda = listaVenda.FirstOrDefault(v => v.Comprador.Nome == nomeCliente && v.ProdutoVendido.Nome == nomeProduto);

            if (venda != null)
            {
                Console.WriteLine("Digite o nome atualizado do produto vendido: ");
                nomeProduto = Console.ReadLine();

                var produto = listaProduto.FirstOrDefault(x => x.Nome == nomeProduto);

                if(produto != null)
                    venda.ProdutoVendido = produto;
                else
                {
                    Console.WriteLine("Produto não encontrado ou não cadastrado, retornando ao menu...");
                    return;
                }

                Console.WriteLine("Digite o nome atualizado do cliente comprador: ");
                nomeCliente = Console.ReadLine();

                var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);

                if (cliente != null)
                    venda.Comprador = cliente;
                else
                {
                    Console.WriteLine("Produto não encontrado ou não cadastrado, retornando ao menu...");
                    return;
                }

                Console.WriteLine("Digite o novo valor da venda: ");
                try
                {
                    valor = float.Parse(Console.ReadLine());
                    venda.Valor = valor;
                }
                catch
                {
                    throw;
                }

                Console.WriteLine("Venda atualizada com sucesso! \n");
            }
            else
                Console.WriteLine("Venda nula ou não encontrada");

        }

    }
}

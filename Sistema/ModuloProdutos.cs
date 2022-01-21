using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ModuloProdutos
    {
        public void MenuProduto(List<Produto> listaProduto)
        {
            int opcao;

            while (true)
            {
                Console.WriteLine("Modulo de produtos:");
                Console.WriteLine("Digite 1 para cadastrar um novo produto");
                Console.WriteLine("Digite 2 para para listar os produtos cadastrados");
                Console.WriteLine("Digite 3 para deletar um produto");
                Console.WriteLine("Digite 4 para editar um produto");
                Console.WriteLine("Digite 0 voltar ao menu principal \n");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:

                        AdicionarProduto(listaProduto);
                        break;

                    case 2:
                        ListarProdutos(listaProduto);
                        break;

                    case 3:
                        RemoverProduto(listaProduto);
                        break;

                    case 4:
                        AtualizarProduto(listaProduto);
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

        void AdicionarProduto(List<Produto> listaProduto) 
        {
            string nome;
            int quantidadeDisponivel;
            double valor;

            Console.WriteLine("Digite o nome do novo produto:");
            nome = Console.ReadLine();

            Console.WriteLine("Digite a quantidade disponivel no estoque deste produto:");
            try
            {
                quantidadeDisponivel = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw;
            }

            Console.WriteLine("Digite o valor do produto em reais:");
            try
            {
                valor = float.Parse(Console.ReadLine());
            }
            catch
            {
                throw;
            }

            Produto produto = new Produto(nome, quantidadeDisponivel, valor);
            if (listaProduto.Contains(produto))
            {
                Console.WriteLine("Produto já cadastrado, retornando ao menu...");
            }
            else
            {
                listaProduto.Add(produto);
                Console.WriteLine("Produto adicionado com sucesso! \n");
            }
        }

        void RemoverProduto(List<Produto> listaProduto)
        {
            string nomeProduto;

            Console.WriteLine("Digite o nome do produto a ser deletado:");
            nomeProduto = Console.ReadLine();

            var produto = listaProduto.FirstOrDefault(x => x.Nome == nomeProduto);
            if (produto != null)
            {
                listaProduto.Remove(produto);
                Console.WriteLine("Produto removido com sucesso! \n");
            }
            else
                Console.WriteLine("Produto nulo ou não encontrado \n");
        }

        void ListarProdutos(List<Produto> listaProduto)
        {
            Console.WriteLine("Listando produtos:");
            foreach (Produto produto in listaProduto)
            {
                Console.WriteLine($"{produto.Nome}");
            }
            Console.WriteLine("Fim da listagem \n");
        }

        void AtualizarProduto(List<Produto> listaProduto)
        {
            string nomeProduto, auxiliar;
            int quantidade;
            float valor;

            Console.WriteLine("Digite o nome do produto a ser deletado:");
            nomeProduto = Console.ReadLine();

            var produto = listaProduto.FirstOrDefault(x => x.Nome == nomeProduto);
            if (produto != null)
            {
                Console.WriteLine("Digite o novo nome para o produto: ");
                auxiliar = Console.ReadLine();
                produto.Nome = auxiliar;

                Console.WriteLine("Digite o novo cpf do produto: ");
                try
                {
                    quantidade = Convert.ToInt32(Console.ReadLine());
                    produto.QuantidadeDisponivel = quantidade;
                }
                catch
                {
                    throw;
                }

                Console.WriteLine("Digite o novo email do produto: ");
                try
                {
                    valor = float.Parse(Console.ReadLine());
                    produto.Valor = valor;
                }
                catch
                {
                    throw;
                }
                Console.WriteLine("Produto atualizado com sucesso! \n");
            }
            else
                Console.WriteLine("Produto nulo ou não encontrado");


        }
    }
}

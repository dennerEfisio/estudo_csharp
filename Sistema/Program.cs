using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> listaCliente = new List<Cliente>();
            List<Produto> listaProduto = new List<Produto>();

            ModuloProdutos moduloProdutos = new ModuloProdutos();
            ModuloClientes moduloClientes = new ModuloClientes();

            int opcao;

            while (true)
            {
                Console.WriteLine("Escolha uma operação para ser executada:");
                Console.WriteLine("Digite 1 para acessar o modulo de clientes");
                Console.WriteLine("Digite 2 para acessar o modulo de produtos");
                Console.WriteLine("Digite outro para sair \n");

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Opção inválida: deve ser um numero inteiro");
                    throw;   
                }

                switch (opcao)
                {
                    case 1:
                        moduloClientes.MenuCliente(listaCliente);
                        break;
                    case 2:
                        moduloProdutos.MenuProduto(listaProduto);
                        break;
                    default:
                        Console.WriteLine("Retornando ao menu principal");
                        break;
                }
            }

        }
    }
}

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
            List<Cliente> ListaCliente = new List<Cliente>();

            int opcao;
            while (true)
            {
                Console.WriteLine("Escolha uma operação para ser executada:");
                Console.WriteLine("Digite 1 para acessar o modulo de clientes");
                Console.WriteLine("Digite 2 para acessar o modulo de produtos");
                Console.WriteLine("Digite outro para sair \n");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        menuCliente(ListaCliente);
                        break;
                    case 2:
                        Console.WriteLine("modulo de produtos");
                        break;
                    default:
                        Console.WriteLine("Retornando ao menu principal");
                        break;
                }
            }

        }
    }
}

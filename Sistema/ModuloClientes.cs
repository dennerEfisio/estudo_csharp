using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ModuloClientes
    {
        public void menuCliente(List<Cliente> listaCliente)
        {
            int opcao;
            string nome, cpf, email;

            Console.WriteLine("Modulo de clientes:");
            Console.WriteLine("Digite 1 para cadastrar um novo cliente");
            Console.WriteLine("Digite 2 para para listar os clientes cadastrados");
            Console.WriteLine("Digite 3 para deletar um cliente");
            Console.WriteLine("Digite 4 para editar um cliente");
            Console.WriteLine("Digite 0 voltar ao menu principal");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o nome do novo cliente:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite o email do novo cliente:");
                    email = Console.ReadLine();
                    Console.WriteLine("Digite o cpf do novo cliente:");
                    cpf = Console.ReadLine();
                    Cliente cliente = new Cliente(nome, cpf, email);
                    adicionarCliente(listaCliente, cliente);
                    break;

                case 2:
                    listarClientes(listaCliente);
                    break;

                case 3:
                    //pesquisar por busca pelo id
                    break;

                case 4:
                    //implementar função e fazer chamada
                    break;

                default:
                    Console.WriteLine("Retornando ao menu principal");
                    break;
            }
            if(opcao == 0)
            {
                return; //um jeito mais elegante?
            }
        }

        void adicionarCliente(List<Cliente> listaCliente, Cliente cliente)
        {
            listaCliente.Add(cliente);
        }

        void removerCliente(List<Cliente> listaCliente, Cliente cliente)
        {
            listaCliente.Remove(cliente);
        }

        void listarClientes(List<Cliente> listaCliente)
        {
            foreach(Cliente cliente in listaCliente)
            {
                Console.WriteLine($"{cliente.Nome}\n"); // esclarecer com o Wesley formas de impressão de strings
            }
        }




    }
}

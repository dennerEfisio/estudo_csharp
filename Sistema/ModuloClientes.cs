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

                    adicionarCliente(listaCliente);
                    break;

                case 2:
                    listarClientes(listaCliente);
                    break;

                case 3:
                    removerCliente(listaCliente);
                    break;

                case 4:
                    atualizarClientes(listaCliente);
                    break;

                default:
                    Console.WriteLine("Retornando ao menu principal...");
                    break;
            }
            if(opcao == 0)
            {
                return; //um jeito mais elegante?
            }
        }

        void adicionarCliente(List<Cliente> listaCliente)
        {
            string nome, cpf, email;

            Console.WriteLine("Digite o nome do novo cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email do novo cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o cpf do novo cliente:");
            cpf = Console.ReadLine();
            Cliente cliente = new Cliente(nome, cpf, email);
            listaCliente.Add(cliente);
        }

        void removerCliente(List<Cliente> listaCliente)
        {
            string nomeCliente;

            Console.WriteLine("Digite o nome do cliente a ser deletado:");
            nomeCliente = Console.ReadLine();

            var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);
            if (cliente != null)
                listaCliente.Remove(cliente);
            else
                Console.WriteLine("Cliente nulo ou não encontrado");
        }

        void listarClientes(List<Cliente> listaCliente)
        {
            foreach(Cliente cliente in listaCliente)
            {
                Console.WriteLine($"{cliente.Nome}\n"); // esclarecer com o Wesley formas de impressão de strings
            }
        }

        void atualizarClientes(List<Cliente> listaCliente)
        {
            string nomeCliente, auxiliar;

            Console.WriteLine("Digite o nome do cliente a ser deletado:");
            nomeCliente = Console.ReadLine();

            var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);
            if (cliente != null)
            {
                Console.WriteLine("Digite o novo nome para o Cliente: ");
                auxiliar = Console.ReadLine();
                cliente.Nome = auxiliar;

                Console.WriteLine("Digite o novo cpf do Cliente: ");
                auxiliar = Console.ReadLine();
                cliente.Cpf = auxiliar;

                Console.WriteLine("Digite o novo email do Cliente: ");
                auxiliar = Console.ReadLine();
                cliente.Email = auxiliar;
            }
            else
                Console.WriteLine("Cliente nulo ou não encontrado");


        }




    }
}

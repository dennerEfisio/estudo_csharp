using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ModuloClientes
    {
        public void MenuCliente(List<Cliente> listaCliente)
        {
            int opcao;

            while (true)
            {
                Console.WriteLine("Modulo de clientes:");
                Console.WriteLine("Digite 1 para cadastrar um novo cliente");
                Console.WriteLine("Digite 2 para para listar os clientes cadastrados");
                Console.WriteLine("Digite 3 para deletar um cliente");
                Console.WriteLine("Digite 4 para editar um cliente");
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

                        AdicionarCliente(listaCliente);
                        break;

                    case 2:
                        ListarClientes(listaCliente);
                        break;

                    case 3:
                        RemoverCliente(listaCliente);
                        break;

                    case 4:
                        AtualizarClientes(listaCliente);
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

        void AdicionarCliente(List<Cliente> listaCliente)
        {
            string nome, cpf, email;

            Console.WriteLine("Digite o nome do novo cliente:");
            nome = Console.ReadLine();

            Console.WriteLine("Digite o email do novo cliente:");
            email = Console.ReadLine();

            Console.WriteLine("Digite o cpf do novo cliente:");
            cpf = Console.ReadLine();

            Cliente cliente = new Cliente(nome, cpf, email);

            if (listaCliente.Contains(cliente))
            {
                Console.WriteLine("Cliente já cadastrado, retornando ao menu...");
            }
            else
            {
                listaCliente.Add(cliente);

                Console.WriteLine("Cliente adicionado com sucesso! \n");
            }
        }

        void RemoverCliente(List<Cliente> listaCliente)
        {
            string nomeCliente;

            Console.WriteLine("Digite o nome do cliente a ser deletado:");
            nomeCliente = Console.ReadLine();

            var cliente = listaCliente.FirstOrDefault(x => x.Nome == nomeCliente);
            if (cliente != null)
            {
                listaCliente.Remove(cliente);
                Console.WriteLine("Cliente removido com sucesso! \n");
            }
            else
                Console.WriteLine("Cliente nulo ou não encontrado \n");
        }

        void ListarClientes(List<Cliente> listaCliente)
        {
            Console.WriteLine("Listando clientes:");
            foreach (Cliente cliente in listaCliente)
            {
                Console.WriteLine($"{cliente.Nome}");
            }
            Console.WriteLine("Fim da listagem \n");
        }

        void AtualizarClientes(List<Cliente> listaCliente)
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

                Console.WriteLine("Cliente atualizado com sucesso! \n");
            }
            else
                Console.WriteLine("Cliente nulo ou não encontrado");


        }




    }
}

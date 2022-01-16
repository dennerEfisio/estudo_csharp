using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Cliente
    {
        private static int id;
        private string nome, cpf, email;

        Cliente(string nome, string cpf, string email)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.email = email;
            id = id + 1;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
    
    }
}

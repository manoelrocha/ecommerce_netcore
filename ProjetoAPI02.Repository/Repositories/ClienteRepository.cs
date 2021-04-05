using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoAPI02.Repository.Repositories
{
    public class ClienteRepository
        : BaseRepository<Cliente>, IClienteRepository
    {
        private SqlServerContext context;

        public ClienteRepository(SqlServerContext context) : base(context)
        {
            this.context = context;
        }

        public Cliente GetByEmail(string email)
        {
            return context.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente GetByCpf(string cpf)
        {
            return context.Cliente
                    .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }

        public Cliente GetByEmailSenha(string email, string senha)
        {
            return context.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email)
                                      && c.Senha.Equals(senha));
        }
    }
}

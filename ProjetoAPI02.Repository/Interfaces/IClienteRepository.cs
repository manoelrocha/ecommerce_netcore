using ProjetoAPI02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByEmail(string email);
        Cliente GetByCpf(string cpf);
        Cliente GetByEmailSenha(string email, string senha);
    }
}

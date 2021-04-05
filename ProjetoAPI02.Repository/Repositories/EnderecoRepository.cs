using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Repositories
{
    public class EnderecoRepository
        : BaseRepository<Endereco>, IEnderecoRepository
    {
        private SqlServerContext context;

        public EnderecoRepository(SqlServerContext context) : base(context)
        {
            this.context = context;
        }
    }
}

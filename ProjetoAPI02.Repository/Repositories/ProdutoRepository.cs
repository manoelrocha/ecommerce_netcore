using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Repositories
{
    public class ProdutoRepository 
        : BaseRepository<Produto>, IProdutoRepository
    {
        private SqlServerContext context;

        public ProdutoRepository(SqlServerContext context) : base(context)
        {
            this.context = context;
        }
    }
}

using Microsoft.EntityFrameworkCore.Storage;
using ProjetoAPI02.Repository.Contexts;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlServerContext context;
        private IDbContextTransaction transaction;

        public UnitOfWork(SqlServerContext context)
        {
            this.context = context;
        }

        public void BeginTransaction() //abrindo uma transação..
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit() //confirmando e fechando a transação
        {
            transaction.Commit();
        }

        public void Rollback() //desfazer as operações da transação
        {
            transaction.Rollback();
        }

        public IClienteRepository ClienteRepository => new ClienteRepository(context);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(context);

        public IPedidoRepository PedidoRepository => new PedidoRepository(context);

        public IItemPedidoRepository ItemPedidoRepository => new ItemPedidoRepository(context);

        public IEnderecoRepository EnderecoRepository => new EnderecoRepository(context);
    }
}

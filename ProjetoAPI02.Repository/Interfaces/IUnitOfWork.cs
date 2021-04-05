using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Repository.Interfaces
{
    /*
     * UnitOfWork -> Unidade de trabalho
     * Componente para gerenciar todos os repositorios e as
     * transações realizadas no contexto do banco de dados
     */ 
    public interface IUnitOfWork
    {
        //métodos abstratos!
        void BeginTransaction();
        void Commit();
        void Rollback();

        //método para acessar cada repositorio..
        IClienteRepository ClienteRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IItemPedidoRepository ItemPedidoRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
    }
}

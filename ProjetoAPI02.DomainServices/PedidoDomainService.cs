using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjetoAPI02.DomainServices
{
    public class PedidoDomainService
    {
        private IUnitOfWork unitOfWork;

        public PedidoDomainService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Método para executar o cadastro de um Pedido no ECommerce
        /// </summary>
        /// <param name="pedido">Entidade contendo os dados do pedido</param>
        /// <param name="itemPedido">Coleção de objetos que compoem os itens do pedido</param>
        /// <param name="cliente">Entidade contendo os dados do Cliente relacionado ao Pedido</param>
        public void CadastrarPedido(Pedido pedido, List<ItemPedido> itemPedido, Cliente cliente)
        {
            try
            {
                unitOfWork.BeginTransaction();

                if (unitOfWork.ClienteRepository.GetById(cliente.IdCliente) == null)
                    unitOfWork.ClienteRepository.Insert(cliente);

                pedido.IdCliente = cliente.IdCliente;

                unitOfWork.PedidoRepository.Insert(pedido);

                foreach (var item in itemPedido)
                {
                    item.IdPedido = pedido.IdPedido;
                    unitOfWork.ItemPedidoRepository.Insert(item);
                }

                unitOfWork.Commit(); 
            }
            catch(Exception e)
            {
                unitOfWork.Rollback();
                throw new Exception(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Domain.Entities
{
    public class ItemPedido
    {
        public Guid IdItemPedido { get; set; }        
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}

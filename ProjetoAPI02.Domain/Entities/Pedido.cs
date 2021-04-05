using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Domain.Entities
{
    public class Pedido
    {
        public Guid IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdCliente { get; set; }

        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}

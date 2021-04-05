using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Domain.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        public List<ItemPedido> ItensPedido { get; set; }
    }
}

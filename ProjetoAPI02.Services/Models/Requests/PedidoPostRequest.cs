using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models.Requests
{
    public class PedidoPostRequest
    {
        [Required(ErrorMessage = "Por favor, informe a data do pedido.")]
        public string DataPedido { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor do pedido.")]
        public string ValorPedido { get; set; }
        public List<ItemPedidoPostRequest> ItemPedidos { get; set; }
    }
}

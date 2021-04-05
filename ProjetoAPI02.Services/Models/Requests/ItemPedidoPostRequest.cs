using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models.Requests
{
    public class ItemPedidoPostRequest
    {
        [Required(ErrorMessage = "Por favor, informe o Id do Produto.")]
        public string IdProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade.")]
        public int Quantidade { get; set; }
    }
}

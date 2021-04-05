using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models.Requests
{
    public class EnderecoPostRequest
    {
        [Required(ErrorMessage = "Informe o logradouro.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o numero.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o complemento.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o cep.")]
        public string Cep { get; set; }
    }
}

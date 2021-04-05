using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models.Requests
{
    public class ClientePostRequest
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Cpf { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Confirme a senha.")]
        public string SenhaConfirmacao { get; set; }

        public List<EnderecoPostRequest> Enderecos { get; set; }
    }
}

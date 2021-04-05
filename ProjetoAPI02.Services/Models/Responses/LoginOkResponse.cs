using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Models.Responses
{
    public class LoginOkResponse
    {
        public string Mensagem { get; set; }
        public string AccessToken { get; set; }
        public DateTime DataExpiracao { get; set; }

    }
}

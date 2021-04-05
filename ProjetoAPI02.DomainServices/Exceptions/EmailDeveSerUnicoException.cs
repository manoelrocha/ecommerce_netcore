using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.DomainServices.Exceptions
{
    public class EmailDeveSerUnicoException : Exception
    {
        private string email;

        public EmailDeveSerUnicoException(string email)
        {
            this.email = email;
        }

        public override string Message 
            => $"O email '{email}' informado já encontra-se cadastrado.";
    }
}

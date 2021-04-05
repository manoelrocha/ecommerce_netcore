using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Security.Settings
{
    /// <summary>
    /// Classe utilizada para ler e armazenar a palavra-chave que será
    /// utilizada para gerar o TOKEN do cliente.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Armazenar a palavra-chave utilizada para gerar o TOKEN
        /// </summary>
        public string SecretKey { get; set; }
    }
}

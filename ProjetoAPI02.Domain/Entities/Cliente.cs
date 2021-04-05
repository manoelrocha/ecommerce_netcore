using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.Domain.Entities
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }

        public List<Pedido> Pedidos { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}

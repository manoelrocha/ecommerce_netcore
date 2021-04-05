using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.DomainServices;
using ProjetoAPI02.DomainServices.Exceptions;
using ProjetoAPI02.Services.Models.Requests;
using ProjetoAPI02.Services.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClientePostRequest request, 
            [FromServices] ClienteDomainService clienteDomainService)
        {
            try
            {
                var cliente = new Cliente
                {
                    IdCliente = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Cpf = request.Cpf,
                    Senha = request.Senha
                };

                var enderecos = new List<Endereco>();

                foreach (var item in request.Enderecos)
                {
                    enderecos.Add(new Endereco 
                    { 
                        IdEndereco = Guid.NewGuid(),
                        Logradouro = item.Logradouro,
                        Numero = item.Numero,
                        Complemento = item.Complemento,
                        Bairro = item.Bairro,
                        Cidade = item.Cidade,
                        Estado = item.Estado,
                        Cep = item.Cep
                    });
                }

                clienteDomainService.CadastrarCliente(cliente, enderecos);

                var response = new PostOkResponse
                {
                    Mensagem = "Cliente cadastrado com sucesso."
                };

                return Ok(response);
            }
            catch(EmailDeveSerUnicoException e)
            {
                return StatusCode(403, e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Não foi possível realizar o cadastro do cliente.");
            }
        }
    }
}

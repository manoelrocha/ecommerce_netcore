using AutoMapper;
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
            [FromServices] ClienteDomainService clienteDomainService,
            [FromServices] IMapper mapper)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(request);
                cliente.IdCliente = Guid.NewGuid();

                var enderecos = new List<Endereco>();

                foreach (var item in request.Enderecos)
                {
                    var endereco = mapper.Map<Endereco>(item);
                    endereco.IdEndereco = Guid.NewGuid();
                    enderecos.Add(endereco); 
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

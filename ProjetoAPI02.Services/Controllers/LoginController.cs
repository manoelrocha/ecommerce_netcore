using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.DomainServices;
using ProjetoAPI02.Security.Services;
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
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginPostRequest request,
            [FromServices] ClienteDomainService clienteDomainService,
            [FromServices] TokenService tokenService)
        {
            try
            {
                //buscar cliente pelo email e senha
                var cliente = clienteDomainService.ObterCliente(request.Email, request.Senha);

                //verificar se o cliente foi encontrado
                if(cliente != null)
                {
                    //gerar o TOKEN de acesso
                    var response = new LoginOkResponse
                    {
                        Mensagem = "Cliente autenticado com sucesso!",
                        AccessToken = tokenService.GenerateToken(cliente.Email),
                        DataExpiracao = DateTime.Now.AddDays(1)
                    };

                    return Ok(response);
                }
                else
                {
                    return StatusCode(401, "Acesso não autorizado.");
                }

            }
            catch(Exception)
            {
                return StatusCode(500, "Não foi possivel realizar autenticacao.");
            }
            
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.DomainServices;
using ProjetoAPI02.Services.Models.Responses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromServices] ProdutoDomainService produtoDomainService)
        {
            try
            {
                var result = new List<ProdutoGetResponse>();

                foreach (var item in produtoDomainService.ConsultarProdutos())
                {
                    result.Add(new ProdutoGetResponse
                    {
                        Id = item.IdProduto,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        Descricao = item.Descricao,
                        Foto = item.Foto
                        
                    });
                }

                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

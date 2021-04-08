using FluentAssertions;
using Newtonsoft.Json;
using ProjetoAPI02.Services.Models.Responses.Data;
using ProjetoAPI02.Tests.Configurations;
using ProjetoAPI02.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoAPI02.Tests
{
    public class ProdutosTest
    {
        //atributo
        private readonly HttpClient httpClient;

        //construtor..
        public ProdutosTest()
        {
            var configuration = new ServerConfiguration();
            httpClient = configuration.CreateClient();
        }

        [Fact]
        public async Task<List<ProdutoGetResponse>> Produtos_Get_Return_Ok_NotEmpty()
        {
            #region Realizando a chamada para a API

            //executando a chamada para a API..
            var response = await httpClient.GetAsync("api/produtos");

            //critério do teste -> OK
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //capturando os dados retornados pelo serviço de consulta de produtos..
            var result = JsonConvert.DeserializeObject<List<ProdutoGetResponse>>
                (ContentHelper.GetContent(response));

            //critério de teste -> Não pode estar vazio
            result
                .Should()
                .NotBeEmpty();

            return result;

            #endregion
        }
    }
}



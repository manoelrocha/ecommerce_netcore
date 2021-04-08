using FluentAssertions;
using ProjetoAPI02.Services.Models.Requests;
using ProjetoAPI02.Tests.Configurations;
using ProjetoAPI02.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoAPI02.Tests
{
    public class PedidosTest
    {
        //atributo
        private readonly HttpClient httpClient;

        //construtor..
        public PedidosTest()
        {
            var configuration = new ServerConfiguration();
            httpClient = configuration.CreateClient();
        }

        [Fact]
        public async Task Pedidos_Post_Return_Ok()
        {
            #region Dados do teste

            //Autenticar um cliente..
            var loginTest = new LoginTest();
            var auth = await loginTest.Login_Post_Return_Ok();

            //Consultar produtos..
            var produtosTest = new ProdutosTest();
            var produtos = await produtosTest.Produtos_Get_Return_Ok_NotEmpty();

            //criando um pedido..
            var pedido = new PedidoPostRequest
            {
                DataPedido = DateTime.Now.ToString(), //data do pedido
                ValorPedido = "100", //valor do pedido
                ItemPedidos = new List<ItemPedidoPostRequest>()
            };

            //adicionando 1 produto ao pedido
            pedido.ItemPedidos.Add(new ItemPedidoPostRequest
            {
                IdProduto = produtos[0].Id.ToString(),
                Quantidade = 1
            });

            #endregion

            #region Realizando a chamada para a API

            //criando os dados da requisição
            var request = ContentHelper.CreateContent(pedido);

            //enviando o TOKEN de autenticação do cliente
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", auth.AccessToken);

            //enviando o TOKEN do cliente (autenticação)
            var response = await httpClient.PostAsync("api/pedidos", request);

            //verificando se o resultado foi OK
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Pedidos_Post_Return_BadRequest()
        {
            #region Dados do teste

            //Autenticar um cliente..
            var loginTest = new LoginTest();
            var auth = await loginTest.Login_Post_Return_Ok();

            //criando um pedido sem informações (vazio)..
            var pedido = new PedidoPostRequest();

            #endregion

            #region Realizando a chamada para a API

            //criando os dados da requisição
            var request = ContentHelper.CreateContent(pedido);

            //enviando o TOKEN de autenticação do cliente
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", auth.AccessToken);

            //enviando o TOKEN do cliente (autenticação)
            var response = await httpClient.PostAsync("api/pedidos", request);

            //verificando se o resultado foi BAD REQUEST
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            #endregion
        }
    }
}




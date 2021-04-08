using FluentAssertions;
using Newtonsoft.Json;
using ProjetoAPI02.Services.Models.Requests;
using ProjetoAPI02.Services.Models.Responses;
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
    public class LoginTest
    {
        //atributo
        private readonly HttpClient httpClient;

        //construtor..
        public LoginTest()
        {
            var configuration = new ServerConfiguration();
            httpClient = configuration.CreateClient();
        }

        [Fact]
        public async Task<LoginOkResponse> Login_Post_Return_Ok()
        {
            #region Dados do teste

            //executando o teste para criar um cliente com sucesso na aplicação
            var clienteTest = new ClientesTest();
            var cliente = await clienteTest.Clientes_Post_Return_OK();

            //montando os dados para autenticar o cliente
            //utilizando o cliente que acabou de ser cadastrado na API
            var login = new LoginPostRequest
            {
                Email = cliente.Email,
                Senha = cliente.Senha
            };

            #endregion

            #region Realizando a autenticação do cliente

            var request = ContentHelper.CreateContent(login);

            //executando a chamada para a API..
            var response = await httpClient.PostAsync("api/login", request);

            //verificando o retorno obtido da api..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //retornar os dados obtidos da API após a realização da autenticação
            var result = JsonConvert.DeserializeObject<LoginOkResponse>
                (ContentHelper.GetContent(response));

            return result;

            #endregion
        }

        [Fact]
        public async Task Login_Post_Return_BadRequest()
        {
            #region Dados do teste

            //Objeto sem preenchimento os campos
            var login = new LoginPostRequest();

            #endregion

            #region Realizando a autenticação do cliente

            var request = ContentHelper.CreateContent(login);

            //executando a chamada para a API..
            var response = await httpClient.PostAsync("api/login", request);

            //verificando o retorno obtido da api..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            #endregion
        }

        [Fact]
        public async Task Login_Post_Return_Unauthorized()
        {
            #region Dados do teste

            //Objeto sem preenchimento os campos
            var login = new LoginPostRequest
            {
                Email = "teste_usuarioinvalido@gmail.com",
                Senha = "teste123456"
            };

            #endregion

            #region Realizando a autenticação do cliente

            var request = ContentHelper.CreateContent(login);

            //executando a chamada para a API..
            var response = await httpClient.PostAsync("api/login", request);

            //verificando o retorno obtido da api..
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Unauthorized);

            #endregion
        }
    }
}





using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjetoAPI02.Services.Models.Requests;
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
    public class ClientesTest
    {
        //atributo
        private readonly HttpClient httpClient;

        //construtor..
        public ClientesTest()
        {
            var configuration = new ServerConfiguration();
            httpClient = configuration.CreateClient();
        }

        /// <summary>
        /// Teste que verifica se um cliente é cadastrado com sucesso na API
        /// </summary>
        /// <returns>Dados do Cliente cadastrado na API</returns>
        [Fact]
        public async Task<ClientePostRequest> Clientes_Post_Return_OK()
        {
            #region Dados do teste

            //gerando um numero randomico
            var random = new Random().Next(99999, 999999);

            //dados do cliente
            var cliente = new ClientePostRequest
            {
                Nome = "Cliente Teste",
                Email = $"cliente_teste{random}@gmail.com",
                Cpf = $"12345{random}",
                Senha = "admin@123",
                SenhaConfirmacao = "admin@123",
                Enderecos = new List<EnderecoPostRequest>()
            };

            //adicionando endereços ao cliente
            cliente.Enderecos.Add(new EnderecoPostRequest
            {
                Logradouro = "Av Rio Branco",
                Numero = "185",
                Complemento = "Sala 225",
                Bairro = "Centro",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Cep = "25000000"
            });

            cliente.Enderecos.Add(new EnderecoPostRequest
            {
                Logradouro = "Av Pres Vargas",
                Numero = "100",
                Complemento = "Sala 210",
                Bairro = "Centro",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Cep = "24000000"
            });

            #endregion

            #region Realizando a chamada para a API

            //criando a requisição (dados em formato JSON) que serão enviados para a API
            var request = ContentHelper.CreateContent(cliente);

            //executando a chamada para a API (método assincrono -> THREAD)
            var response = await httpClient.PostAsync("api/clientes", request);

            //verificando se o retorno obtido da API foi STATUS OK (SUCESSO)
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            return cliente;

            #endregion
        }

        /// <summary>
        /// Teste que verifica se API retorna erros de validação (400) para o cadastro do cliente
        /// </summary>
        [Fact]
        public async Task Clientes_Post_Return_BadRequest()
        {
            #region Dados do teste

            //criando um objeto Cliente vazio (campos em branco)
            var cliente = new ClientePostRequest
            {
                Enderecos = new List<EnderecoPostRequest>()
            };

            #endregion

            #region Realizando a chamada para a API

            //criando a requisição (dados em formato JSON) que serão enviados para a API
            var request = ContentHelper.CreateContent(cliente);

            //executando a chamada para a API (método assincrono -> THREAD)
            var response = await httpClient.PostAsync("api/clientes", request);

            //verificando se o retorno obtido da API foi STATUS BAD REQUEST
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            #endregion
        }

        /// <summary>
        /// Teste que verifica se API retorna erros (403) para o cadastro de clientes com o mesmo email
        /// </summary>
        [Fact]
        public async Task Clientes_Post_Return_Forbidden()
        {
            #region Dados do Teste

            //cadastrar um cliente (executando o teste de cadastro com sucesso)
            //nós temos aqui um objeto cliente contendo um registro ja cadastrado
            var cliente = await Clientes_Post_Return_OK();

            #endregion

            #region Realizando a chamada para a API

            //criando a requisição (dados em formato JSON) que serão enviados para a API
            var request = ContentHelper.CreateContent(cliente);

            //executando a chamada para a API (método assincrono -> THREAD)
            var response = await httpClient.PostAsync("api/clientes", request);

            //verificando se o retorno obtido da API foi STATUS FORBIDDEN (403)
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Forbidden);

            #endregion
        }
    }
}

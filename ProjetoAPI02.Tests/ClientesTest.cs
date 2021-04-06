using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProjetoAPI02.Services.Models.Requests;
using ProjetoAPI02.Tests.Configurations;
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

        [Fact]
        public async Task Clientes_Post_Return_OK()
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
            var request = new StringContent(JsonConvert.SerializeObject(cliente),
                Encoding.UTF8, "application/json");

            //executando a chamada para a API (método assincrono -> THREAD)
            var response = await httpClient.PostAsync("api/clientes", request);

            //verificando se o retorno obtido da API foi STATUS OK (SUCESSO)
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            #endregion
        }

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
            var request = new StringContent(JsonConvert.SerializeObject(cliente),
                Encoding.UTF8, "application/json");

            //executando a chamada para a API (método assincrono -> THREAD)
            var response = await httpClient.PostAsync("api/clientes", request);

            //verificando se o retorno obtido da API foi STATUS BAD REQUEST
            response.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            #endregion
        }
    }
}









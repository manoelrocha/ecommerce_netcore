using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ProjetoAPI02.Tests.Configurations
{
    public class ServerConfiguration
    {
        //método para retornar a configuração do HttpClient
        public HttpClient CreateClient()
        {
            #region Acessando o arquivo appsettings.json

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            #endregion

            #region Criando o HttpClient para acesso a API

            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Services.Startup>());

            return server.CreateClient(); //Cliente do projeto API!
            #endregion
        }
    }
}

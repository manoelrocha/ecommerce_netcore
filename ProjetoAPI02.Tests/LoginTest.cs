using ProjetoAPI02.Tests.Configurations;
using System;
using System.Collections.Generic;
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

        [Fact(Skip = "Não implementado")]
        public async Task Login_Post_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado")]
        public async Task Login_Post_Return_BadRequest()
        {

        }

        [Fact(Skip = "Não implementado")]
        public async Task Login_Post_Return_Unauthorized()
        {

        }
    }
}

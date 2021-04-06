using ProjetoAPI02.Tests.Configurations;
using System;
using System.Collections.Generic;
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

        [Fact(Skip = "Não implementado")]
        public async Task Produtos_Get_Return_Ok()
        {

        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ProjetoAPI02.Tests.Helpers
{
    public class ContentHelper
    {
        //Método para serializar e montar um objeto JSON
        //para envio de dados em uma API (request)
        public static StringContent CreateContent(object model)
        {
            return new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8, "application/json");
        }

        //retornar o resultado obtido de uma chamada feita na API..
        public static string GetContent(HttpResponseMessage response)
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}

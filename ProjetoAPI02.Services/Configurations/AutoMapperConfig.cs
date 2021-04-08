using AutoMapper;
using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Services.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Services.Configurations
{
    public class AutoMapperConfig : Profile
    {
        //construtor
        public AutoMapperConfig()
        {
            //mapear as trocas de dados que deverao ser feitas atraves do AutoMapper
            CreateMap<ClientePostRequest, Cliente>();
            CreateMap<EnderecoPostRequest, Endereco>();

        }
    }
}

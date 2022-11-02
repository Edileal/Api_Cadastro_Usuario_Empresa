using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Endereco;
using CadastroUsuarioEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.CrossCutting.Mappers
{
    public class EnderecoEntitiesToContractMap : Profile
    {
        public EnderecoEntitiesToContractMap()
        {
            CreateMap<EnderecoEntities, EnderecoRequest>().ReverseMap();
            //CreateMap<EnderecoEntities, EnderecoResponse>().ReverseMap(); ainda não decidi se terá response
        }
    }
}

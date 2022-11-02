using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.CrossCutting.Mappers
{
    public class EmpresaEntitiesToContractMap : Profile
    {
        public EmpresaEntitiesToContractMap()
        {
            CreateMap<EmpresaEntities, EmpresaRequest>().ReverseMap();
            CreateMap<EmpresaEntities, EmpresaResponse>().ReverseMap();
        }
    }
}

using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;

namespace CadastroUsuarioEmpresa.CrossCutting.Mappers
{
    public class UsuarioEntitiesToContractMap : Profile
    {
        public UsuarioEntitiesToContractMap()
        {
            CreateMap<UsuarioEntities, UsuarioRequest>().ReverseMap();
            CreateMap<UsuarioEntities, UsuarioCadastraRequest>().ReverseMap();
            CreateMap<UsuarioEntities, UsuarioResponse>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CadastroUsuarioEmpresa.CrossCutting.Mappers;

namespace CadastroUsuarioEmpresa.Testes.CrossCutting
{
    public abstract class BaseAutoMapperFixture
    {
        public IMapper mapper { get; set; }

        public BaseAutoMapperFixture()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsuarioEntitiesToContractMap());
                cfg.AddProfile(new EmpresaEntitiesToContractMap());
                cfg.AddProfile(new EnderecoEntitiesToContractMap());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }

}
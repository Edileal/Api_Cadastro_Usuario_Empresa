using CadastroUsuarioEmpresa.CrossCutting.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.CrossCutting.DependencyInjection
{
    public static class ConfigureMappers
    {
        public static void ConfigureDependenciesMapper(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cnf =>
            {
                cnf.AddProfile(new UsuarioEntitiesToContractMap());
                cnf.AddProfile(new EmpresaEntitiesToContractMap());
                cnf.AddProfile(new EnderecoEntitiesToContractMap());
            });

            var mapConfiguration = config.CreateMapper();
            serviceCollection.AddSingleton(mapConfiguration);
        }
    }
}

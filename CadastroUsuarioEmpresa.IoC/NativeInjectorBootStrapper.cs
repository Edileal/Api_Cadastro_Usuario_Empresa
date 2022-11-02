using CadastroUsuarioEmpresa.CrossCutting.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            ConfigureServices.ConfigureDependenciesService(services);
            ConfigureMappers.ConfigureDependenciesMapper(services);
        }

        public static void RegisterAppDependenciesContext(this IServiceCollection services, string connectionString)
        {
            ConfigureRepository.ConfigureDependenciesRepository(services, connectionString);
        }
    }
}

using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroUsuarioEmpresa.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<IEmpresaRepository, EmpresaRepository>();
            serviceCollection.AddScoped<IEnderecoRepository, EnderecoRepository>();
            serviceCollection.AddDbContext<CadastroUsuarioEmpresaContext>(options => options.UseSqlServer(connectionString));
        }
    }
}

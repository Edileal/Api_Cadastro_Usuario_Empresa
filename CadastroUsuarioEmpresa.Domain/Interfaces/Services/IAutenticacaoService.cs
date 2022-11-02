using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Interfaces.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(string usuario, string senha);
    }
}

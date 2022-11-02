using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Interfaces.Services
{
    public interface IEmpresaService : IBaseCRUD<EmpresaRequest, EmpresaResponse>
    {
    }
}

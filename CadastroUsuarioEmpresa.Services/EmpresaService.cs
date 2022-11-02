using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Services
{
    public class EmpresaService : IEmpresaService
    {
        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmpresaResponse>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> Post(EmpresaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaResponse> Put(EmpresaRequest request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}

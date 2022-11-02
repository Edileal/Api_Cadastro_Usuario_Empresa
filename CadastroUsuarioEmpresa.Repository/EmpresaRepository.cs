using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public Task Delete(EmpresaEntities request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmpresaEntities>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaEntities> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaEntities> Post(EmpresaEntities request)
        {
            throw new NotImplementedException();
        }

        public Task<EmpresaEntities> Put(EmpresaEntities request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}

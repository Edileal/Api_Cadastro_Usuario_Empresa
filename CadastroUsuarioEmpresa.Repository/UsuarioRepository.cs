using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task Delete(UsuarioEntities request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntities>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntities> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntities> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntities> Post(UsuarioEntities request)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntities> Put(UsuarioEntities request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}

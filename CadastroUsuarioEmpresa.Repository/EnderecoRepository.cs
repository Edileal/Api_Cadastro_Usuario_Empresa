using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public Task Delete(int request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EnderecoEntities request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EnderecoEntities>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntities> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntities> Post(EnderecoEntities request)
        {
            throw new NotImplementedException();
        }

        public Task<EnderecoEntities> Put(EnderecoEntities request, int? id)
        {
            throw new NotImplementedException();
        }
    }
}

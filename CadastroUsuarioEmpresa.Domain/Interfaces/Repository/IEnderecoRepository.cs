using CadastroUsuarioEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IBaseCRUD<EnderecoEntities, EnderecoEntities>
    {
        Task Delete(EnderecoEntities request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Interfaces
{
    public interface IBaseCRUD<Request, Response>
    {
        Task<IEnumerable<Response>> Get();

        Task<Response> GetById(int id);

        Task<Response> Post(Request request);

        Task<Response> Put(Request request, int? id);

        Task Delete(int request);
    }
}

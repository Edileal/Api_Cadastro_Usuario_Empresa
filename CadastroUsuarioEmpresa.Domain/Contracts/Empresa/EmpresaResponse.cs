using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Contracts.Empresa
{
    public class EmpresaResponse : EmpresaRequest
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Entities
{
    public class EmpresaEntities
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoEntities Endereco { get; set; }
    }
}

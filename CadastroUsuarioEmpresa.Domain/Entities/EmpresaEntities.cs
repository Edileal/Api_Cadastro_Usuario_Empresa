using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Entities
{
    public class EmpresaEntities
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string NomeFantasia { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoEntities Endereco { get; set; }
    }
}

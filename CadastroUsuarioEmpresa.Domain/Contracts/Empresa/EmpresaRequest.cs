using CadastroUsuarioEmpresa.Domain.Contracts.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Contracts.Empresa
{
    public class EmpresaRequest
    {
        public string? Nome { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}

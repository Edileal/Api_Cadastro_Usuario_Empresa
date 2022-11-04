using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Contracts.Usuario
{
    public class UsuarioAdminResponse : UsuarioResponse
    {
        public string Cpf { get; set; }
    }
}

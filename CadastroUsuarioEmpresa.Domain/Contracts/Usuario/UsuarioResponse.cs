﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Contracts.Usuario
{
    public class UsuarioResponse : UsuarioRequest
    {
        public int Id { get; set; }
    }
}

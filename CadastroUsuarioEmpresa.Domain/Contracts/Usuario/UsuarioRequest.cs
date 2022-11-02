﻿using CadastroUsuarioEmpresa.Domain.Contracts.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Contracts.Usuario
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Role { get; set; }
        public string DataNascimento { get; set; }
        public EnderecoRequest Endereco { get; set; }
    }
}

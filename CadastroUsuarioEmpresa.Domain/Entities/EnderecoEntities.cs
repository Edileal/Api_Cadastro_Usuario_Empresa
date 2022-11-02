﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Domain.Entities
{
    public class EnderecoEntities
    {
        public int Id  { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
	    public string Estado { get; set; }
        public string Numero { get; set; }
    }
}

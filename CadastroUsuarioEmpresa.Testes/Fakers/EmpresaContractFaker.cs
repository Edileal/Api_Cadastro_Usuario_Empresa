using Bogus;
using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public class EmpresaContractFaker
    {
        private static readonly Faker Fake = new Faker();

       public static EmpresaRequest EmpresaRequest()
        {
            return new EmpresaRequest()
            {
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Company.CompanyName(),
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }
    }
}

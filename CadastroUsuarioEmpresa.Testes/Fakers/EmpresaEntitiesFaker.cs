using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class EmpresaEntitiesFaker
    {
        private static readonly Faker fake = new Faker();

        public static int GetEmpresaById()
        {
            return fake.IndexFaker;

        }
        public static async Task<EmpresaEntities> EmpresaEntitiesAsync(int id)
        {
            return new EmpresaEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Name.FirstName(),
                NomeFantasia = fake.Company.CompanyName(),
                Endereco = EnderecoFaker.GetEndereco()
            };
        }
    }
}

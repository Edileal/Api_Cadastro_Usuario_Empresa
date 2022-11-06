using Bogus;
using Bogus.Extensions.Brazil;
using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Enum;
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
        public static async Task<IEnumerable<EmpresaEntities>> EmpresaEntitiesAsync()
        {
            var minhaLista = new List<EmpresaEntities>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new EmpresaEntities()
                {
                    Id = i,
                    Nome = fake.Name.FirstName(),
                    NomeFantasia = fake.Company.CompanyName(),
                    Endereco = EnderecoFaker.GetEndereco()
                });
                
            }
            return minhaLista;
        }
        public static async Task<EmpresaEntities> EmpresaEntitiesBase(EmpresaRequest request)
        {
            return new EmpresaEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Name.FirstName(),
                NomeFantasia = fake.Company.CompanyName(),
                Endereco = EnderecoFaker.GetEndereco()
            };
        }
        public static async Task<EmpresaEntities> EmpresaEntitiesBase(EmpresaEntities request)
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

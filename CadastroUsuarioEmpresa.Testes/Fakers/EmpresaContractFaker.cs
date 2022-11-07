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

        public static int GetId()
        {
            return Fake.IndexFaker;
        }
        public static EmpresaRequest EmpresaRequest()
        {
            return new EmpresaRequest()
            {
                Nome = Fake.Name.FirstName(),
                NomeFantasia = Fake.Company.CompanyName(),
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }
        public static async Task<IEnumerable<EmpresaResponse>> EmpresaResponseAsync()
        {
            var minhaLista = new List<EmpresaResponse>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new EmpresaResponse()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName(),
                    NomeFantasia = Fake.Company.CompanyName(),
                    Endereco = EnderecoContractFaker.GetEnderecoRequest()

                });
            }

            return minhaLista;
        }
        public static async Task<EmpresaResponse> EmpresaResponsePorIdAsync(int id)
        {
            return new EmpresaResponse
            {
                Id = id,
                NomeFantasia = Fake.Company.CompanyName(),
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }
        public static async Task<EmpresaResponse> EmpresaResponseAsync(string nomeFantasia)
        {
            return new EmpresaResponse
            {
                NomeFantasia = nomeFantasia,
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }
    }
}

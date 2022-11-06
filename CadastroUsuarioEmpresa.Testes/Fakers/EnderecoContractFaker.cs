using Bogus;
using CadastroUsuarioEmpresa.Domain.Contracts.Endereco;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class EnderecoContractFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }
        public static EnderecoRequest GetEnderecoRequest()
        {
            return new EnderecoRequest
            {
                Bairro = Fake.Address.County(),
                Cep = Fake.Address.ZipCode("########"),
                Cidade = Fake.Address.City(),
                Estado = Fake.Address.State(),
                Numero = Fake.Random.Int(1, 9999).ToString(),
                Rua = Fake.Address.StreetName()
            };
        }
    }
}
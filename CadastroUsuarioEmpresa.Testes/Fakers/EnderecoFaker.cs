using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class EnderecoFaker
    {
        private static readonly Faker fake = new Faker();

        public static EnderecoEntities GetEndereco()
            {
                return new EnderecoEntities()
                {
                    Bairro = fake.Address.County(),
                    Cep = fake.Address.ZipCode("########"),
                    Cidade = fake.Address.City(),
                    Estado = fake.Address.State(),
                    Numero = fake.Random.Int(1, 9999).ToString(),
                    Rua = fake.Address.StreetName()

                };
            }
    }
}
using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;
using Bogus.Extensions.Brazil;
using CadastroUsuarioEmpresa.Domain.Enum;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class UsuarioEntitiesFaker
    {
        private static readonly Faker fake = new Faker();
        
        public static UsuarioEntities GetUsuarioEntities()
        {
            return new UsuarioEntities()
            {
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Nome = fake.Person.FullName,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Random.AlphaNumeric(10),
                Telefone = fake.Random.Int(11, 11).ToString()
            };
        }
    }
}
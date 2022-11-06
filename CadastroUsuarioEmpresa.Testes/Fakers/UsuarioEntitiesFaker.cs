using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;
using Bogus.Extensions.Brazil;
using CadastroUsuarioEmpresa.Domain.Enum;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class UsuarioEntitiesFaker
    {
        private static readonly Faker fake = new Faker();

        public static int GetUsuarioById()
        {
            return fake.IndexFaker;

        }
        public static async Task<UsuarioEntities> GetUsuarioEntities()
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
       
        public static async Task<UsuarioEntities> UsuarioEntitiesAsync(int id)
        {
            return new UsuarioEntities()
            {
                Id = id,
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
        public static async Task<IEnumerable<UsuarioEntities>> UsuarioEntitiesAsync()
        {
            var minhaLista = new List<UsuarioEntities>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new UsuarioEntities()
                {
                    Id = i,
                    Cpf = fake.Person.Cpf(),
                    DataNascimento = fake.Person.DateOfBirth,
                    Email = fake.Person.Email,
                    Nome = fake.Person.FullName,
                    Role = fake.PickRandom<RoleEnum>(),
                    Endereco = EnderecoFaker.GetEndereco(),
                    Senha = fake.Random.AlphaNumeric(10),
                    Telefone = fake.Random.Int(11, 11).ToString()
                });
            }

            return minhaLista;
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesBaseRequestAsync(string nome)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = nome,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Random.AlphaNumeric(10),
                Telefone = fake.Random.Int(11, 11).ToString()
            };
        }
    }
}
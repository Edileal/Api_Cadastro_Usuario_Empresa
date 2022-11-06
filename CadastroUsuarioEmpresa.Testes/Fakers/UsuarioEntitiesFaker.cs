using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;
using Bogus.Extensions.Brazil;
using CadastroUsuarioEmpresa.Domain.Enum;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;

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
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
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
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
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
                    Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                    Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
                });
            }

            return minhaLista;
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesBase(UsuarioCadastraRequest request)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesBaseAsync(UsuarioEntities request)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesNomeValido(string nome)
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
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesSemNome(string nome)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,

                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> GetUsuarioEntitiesNameInvalido()
        {
            return new UsuarioEntities()
            {
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Nome = fake.Person.FullName,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> GetUsuarioEntitiesSenhaInvalida()
        {
            return new UsuarioEntities()
            {
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Nome = fake.Person.FullName,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = "1234",
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesSenhaInvalida(string senha)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = fake.Person.Email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = senha,
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> GetUsuarioEntitiesEmailInvalido()
        {
            return new UsuarioEntities()
            {
                
                Nome = fake.Person.FullName,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
               
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }
        public static async Task<UsuarioEntities> UsuarioEntitiesEmailInvalido(string email)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                Cpf = fake.Person.Cpf(),
                DataNascimento = fake.Person.DateOfBirth,
                Email = email,
                Role = fake.PickRandom<RoleEnum>(),
                Endereco = EnderecoFaker.GetEndereco(),
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = fake.Phone.PhoneNumber("(71) 9####-####")
            };
        }

    }
}
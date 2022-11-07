using Bogus;
using CadastroUsuarioEmpresa.Domain.Entities;
using Bogus.Extensions.Brazil;
using CadastroUsuarioEmpresa.Domain.Enum;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Shared;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class UsuarioEntitiesFaker
    {
        private static readonly Faker fake = new Faker();

        public static int GetUsuarioById()
        {
            return fake.IndexFaker;

        }
        public static UsuarioEntities GetUsuarioSenha(string senha)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                DataNascimento = fake.Person.DateOfBirth,
                Cpf = fake.Person.Cpf(),
                Endereco = EnderecoFaker.GetEndereco(),
                Email = fake.Person.Email,
                Senha = Cryptography.Encrypt(senha),
                Role = fake.PickRandom<RoleEnum>(),
                Telefone = fake.Phone.PhoneNumber("(75) 98###-####")

            };
        }
        public static UsuarioEntities GetUsuario(RoleEnum adm)
        {
            return new UsuarioEntities()
            {
                Id = fake.IndexFaker,
                Nome = fake.Person.FullName,
                DataNascimento = fake.Person.DateOfBirth,
                Cpf = fake.Person.Cpf(),
                Endereco = EnderecoFaker.GetEndereco(),
                Email = fake.Person.Email,
                Senha = fake.Internet.Password(8, true, "", "E-1y74"),
                Role = adm,
                Telefone = fake.Phone.PhoneNumber("(75) 98###-####")

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
                Telefone = fake.Phone.PhoneNumber("(71) 98###-####")
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
                    Telefone = fake.Phone.PhoneNumber("(71) 98###-####")
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
                Telefone = fake.Phone.PhoneNumber("(71) 98###-####")
            };
        }
        //public static async Task<UsuarioEntities> UsuarioEntitiesBaseAsync(UsuarioEntities request)
        //{
        //    return new UsuarioEntities()
        //    {
        //        Id = fake.IndexFaker,
        //        Nome = fake.Person.FullName,
        //        Cpf = fake.Person.Cpf(),
        //        DataNascimento = fake.Person.DateOfBirth,
        //        Email = fake.Person.Email,
        //        Role = fake.PickRandom<RoleEnum>(),
        //        Endereco = EnderecoFaker.GetEndereco(),
        //        Senha = fake.Internet.Password(8, true, "", "E-1y74"),
        //        Telefone = fake.Phone.PhoneNumber("(71) 98###-####")
        //    };
        //}

    }
}
using Bogus;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioEmpresa.Testes.Fakers
{
    public static class UsuarioContractFaker
    {
        private static readonly Faker Fake = new Faker();

        public static int GetId()
        {
            return Fake.IndexFaker;
        }

        public static async Task<IEnumerable<UsuarioResponse>> UsuarioResponseAsync()
        {
            var minhaLista = new List<UsuarioResponse>();

            for (int i = 0; i < 5; i++)
            {
                minhaLista.Add(new UsuarioResponse()
                {
                    Id = i,
                    Nome = Fake.Name.FirstName(),
                    Telefone = Fake.Random.Int(11, 11).ToString(),
                    Email = Fake.Person.Email,
                    DataNascimento = Fake.Person.DateOfBirth,
                    Role = Fake.PickRandom<RoleEnum>(),
                    //Endereco = EnderecoFaker.GetEndereco()

                });
            }

            return minhaLista;
        }

        public static async Task<UsuarioResponse> UsuarioResponseAsync(int id)
        {
            return new UsuarioResponse()
            {
                Id = id,
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Random.Int(11, 11).ToString(),
                Email = Fake.Person.Email,
                DataNascimento = Fake.Person.DateOfBirth,
                Role = Fake.PickRandom<RoleEnum>(),
            };
        }

        public static UsuarioRequest UsuarioRequest()
        {
            return new UsuarioRequest
            {
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Random.Int(11, 11).ToString(),
                Email = Fake.Person.Email,
                DataNascimento = Fake.Person.DateOfBirth,
                Role = Fake.PickRandom<RoleEnum>(),
            };
        }

        public static UsuarioCadastraRequest UsuarioCadastraRequest()
        {
            return new UsuarioCadastraRequest
            {
                Nome = Fake.Name.FirstName(),
                Senha = Fake.Name.FullName(),
                Telefone = Fake.Random.Int(11, 11).ToString(),
                Email = Fake.Person.Email,
                DataNascimento = Fake.Person.DateOfBirth,
                Role = Fake.PickRandom<RoleEnum>(),
            };
        }

        public static async Task<UsuarioResponse> UsuarioResponseBaseRequestAsync(string nome)
        {
            return new UsuarioResponse()
            {
                Id = Fake.IndexFaker,
                Nome = nome
            };
        }
    }
}

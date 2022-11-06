using Bogus;
using Bogus.Extensions.Brazil;
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
                    Endereco = EnderecoContractFaker.GetEnderecoRequest()

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
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }

        public static UsuarioCadastraRequest UsuarioCadastraRequest()
        {
            return new UsuarioCadastraRequest
            {
                Nome = Fake.Name.FirstName(),
                Senha = Fake.Internet.Password(8, true, "", "E-1y74"),
                Telefone = Fake.Phone.PhoneNumber("(71) 9####-####"),
                Email = Fake.Person.Email,
                DataNascimento = Fake.Person.DateOfBirth,
                Role = Fake.PickRandom<RoleEnum>(),
                Cpf = Fake.Person.Cpf(),
                Endereco = EnderecoContractFaker.GetEnderecoRequest()
            };
        }

        public static async Task<UsuarioResponse> UsuarioResponseBaseRequestAsync(string nome) //acho que não to usando isso.
        {
            return new UsuarioResponse()
            {
                Id = Fake.IndexFaker,
                Nome = Fake.Name.FirstName(),
                Telefone = Fake.Random.Int(11, 11).ToString(),
                Email = Fake.Person.Email,
                DataNascimento = Fake.Person.DateOfBirth,
                Role = Fake.PickRandom<RoleEnum>(),
            };
        }
    }
}

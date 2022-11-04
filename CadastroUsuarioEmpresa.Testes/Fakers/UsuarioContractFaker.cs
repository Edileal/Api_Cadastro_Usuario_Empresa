using Bogus;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
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
                    Nome = Fake.Name.FirstName()
                });
            }

            return minhaLista;
        }

        public static async Task<UsuarioResponse> UsuarioResponseAsync(int id)
        {
            return new UsuarioResponse()
            {
                Id = id,
                Nome = Fake.Name.FirstName()
            };
        }

        public static UsuarioRequest UsuarioRequest()
        {
            return new UsuarioRequest
            {
                Nome = Fake.Name.FirstName()
            };
        }

        public static UsuarioCadastraRequest UsuarioCadastraRequest()
        {
            return new UsuarioCadastraRequest
            {
                Nome = Fake.Name.FirstName(),
                Senha = Fake.Name.FullName()
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

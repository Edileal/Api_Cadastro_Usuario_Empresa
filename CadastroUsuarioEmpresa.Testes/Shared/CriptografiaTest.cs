using CadastroUsuarioEmpresa.Domain.Shared;
using CadastroUsuarioEmpresa.Services;
using CadastroUsuarioEmpresa.Testes.Fakers;
using System.Security.Cryptography;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Shared
{
    public class CriptografiaTest
    {
        [Fact(DisplayName = "Testes criptografia ok")]
        public void TesteSeCriptografiaOk()
        {
            string senha = "Dado123-";
            string senhaCriptografada = Cryptography.Encrypt(senha);
            string senhaDescriptografada = Cryptography.Decrypt(senhaCriptografada);

            Assert.Equal(senhaDescriptografada, senha);
        }
    }
}

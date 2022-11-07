using CadastroUsuarioEmpresa.Domain.Enum;
using CadastroUsuarioEmpresa.Domain.Shared;
using CadastroUsuarioEmpresa.Testes.Fakers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Shared
{
    public class TokenTest
    {
        private readonly JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        [Fact(DisplayName = "Testes token ok")]
        public void TesteSeCriptografiaOk()
        {
            var token = Token.GenerateToken(UsuarioEntitiesFaker.GetUsuario(RoleEnum.Administrador));
            var convert = handler.ReadJwtToken(token);
            var role = convert.Claims.FirstOrDefault(prop => prop.Type == "role");

            Assert.Equal("Administrador", role.Value);
        }
    }
}

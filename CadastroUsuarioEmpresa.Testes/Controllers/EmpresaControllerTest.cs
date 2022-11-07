using CadastroUsuarioEmpresa.Controllers;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using CadastroUsuarioEmpresa.Testes.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Controllers
{
    [Trait("Controller", "Controller de Empresa")]
    public class EmpresaControllerTest
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService = new Mock<IEmpresaService>();

        [Fact(DisplayName = "Lista todas as empresas")]
        public async Task GetTodasEmpresas()
        {
            _mockEmpresaService.Setup(mock => mock.Get()).Returns(EmpresaContractFaker.EmpresaResponseAsync());

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Get();

            Assert.True(result.ToList().Count() > 0);
        }
    }
}

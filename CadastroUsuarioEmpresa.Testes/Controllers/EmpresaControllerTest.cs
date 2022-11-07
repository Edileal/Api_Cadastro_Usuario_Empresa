using CadastroUsuarioEmpresa.Controllers;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using CadastroUsuarioEmpresa.Testes.Fakers;
using Microsoft.AspNetCore.Http;
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

        [Fact(DisplayName = "Busca uma empresa por ID")]
        public async Task GetEmpresaById()
        {
            int id = EmpresaContractFaker.GetId();

            _mockEmpresaService.Setup(mock => mock.GetById(id)).Returns(EmpresaContractFaker.EmpresaResponsePorIdAsync(id));

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.GetById(id);

            Assert.Equal(result.Id, id);
        }

        [Fact(DisplayName = "Cadastra uma nova empresa")]
        public async Task Post()
        {
            var empresaRequest = EmpresaContractFaker.EmpresaRequest();
            var resultEmpresaRequest = EmpresaContractFaker.EmpresaResponseAsync(empresaRequest.NomeFantasia);

            _mockEmpresaService.Setup(mock => mock.Post(empresaRequest)).Returns(resultEmpresaRequest);

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Post(empresaRequest);

            Assert.Equal(result.NomeFantasia, resultEmpresaRequest.Result.NomeFantasia);
        }

        [Fact(DisplayName = "Edita uma empresa")]
        public async Task Put()
        {
            var empresaRequest = EmpresaContractFaker.EmpresaRequest();
            var resultEmpresaRequest = EmpresaContractFaker.EmpresaResponseAsync(empresaRequest.NomeFantasia);

            _mockEmpresaService.Setup(mock => mock.Put(empresaRequest, resultEmpresaRequest.Result.Id)).Returns(resultEmpresaRequest);

            var controller = new EmpresaController(_mockEmpresaService.Object);

            var result = await controller.Put(resultEmpresaRequest.Result.Id, empresaRequest);

            Assert.Equal(result.NomeFantasia, resultEmpresaRequest.Result.NomeFantasia);
        }

        [Fact(DisplayName = "Remove uma empresa já existente")]
        public async Task Delete()
        {
            int id = EmpresaContractFaker.GetId();

            _mockEmpresaService.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));

            var controller = new EmpresaController(_mockEmpresaService.Object);

            await controller.Delete(id);
            Results.Ok();
        }
    }
}

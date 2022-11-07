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
    [Trait("Controller", "Controller de Usuarios")]
    public class UsuarioControllerTest
    {
        private readonly Mock<IUsuarioService> _mockUsuarioService = new Mock<IUsuarioService>();

        [Fact(DisplayName = "Lista todos os Usuarios")]
        public async Task GetTodosUsuarios()
        {
            _mockUsuarioService.Setup(mock => mock.Get()).Returns(UsuarioContractFaker.UsuarioResponseAsync());

            var controller = new UsuarioController(_mockUsuarioService.Object);

            var result = await controller.Get();

            Assert.True(result.ToList().Count() > 0);
        }
        [Fact(DisplayName = "Busca um usuario por ID")]
        public async Task GetById()
        {
            int id = UsuarioContractFaker.GetId();

            _mockUsuarioService.Setup(mock => mock.GetById(id)).Returns(UsuarioContractFaker.UsuarioResponseAsync(id));

            var controller = new UsuarioController(_mockUsuarioService.Object);

            var result = await controller.GetById(id);

            Assert.Equal(result.Id, id);
        }
        [Fact(DisplayName = "Cadastra um novo usuario")]
        public async Task Post()
        {
            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            var resultUserRequest = UsuarioContractFaker.UsuarioResponseBaseRequestAsync(userRequest.Nome);

            _mockUsuarioService.Setup(mock => mock.Post(userRequest)).Returns(resultUserRequest);

            var controller = new UsuarioController(_mockUsuarioService.Object);

            var result = await controller.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }

        [Fact(DisplayName = "Edita um usuario já existente")]
        public async Task Put()
        {
            var userRequest = UsuarioContractFaker.UsuarioRequest();
            var resultUserRequest = UsuarioContractFaker.UsuarioResponseBaseRequestAsync(userRequest.Nome);

            _mockUsuarioService.Setup(mock => mock.Put(userRequest, resultUserRequest.Result.Id)).Returns(resultUserRequest);

            var controller = new UsuarioController(_mockUsuarioService.Object);

            var result = await controller.Put(resultUserRequest.Result.Id, userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }

        [Fact(DisplayName = "Remove um usuario já existente")]
        public async Task Delete()
        {
            int id = UsuarioContractFaker.GetId();

            _mockUsuarioService.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));

            var controller = new UsuarioController(_mockUsuarioService.Object);

            try
            {
                await controller.Delete(id);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }
        }

    }
}

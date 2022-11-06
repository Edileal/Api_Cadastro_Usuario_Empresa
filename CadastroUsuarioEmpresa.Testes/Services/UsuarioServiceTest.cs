using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Services;
using CadastroUsuarioEmpresa.Testes.CrossCutting;
using CadastroUsuarioEmpresa.Testes.Fakers;
using Moq;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Services
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();

        [Fact(DisplayName = "Buscar usuário por Id")]
        public async Task GetById()
        {
            int id = UsuarioEntitiesFaker.GetUsuarioById();

            _mockUsuarioRepository.Setup(mock => mock.GetById(id)).Returns(UsuarioEntitiesFaker.UsuarioEntitiesAsync(id));

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var resultado = await service.GetById(id);

            Assert.Equal(resultado.Id, id);
        }

        [Fact(DisplayName = "Listar todos usuários")]
        public async Task Get()
        {
    
            _mockUsuarioRepository.Setup(mock => mock.Get()).Returns(UsuarioEntitiesFaker.UsuarioEntitiesAsync());

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Get();

            Assert.True(result.ToList().Count() > 0);
        }
        [Fact(DisplayName = "Cadastrar novo usuário")]
        public async Task Post()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            var userRequestEntities = await UsuarioEntitiesFaker.GetUsuarioEntities();
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseRequestAsync(userRequestEntities.Nome);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }
        [Fact(DisplayName = "Cadastrar novo usuário com nome null")]
        public async Task PostNomeNull()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            var userRequestEntities = await UsuarioEntitiesFaker.GetUsuarioEntities();
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseRequestAsync(userRequestEntities.Nome);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }
    }
}

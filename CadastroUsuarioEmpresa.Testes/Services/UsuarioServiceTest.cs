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
            var userRequestEntities = await UsuarioEntitiesFaker.UsuarioEntitiesBase(userRequest);
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseAsync(userRequestEntities);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            var result = await service.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }
        [Fact(DisplayName = "Cadastrar novo usuário com nome inválido")]
        public async Task PostNomeInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Nome = null;
            var userRequestEntities = await UsuarioEntitiesFaker.UsuarioEntitiesBase(userRequest);
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseAsync(userRequestEntities);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            try
            {
                await service.Post(userRequest);
            }
            catch (Exception e)
            {
                Assert.Equal("Nome inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com senha inválida")]
        public async Task PostSenhaInvalida()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Senha = "1";
            var userRequestEntities = await UsuarioEntitiesFaker.UsuarioEntitiesBase(userRequest);
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseAsync(userRequestEntities);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            try
            {
                await service.Post(userRequest);
            }
            catch (Exception e)
            {
                Assert.Equal("Senha inserida inválida", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com e-mail inválido")]
        public async Task PostEmailInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Email = "e";
            var userRequestEntities = await UsuarioEntitiesFaker.UsuarioEntitiesBase(userRequest);
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseAsync(userRequestEntities);

            _mockUsuarioRepository.Setup(mock => mock.Post(It.IsAny<UsuarioEntities>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            try
            {
                await service.Post(userRequest);
            }
            catch (Exception e)
            {
                Assert.Equal("E-mail inserido inválido", e.Message);
            }
        }
    }
}

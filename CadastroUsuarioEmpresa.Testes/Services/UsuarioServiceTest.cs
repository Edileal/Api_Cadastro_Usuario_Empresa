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
            userRequest.Nome = "";
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
        [Fact(DisplayName = "Cadastrar novo usuário com data de nascimento inválida")]
        public async Task PostDataNascimentoInvalida()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.DataNascimento = DateTime.Now;
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
                Assert.Equal("Data de nascimento inserida inválida", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com cpf inválido")]
        public async Task PostCpfInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Cpf = "12345678";
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
                Assert.Equal("Cpf inserido inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com cidade inválida")]
        public async Task PostEnderecoCidadeInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Cidade = null;
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
                Assert.Equal("Cidade inválida", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com rua inválida")]
        public async Task PostEnderecoRuaInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Rua = null;
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
                Assert.Equal("Rua inválida", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com bairro inválido")]
        public async Task PostEnderecoBairroInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Bairro = null;
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
                Assert.Equal("Bairro inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com cep inválido")]
        public async Task PostEnderecoCepInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Cep = "12";
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
                Assert.Equal("Cep inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com número inválido")]
        public async Task PostEnderecoNumeroInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Numero = "";
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
                Assert.Equal("Número inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Cadastrar novo usuário com Estado inválido")]
        public async Task PostEnderecoEstadoInvalido()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            userRequest.Endereco.Estado = "";
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
                Assert.Equal("Estado inválido", e.Message);
            }
        }
        [Fact(DisplayName = "Edita um usuário com sucesso")]
        public async Task Put()
        {

            var userRequest = UsuarioContractFaker.UsuarioCadastraRequest();
            var userRequestEntities = await UsuarioEntitiesFaker.UsuarioEntitiesBase(userRequest);
            var resultUserRequest = UsuarioEntitiesFaker.UsuarioEntitiesBaseAsync(userRequestEntities);

            _mockUsuarioRepository.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(resultUserRequest);
            _mockUsuarioRepository.Setup(mock => mock.Put(It.IsAny<UsuarioEntities>(), It.IsAny<int?>())).Returns(resultUserRequest);

            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);
            var result = await service.Put(userRequest, resultUserRequest.Result.Id);

            Assert.Equal(result.Email, resultUserRequest.Result.Email);
           
        }
        [Fact(DisplayName = "Remove um usuário com sucesso")]
        public async Task Delete()
        {
            int id = UsuarioEntitiesFaker.GetUsuarioById();

            _mockUsuarioRepository.Setup(mock => mock.Delete(id)).Returns(() => Task.FromResult(string.Empty));


            var service = new UsuarioService(_mockUsuarioRepository.Object, mapper);

            try
            {
                await service.Delete(id);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }

        }
    }
}

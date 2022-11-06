using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Services;
using CadastroUsuarioEmpresa.Testes.CrossCutting;
using CadastroUsuarioEmpresa.Testes.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Services
{
    public class EmpresaServiceTest
    {
        private readonly Mock<IEmpresaRepository> _mockEmpresaRepository = new Mock<IEmpresaRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();

        [Fact(DisplayName = "Buscar empresa por Id")]
        public async Task GetById()
        {
            int id = EmpresaEntitiesFaker.GetEmpresaById();

            _mockEmpresaRepository.Setup(mock => mock.GetById(id)).Returns(EmpresaEntitiesFaker.EmpresaEntitiesAsync(id));

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var resultado = await service.GetById(id);

            Assert.Equal(resultado.Id, id);
        }
        [Fact(DisplayName = "Listar todas empresas")]
        public async Task Get()
        {

            _mockEmpresaRepository.Setup(mock => mock.Get()).Returns(EmpresaEntitiesFaker.EmpresaEntitiesAsync());

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var result = await service.Get();

            Assert.True(result.ToList().Count() > 0);
        }
        [Fact(DisplayName = "Cadastrar nova empresa")]
        public async Task Post()
        {

            var userRequest = EmpresaContractFaker.EmpresaRequest();
            var userRequestEntities = await EmpresaEntitiesFaker.EmpresaEntitiesBase(userRequest);
            var resultUserRequest = EmpresaEntitiesFaker.EmpresaEntitiesBase(userRequestEntities);

            _mockEmpresaRepository.Setup(mock => mock.Post(It.IsAny<EmpresaEntities>())).Returns(resultUserRequest);

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var result = await service.Post(userRequest);

            Assert.Equal(result.Nome, resultUserRequest.Result.Nome);
        }
    }
}

using AutoMapper;
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

        [Fact(DisplayName = "Buscar usuário por Id")]
        public async Task GetById()
        {
            int id = EmpresaEntitiesFaker.GetEmpresaById();

            _mockEmpresaRepository.Setup(mock => mock.GetById(id)).Returns(EmpresaEntitiesFaker.EmpresaEntitiesAsync(id));

            var service = new EmpresaService(_mockEmpresaRepository.Object, mapper);

            var resultado = await service.GetById(id);

            Assert.Equal(resultado.Id, id);
        }
    }
}

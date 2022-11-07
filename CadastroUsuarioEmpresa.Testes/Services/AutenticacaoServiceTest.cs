using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Services;
using CadastroUsuarioEmpresa.Testes.CrossCutting;
using CadastroUsuarioEmpresa.Testes.Fakers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace CadastroUsuarioEmpresa.Testes.Services
{
    public class AutenticacaoServiceTest
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository = new Mock<IUsuarioRepository>();
        public IMapper mapper = new AutoMapperFixture().GetMapper();

        [Fact(DisplayName = "Login inválido")]
        public async Task LoginInvalido()
        {
            var user = UsuarioContractFaker.UsuarioCadastraRequest();

            var service = new AutenticacaoService(_mockUsuarioRepository.Object);

            _mockUsuarioRepository.Setup(mock => mock.GetByEmail(user.Email)).ReturnsAsync((UsuarioEntities)null);

            var exception = await Assert.ThrowsAsync<Exception>(() => service.Login(user.Email, user.Senha));

            Assert.Equal("Login inválido", exception.Message);
            
        }
        [Fact(DisplayName = "Login válido")]
        public async Task LoginValido()
        {
           /* var user = UsuarioContractFaker.UsuarioCadastraRequest();

            var service = new AutenticacaoService(_mockUsuarioRepository.Object);

            _mockUsuarioRepository.Setup(mock => mock.GetByEmail(user.Email)).Returns(() => Task.FromResult(string.Empty));

            //var result = service.Login(user.Email, user.Senha);

            try
            {
               await service.Login(user.Email, user.Senha);
            }
            catch (System.Exception)
            {
                Assert.True(false);
            }*/
            
        }
    }
}

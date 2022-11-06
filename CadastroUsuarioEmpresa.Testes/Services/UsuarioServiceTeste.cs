using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Services;
using CadastroUsuarioEmpresa.Testes.CrossCutting;
using CadastroUsuarioEmpresa.Testes.Fakers;
/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace CadastroUsuarioEmpresa.Testes.Services
{
    [TestClass]
    public class UsuarioServiceTeste
    {
        private readonly IMapper _mapper = new AutoMapperFixture().GetMapper();
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;

        [TestMethod]
        public async void TestCadastrarUsuarioNomeVazio()
        {
            var usuarioInvalido = UsuarioContractFaker.GetId();
            usuarioInvalido.Nome = "";
            var service = new UsuarioService (_mockUsuarioRepository.Object, _mapper);
            var result = await service.Post(usuarioInvalido)

            Assert.IsTrue(true);
        }
    }
}*/
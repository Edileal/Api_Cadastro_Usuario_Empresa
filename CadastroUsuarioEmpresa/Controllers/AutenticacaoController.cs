using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioEmpresa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        /// <summary>
        /// Essa rota te permite acessar o sistema com usuário e senha.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna um token</response>
        [HttpPost]
        public async Task<string> Login(string email, string senha)
        {
            return await _autenticacaoService.Login(email, senha);
        }
    }
}

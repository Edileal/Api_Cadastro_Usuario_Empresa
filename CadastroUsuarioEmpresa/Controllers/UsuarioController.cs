using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioEmpresa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        //Respostas de informação (100-199),
        //Respostas de sucesso (200-299),
        //Redirecionamentos (300-399)
        //Erros do cliente (400-499)
        //Erros do servidor (500-599)
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        /// <summary>
        /// Essa rota te permite buscar todos os usuário cadastrados sem visualizar cpf.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        [Authorize(Roles = "Administrador, Cliente")]
        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            return await _usuarioService.Get();
        }

        /// <summary>
        /// Essa rota te permite buscar todos os usuário cadastrados com a visualização do cpf
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, retorna uma lista de elementos</response>
        [HttpGet("Administrador")]
        [Authorize(Roles = "Administrador")]
        public async Task<IEnumerable<UsuarioAdminResponse>> GetAdmin()
        {
            return await _usuarioService.GetAdmin();
        }

        /// <summary>
        /// Essa rota retorna os usuarios Cadastrados por meio do Id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public async Task<UsuarioResponse> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        /// <summary>
        /// Essa rota permite que voce cadastre usuário
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e cadastra usuário</response>
        [HttpPost]
        public async Task<UsuarioResponse> Post(UsuarioCadastraRequest usuarioRequest)
        {
            return await _usuarioService.Post(usuarioRequest);
        }

        /// <summary>
        /// Essa rota permite que você modifique os atributos do usuário
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e fez a modificacao do usuario</response>
        [HttpPut("{id}")]
        public async Task<UsuarioResponse> Put(int id, UsuarioRequest usuarioRequest)
        {
            return await _usuarioService.Put(usuarioRequest, id);
        }

        /// <summary>
        /// Essa rota permite que você delete um usuário
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e fez a deleção de usuário</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _usuarioService.Delete(id);
        }
    }
}

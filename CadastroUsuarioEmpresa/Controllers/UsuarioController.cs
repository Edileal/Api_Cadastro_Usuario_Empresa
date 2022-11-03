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
        public readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            return await _usuarioService.Get();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<UsuarioResponse> GetById(int id)
        {
            return await _usuarioService.GetById(id);
        }

        [HttpPost]
        public async Task<UsuarioResponse> Post(UsuarioCadastraRequest usuarioRequest)
        {
            return await _usuarioService.Post(usuarioRequest);
        }

        [HttpPut("{id}")]
        public async Task<UsuarioResponse> Put(int id, UsuarioRequest usuarioRequest)
        {
            return await _usuarioService.Put(usuarioRequest, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _usuarioService.Delete(id);
        }
    }
}

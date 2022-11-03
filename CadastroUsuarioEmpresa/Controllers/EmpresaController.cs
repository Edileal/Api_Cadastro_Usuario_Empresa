using CadastroUsuarioEmpresa.Domain.Contracts.Empresa;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarioEmpresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        public readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            return await _empresaService.Get();
        }

        [HttpGet("{id}")]
        public async Task<EmpresaResponse> GetById(int id)
        {
            return await _empresaService.GetById(id);
        }

        [HttpPost]
        public async Task<EmpresaResponse> Post(EmpresaRequest empresaRequest)
        {
            return await _empresaService.Post(empresaRequest);
        }

        [HttpPut("{id}")]
        public async Task<EmpresaResponse> Put(int id, EmpresaRequest empresaRequest)
        {
            return await _empresaService.Put(empresaRequest, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _empresaService.Delete(id);
        }
    }
}

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
        /// <summary>
        /// Essa rota te permite buscar todos as empresas cadastradas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna uma lista de elementos</response>
        [HttpGet]
        public async Task<IEnumerable<EmpresaResponse>> Get()
        {
            return await _empresaService.Get();
        }

        /// <summary>
        /// Essa rota retorna as empresas cadastrados por meio do Id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Sucesso, retorna o elemento encontrado via ID</response>
        [HttpGet("{id}")]
        public async Task<EmpresaResponse> GetById(int id)
        {
            return await _empresaService.GetById(id);
        }

        /// <summary>
        /// Essa rota permite que você cadastre uma empresa
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e cadastra empresa</response>
        [HttpPost]
        public async Task<EmpresaResponse> Post(EmpresaRequest empresaRequest)
        {
            return await _empresaService.Post(empresaRequest);
        }

        /// <summary>
        /// Essa rota permite que voce modifique atributos da empresa
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e fez a modificacao da empresa</response>
        [HttpPut("{id}")]
        public async Task<EmpresaResponse> Put(int id, EmpresaRequest empresaRequest)
        {
            return await _empresaService.Put(empresaRequest, id);
        }

        /// <summary>
        /// Essa rota permite que voce Delete uma empresa
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e fez a delecao da empresa</response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _empresaService.Delete(id);
        }
    }
}

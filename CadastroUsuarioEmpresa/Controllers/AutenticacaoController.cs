﻿using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
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

        [HttpPost]
        public async Task<string> Login(string nome, string senha)
        {
            return await _autenticacaoService.Login(nome, senha);
        }
    }
}
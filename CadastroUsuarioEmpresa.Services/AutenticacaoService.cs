using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using CadastroUsuarioEmpresa.Domain.Shared;

namespace CadastroUsuarioEmpresa.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> Login(string nome, string senha)
        {
            var result = await _usuarioRepository.GetByEmail(nome);

            var _senhaCriptografada = Cryptography.Encrypt(senha);

            if (result != null && result.Senha == _senhaCriptografada)
            {
                return Token.GenerateToken(result);
            }

            throw new Exception("Login inválido");
        }
    }
}

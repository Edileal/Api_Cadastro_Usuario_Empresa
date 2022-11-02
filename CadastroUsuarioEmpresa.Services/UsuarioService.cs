using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using CadastroUsuarioEmpresa.Domain.Shared;

namespace CadastroUsuarioEmpresa.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly IEnderecoRepository _enderecoRepository;
        public readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioResponse>> Get()
        {
            var listaUsuariosRetornoBaseDados = await _usuarioRepository.Get();

            return _mapper.Map<IEnumerable<UsuarioResponse>>(listaUsuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> GetById(int id)
        {
            var usuariosRetornoBaseDados = await _usuarioRepository.GetById(id);

            return _mapper.Map<UsuarioResponse>(usuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> Post(UsuarioCadastraRequest usuarioRequest) // aqui cadastra um usuário com senha
        {
            var requestUsuarioEntities = _mapper.Map<UsuarioEntities>(usuarioRequest);

            requestUsuarioEntities.Senha = Cryptography.Encrypt(usuarioRequest.Senha);

            var usuarioCadastrado = await _usuarioRepository.Post(requestUsuarioEntities);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }

        public Task<UsuarioResponse> Post(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioResponse> Put(UsuarioRequest usuarioRequest, int? id)
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);

            usuarioBancoDeDados.Nome = usuarioRequest.Nome;

            var usuarioCadastrado = await _usuarioRepository.Put(usuarioBancoDeDados, null);

            return _mapper.Map<UsuarioResponse>(usuarioCadastrado);
        }

        public async Task Delete(int id)
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);

            if (usuarioBancoDeDados != null)
            {
                await _usuarioRepository.Delete(usuarioBancoDeDados);
            }
        }
    }
}

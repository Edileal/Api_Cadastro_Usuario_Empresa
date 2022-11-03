using AutoMapper;
using CadastroUsuarioEmpresa.Domain.Contracts.Endereco;
using CadastroUsuarioEmpresa.Domain.Contracts.Usuario;
using CadastroUsuarioEmpresa.Domain.Entities;
using CadastroUsuarioEmpresa.Domain.Interfaces.Repository;
using CadastroUsuarioEmpresa.Domain.Interfaces.Services;
using CadastroUsuarioEmpresa.Domain.Shared;
using System.Text.RegularExpressions;

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

        public async Task<UsuarioResponse> Post(UsuarioCadastraRequest usuarioRequest) 
        {
            Regex email = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+.[^@ \t\r\n]+");
            
            if (!email.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException("Email inválido");
            }

            if(usuarioRequest.Endereco.Rua == null)
            {
                throw new Exception("Rua inválida");
            }
            if (usuarioRequest.Endereco.Bairro == null)
            {
                throw new Exception("Bairro inválido");
            }
            if (usuarioRequest.Endereco.Cep.Length != 8)
            {
                throw new Exception("Cep inválido");
            }
            if (usuarioRequest.Endereco.Cidade == null)
            {
                throw new Exception("Cidade inválida");
            }
            if (usuarioRequest.Endereco.Estado == null)
            {
                throw new Exception("Bairro inválido");
            }
            if (usuarioRequest.Endereco.Numero == null)
            {
                throw new Exception("Número inválido");
            }

            if(await ValidarSenha(usuarioRequest.Senha) == false)
            {
                throw new Exception("Senha inválida");
            }

            if(usuarioRequest.DataNascimento == null)
            {
                throw new Exception("Data inválida");
            }
            if(await ValidarCpf(usuarioRequest.Cpf) == false)
            {
                throw new Exception("Cpf inválido");
            }

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

        public async Task Delete(int request)
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)request);

            if (usuarioBancoDeDados != null)
            {
                await _usuarioRepository.Delete(usuarioBancoDeDados);
            }
        }

        //Métodos de verificação
        private async Task<bool> ValidarEmail(string email)
        {
            Regex regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((.(?!.))|[-!#$%&'*+/=?^`{}|~\w]))(?<=[0-9a-zA-Z])@))(?([)([(\d{1,3}.){3}\d{1,3}])|(([0-9a-zA-Z][-\w][0-9a-zA-Z].)+[a-zA-Z]{2,6}))$");

            if (email == null)
            {
                return false;
            }
            if (!regexEmail.IsMatch(email))
            {
                return false;
            }
            return true;
        }
        private async Task<bool> ValidarNome(string nome)
        {
            if (nome == null || nome.Length < 3)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> ValidarSenha(string senha)
        {
            if(senha.Length < 8 && senha == null)
            {
                return false;
            }
            return true;
        }
        private async Task<bool> ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}

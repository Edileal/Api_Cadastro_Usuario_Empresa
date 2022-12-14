using AutoMapper;
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
        public readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
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
        public async Task<IEnumerable<UsuarioAdminResponse>> GetAdmin()
        {
            var listaUsuariosRetornoBaseDados = await _usuarioRepository.Get();

            return _mapper.Map<IEnumerable<UsuarioAdminResponse>>(listaUsuariosRetornoBaseDados);
        }

        public async Task<UsuarioResponse> Post(UsuarioCadastraRequest usuarioRequest) 
        {

            Regex email = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+.[^@ \t\r\n]+");
            
            if (!email.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException("E-mail inserido inválido"); //teste ok
            }

            if(await ValidarNome(usuarioRequest.Nome) == false)
            {
                throw new Exception("Nome inválido"); //teste ok
            }

            if (string.IsNullOrWhiteSpace(usuarioRequest.Endereco.Rua))
            {
                throw new Exception("Rua inválida"); //teste ok
            }

            if (string.IsNullOrWhiteSpace(usuarioRequest.Endereco.Bairro))
            {
                throw new Exception("Bairro inválido"); //teste ok
            }

            if (await ValidarCep(usuarioRequest.Endereco.Cep) == false)
            {
                throw new Exception("Cep inválido"); //teste ok
            }

            if (string.IsNullOrWhiteSpace(usuarioRequest.Endereco.Cidade))
            {
                throw new Exception("Cidade inválida"); //teste ok
            }

            if (string.IsNullOrWhiteSpace(usuarioRequest.Endereco.Estado))
            {
                throw new Exception("Estado inválido"); //teste ok
            }

            if (string.IsNullOrWhiteSpace(usuarioRequest.Endereco.Numero))
            {
                throw new Exception("Número inválido"); //teste ok
            }

            if(await ValidarSenha(usuarioRequest.Senha) == false)
            {
                throw new Exception("Senha não pode ser nula." +
                                     "Precisa conter ao menos um dígito." +
                                     "Deve conter ao menos uma letra minúscula." +
                                     "Deve conter ao menos uma letra maiúscula." +
                                     "Deve conter ao menos um caractere especial." +
                                     "Deve ter mais de 8 caracteres."); //teste ok
            }

            if (usuarioRequest.DataNascimento == null || usuarioRequest.DataNascimento >= DateTime.Now)
            {
                throw new Exception("Data de nascimento inserida inválida"); //teste ok
            }

            if (await ValidarCpf(usuarioRequest.Cpf) == false)
            {
                throw new Exception("Cpf inserido inválido"); //teste ok
            }

            if (await ValidarTelefone(usuarioRequest.Telefone) == false)
            {
                throw new Exception("Telefone inserido inválido"); //teste ok
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

        public async Task<UsuarioResponse> Put(UsuarioRequest usuarioRequest, int? id) //falta verificações
        {
            var usuarioBancoDeDados = await _usuarioRepository.GetById((int)id);


            Regex email = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+.[^@ \t\r\n]+");

            if (!email.IsMatch(usuarioRequest.Email))
            {
                throw new ArgumentException("E-mail inserido inválido");
            }

            if (usuarioRequest.Email == usuarioBancoDeDados.Email)
            {
                throw new ArgumentException("Não é possível alterar pelo mesmo e-mail. Escolha um e-mail válido.");
            }
            usuarioBancoDeDados.Email = usuarioRequest.Email;

            if (await ValidarNome(usuarioRequest.Nome) == false)
            {
                throw new Exception("Nome inserido inválido");
            }
            if (usuarioRequest.Nome == usuarioBancoDeDados.Nome)
            {
                throw new ArgumentException("Nome já utilizado. Escolha um nome diferente.");
            }
            usuarioBancoDeDados.Nome = usuarioRequest.Nome;

            if (await ValidarCpf(usuarioRequest.Cpf) == false)
            {
                throw new Exception("Cpf inserido inválido");
            }
            if (usuarioRequest.Cpf == usuarioBancoDeDados.Cpf)
            {
                throw new ArgumentException("Não é possível alterar pelo mesmo Cpf. Escolha um Cpf válido.");
            }
            usuarioBancoDeDados.Cpf = usuarioRequest.Cpf;

            if (await ValidarTelefone(usuarioRequest.Telefone) == false)
            {
                throw new Exception("Telefone inserido inválido");
            }
            usuarioBancoDeDados.Telefone = usuarioRequest.Telefone;

            if (usuarioRequest.DataNascimento == null || usuarioRequest.DataNascimento >= DateTime.Now)
            {
                throw new Exception("Data de nascimento inserida inválida");
            }
            usuarioBancoDeDados.DataNascimento = usuarioRequest.DataNascimento;


            var usuarioAtualizado = await _usuarioRepository.Put(usuarioBancoDeDados, null);

            return _mapper.Map<UsuarioResponse>(usuarioAtualizado);
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

        private async Task<bool> ValidarCep(string cep)
        {
            Regex regexCep = new Regex(@"^[0 - 9]{ 5}-[0 - 9]{ 3}$");
            if (regexCep.IsMatch(cep))
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
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(senha))
            {
                return false;
            }
            if (!hasUpperChar.IsMatch(senha))
            {
                return false;
            }
            if (!hasMiniMaxChars.IsMatch(senha))
            {

                return false;
            }
            if (!hasNumber.IsMatch(senha))
            {

                return false;
            }

            if (!hasSymbols.IsMatch(senha))
            {

                return false;
            }

            return true;
        }
        private async Task<bool> ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                return true;
            }
            Regex tel = new Regex(@"^\(?[1-9]{2}\)?\s?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$");

            if (!tel.IsMatch(telefone))
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
            var repetidos = int.Parse(string.Concat(cpf.GroupBy(x => x).Select(x => x.Count())));
            if (repetidos == 11)
                return false;

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

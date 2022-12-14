using CadastroUsuarioEmpresa.Domain.Enum;

namespace CadastroUsuarioEmpresa.Domain.Entities
{
    public class UsuarioEntities
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EnderecoId { get; set; }
        public EnderecoEntities Endereco { get; set; }
    }
}

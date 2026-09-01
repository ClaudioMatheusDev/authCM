namespace AuthCM.Application.Dtos
{
    public class UsuarioAtualizarDto
    {
        public required string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public  string Email { get; set; }
        public required string Documento { get; set; }
        public required string Telefone { get; set; }
    }
}

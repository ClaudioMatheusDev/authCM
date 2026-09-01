namespace AuthCM.Application.Dtos
{
    public class UsuarioCriarDto
    {
        public required string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Email { get; set; }
        public required string Documento { get; set; }
        public required string Telefone { get; set; }
        public required string Password { get; set; }
    }
}

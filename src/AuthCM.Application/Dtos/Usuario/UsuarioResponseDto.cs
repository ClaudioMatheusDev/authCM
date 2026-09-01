namespace AuthCM.Application.Dtos
{
    public class UsuarioResponseDto
    {
        public int IDUsuario { get; set; }
        public required string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Email { get; set; }
        public required string Documento { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}

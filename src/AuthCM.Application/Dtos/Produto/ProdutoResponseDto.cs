namespace AuthCM.Application.Dtos
{
    public interface ProdutoResponseDto
    {
        public int IDProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorProduto { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}

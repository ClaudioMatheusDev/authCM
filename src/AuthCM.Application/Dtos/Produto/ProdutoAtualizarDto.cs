namespace AuthCM.Application.Dtos
{
    public interface ProdutoAtualizarDto
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorProduto { get; set; }
    }
}

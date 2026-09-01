namespace AuthCM.Application.Dtos
{
    public interface ProdutoCriarDto
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorProduto { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AuthCM.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int IDProduto { get; set; }
        public required string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorProduto { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}

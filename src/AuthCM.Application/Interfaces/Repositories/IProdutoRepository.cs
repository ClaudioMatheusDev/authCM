using AuthCM.Domain.Entities;

namespace AuthCM.Application.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> BuscarProdutoPorIDAsync(int IDProduto);
        Task<List<Produto>> BuscarTodosProdutos();

        Task AdicionarProduto(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
        Task SalvarAlteracoesAsync();

    }
}

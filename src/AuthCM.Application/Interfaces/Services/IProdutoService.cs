using AuthCM.Application.Dtos;

namespace AuthCM.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<int> CriarProdutoAsync(ProdutoCriarDto dto);
        Task<ProdutoResponseDto> BuscarProdutoPorIDAsync(int IDProduto);
        Task<List<ProdutoResponseDto>> BuscarTodosProdutos();
        Task<bool> ApagarProdutoAsync(int IDProduto);
        Task<ProdutoResponseDto> AtualizarProdutoAsync(int IDProduto, ProdutoAtualizarDto dto);
    }
}

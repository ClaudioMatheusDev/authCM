using AuthCM.Application.Dtos;
using AuthCM.Domain.Entities;
using AuthCM.Application.Interfaces;
using AuthCM.Application.Interfaces.Services.Produto;

namespace AuthCM.Application.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<int> CriarProdutoAsync(ProdutoCriarDto dto)
        {
            var produto = new Produto
            {
                NomeProduto = dto.NomeProduto,
                Descricao = dto.Descricao,
                ValorProduto = dto.ValorProduto,
                DataCriacao = DateTime.UtcNow
            };

            await _produtoRepository.CriarProdutoAsync(produto);

            await _produtoRepository.SalvarAlteracoesAsync();

            return produto.IDProduto;
        }

        public async Task<ProdutoResponseDto> BuscarProdutoPorIDAsync(int IDProduto)
        {
            var produto = await _produtoRepository.BuscarProdutoPorIDAsync(IDProduto);

            return new ProdutoResponseDto
            {
                IDProduto = produto.IDProduto,
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                ValorProduto = produto.ValorProduto,
                DataCriacao = produto.DataCriacao,
                DataAtualizacao = produto.DataAtualizacao
            };
        }

        public async Task<List<ProdutoResponseDto>> BuscarTodosProdutos() 
        {
            var produto = await _produtoRepository.BuscarTodosProdutos();


            return produto.Select(produto => new ProdutoResponseDto
            {
                IDProduto = produto.IDProduto,
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                ValorProduto = produto.ValorProduto,
                DataCriacao = produto.DataCriacao,
                DataAtualizacao = produto.DataAtualizacao
            }).ToList();
        }

        public async Task<bool> ApagarProdutoAsync(int IDProduto)
        {
            var produto = await _produtoRepository.BuscarProdutoPorIDAsync(IDProduto);

            _produtoRepository.Remover(produto);

            await _produtoRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<ProdutoResponseDto> AtualizarProdutoAsync(int IDProduto, ProdutoAtualizarDto dto)
        {
            var produto = await _produtoRepository.BuscarProdutoPorIDAsync(IDProduto);


            produto.NomeProduto = dto.NomeProduto;
            produto.Descricao = dto.Descricao;
            produto.ValorProduto = dto.ValorProduto;
            produto.DataAtualizacao = DateTime.UtcNow;

            await _produtoRepository.SalvarAlteracoesAsync();

            return new ProdutoResponseDto
            {
                IDProduto = produto.IDProduto,
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                ValorProduto = produto.ValorProduto,
                DataCriacao = produto.DataCriacao,
                DataAtualizacao = produto.DataAtualizacao
            };

        }

    }
}

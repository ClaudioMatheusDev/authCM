using AuthCM.Application.Interfaces;   
using AuthCM.Domain.Entities;         
using Microsoft.EntityFrameworkCore;
using AuthCM.Infraestructure.Data;

namespace AuthCM.Infraestructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CriarProdutoAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task<Produto> BuscarProdutoPorIDAsync(int IDProduto)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.IDProduto == IDProduto);
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
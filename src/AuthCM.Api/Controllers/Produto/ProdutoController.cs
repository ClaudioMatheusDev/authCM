using AuthCM.Application.Dtos;
using AuthCM.Application.Interfaces.Services.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthCM.Api.Controllers.Produto
{
    [ApiController]
    [Route("api/produtos")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProdutoAsync([FromBody] ProdutoCriarDto dto)
        {
            var idProduto = await _produtoService.CriarProdutoAsync(dto);

            return Ok(new { IDProduto = idProduto });
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosProdutosAsync()
        {
            var produtos = await _produtoService.BuscarTodosProdutos();

            return Ok(produtos);
        }

        [HttpGet("{IDProduto:int}")]
        public async Task<IActionResult> BuscarProdutoPorID(int IDProduto)
        {
            var produto = await _produtoService.BuscarProdutoPorIDAsync(IDProduto);

            return Ok(produto);
        }
        [HttpPut("{IDProduto:int}")]
        public async Task<IActionResult> AtualizarProduto(int IDProduto, ProdutoAtualizarDto dto)
        {
            var produto = await _produtoService.AtualizarProdutoAsync(IDProduto, dto);

            return Ok(produto);
        }

        [HttpDelete("{IDProduto:int}")]
        public async Task<IActionResult> DeletarProduto(int IDProduto)
        {
            var produto = await _produtoService.ApagarProdutoAsync(IDProduto);
            return Ok(produto);
        }
    }
}

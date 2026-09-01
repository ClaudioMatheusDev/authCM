using AuthCM.Application.Dtos;
using AuthCM.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthCM.Api.Controllers.Usuario
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCriarDto dto)
        {
            try
            {
                var idUsuario = await _usuarioService.CriarUsuarioAsync(dto);

                return Ok(new { IDUsuario = idUsuario });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosUsuarios()
        {
            var usuarios = await _usuarioService.BuscarUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("{IDUsuario:int}")]
        public async Task<IActionResult> BuscarUsuarioPorID(int IDUsuario)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorIDAsync(IDUsuario);

            return Ok(usuario);
        }

        [HttpDelete("{IDUsuario:int}")]
        public async Task<IActionResult> DeletarUsuario(int IDUsuario)
        {
            try
            {
                var usuario = await _usuarioService.ApagarUsuarioAsync(IDUsuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{IDUsuario:int}")]
        public async Task<IActionResult> AtualizarUsuario(int IDUsuario, UsuarioAtualizarDto dto)
        {
            try
            {
                var usuario = await _usuarioService.AtualizarUsuarioAsync(IDUsuario, dto);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

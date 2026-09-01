using AuthCM.Application.Dtos;
using System.Numerics;

namespace AuthCM.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CriarUsuarioAsync(UsuarioCriarDto dto);
        Task<List<UsuarioResponseDto>> BuscarUsuarios();
        Task<UsuarioResponseDto> BuscarUsuarioPorIDAsync(int IDUsuario);
        Task<bool> ApagarUsuarioAsync(int IDUsuario);
        Task<UsuarioResponseDto> AtualizarUsuarioAsync(int IDUsuario, UsuarioAtualizarDto dto);
    }
}

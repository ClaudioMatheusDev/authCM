using AuthCM.Domain.Entities;

namespace AuthCM.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> BuscarUsuarioPorID(int IDUsuario);
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task AdicionarUsuarioAsync(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
        Task SalvarAlteracoesAsync();
    }
}

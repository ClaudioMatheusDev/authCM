using AuthCM.Application.Interfaces;
using AuthCM.Domain.Entities;
using AuthCM.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthCM.Infraestructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> BuscarUsuarioPorID(int IDUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IDUsuario == IDUsuario);
        }

        public void Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
             _context.Usuarios.Update(usuario);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

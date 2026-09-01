using AuthCM.Application.Dtos;
using AuthCM.Application.Interfaces;
using AuthCM.Domain.Entities;

namespace AuthCM.Application.Service
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<int> CriarUsuarioAsync(UsuarioCriarDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Documento = dto.Documento,
                Telefone = dto.Telefone,
                DataCriacao = DateTime.UtcNow
            };

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);

            await _usuarioRepository.SalvarAlteracoesAsync();

            return usuario.IDUsuario;

        }

        public async Task<UsuarioResponseDto> BuscarUsuarioPorIDAsync(int IDUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorID(IDUsuario);

            if (usuario is null)
            {
                throw new Exception("Não foi encontrado nenhum usuario.");
            }

            return new UsuarioResponseDto
            {
                IDUsuario = usuario.IDUsuario,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Documento = usuario.Documento,
                Telefone = usuario.Telefone,
                DataCriacao = usuario.DataCriacao,
                DataAtualizacao = usuario.DataAtualizacao
            };
        }

        public async Task<List<UsuarioResponseDto>> BuscarUsuarios()
        {
            var usuarios = await _usuarioRepository.BuscarTodosUsuarios();

            return usuarios.Select(usuarios => new UsuarioResponseDto
            {
                IDUsuario = usuarios.IDUsuario,
                Nome = usuarios.Nome,
                DataNascimento = usuarios.DataNascimento,
                Email = usuarios.Email,
                Documento = usuarios.Documento,
                Telefone = usuarios.Telefone,
                DataCriacao = usuarios.DataCriacao,
                DataAtualizacao = usuarios.DataAtualizacao
            }).ToList();
        }

        public async Task<bool> ApagarUsuarioAsync(int IDUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorID(IDUsuario);


            if (usuario is null)
            {
                throw new Exception("Não foi encontrado nenhum usuario.");
            }

            _usuarioRepository.Remover(usuario);
            await _usuarioRepository.SalvarAlteracoesAsync();

            return true;
        }

        public async Task<UsuarioResponseDto> AtualizarUsuarioAsync(int IDUsuario, UsuarioAtualizarDto dto)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorID(IDUsuario);

            if (usuario is null)
                {
                 throw new Exception("Não foi encontrado nenhum usuario.");  
                }

            usuario.Nome = dto.Nome;
            usuario.DataNascimento = dto.DataNascimento;
            usuario.Email = dto.Email;
            usuario.Documento = dto.Documento;
            usuario.Telefone = dto.Telefone;
            usuario.DataAtualizacao = DateTime.UtcNow;

            await _usuarioRepository.SalvarAlteracoesAsync();

            return new UsuarioResponseDto
            {
                IDUsuario = usuario.IDUsuario,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Documento = usuario.Documento,
                Telefone = usuario.Telefone,
                DataCriacao = usuario.DataCriacao,
                DataAtualizacao = usuario.DataAtualizacao
            };
        }
    }
}

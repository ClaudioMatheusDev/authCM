using AuthCM.Application.Dtos;
using AuthCM.Application.Interfaces;
using AuthCM.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthCM.Application.Service
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioService(IUsuarioRepository usuarioRepository, UserManager<IdentityUser> userManager)
        {
            _usuarioRepository = usuarioRepository;
            _userManager = userManager;
        }


        public async Task<int> CriarUsuarioAsync(UsuarioCriarDto dto)
        {
            var identityUser = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var identityResult = await _userManager.CreateAsync(identityUser, dto.Password);

            if (!identityResult.Succeeded)
            {
                throw new Exception(string.Join(" ", identityResult.Errors.Select(e => e.Description)));
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Documento = dto.Documento,
                Telefone = dto.Telefone,
                DataCriacao = DateTime.UtcNow,
                IdentityUserId = identityUser.Id
            };

            try
            {
                await _usuarioRepository.AdicionarUsuarioAsync(usuario);
                await _usuarioRepository.SalvarAlteracoesAsync();
            }
            catch
            {
                await _userManager.DeleteAsync(identityUser);
                throw;
            }

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

            if (usuario.IdentityUserId is not null)
            {
                var identityUser = await _userManager.FindByIdAsync(usuario.IdentityUserId);

                if (identityUser is not null)
                {
                    await _userManager.DeleteAsync(identityUser);
                }
            }

            return true;
        }

        public async Task<UsuarioResponseDto> AtualizarUsuarioAsync(int IDUsuario, UsuarioAtualizarDto dto)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorID(IDUsuario);

            if (usuario is null)
                {
                 throw new Exception("Não foi encontrado nenhum usuario.");
                }

            if (usuario.IdentityUserId is not null && !string.Equals(usuario.Email, dto.Email, StringComparison.OrdinalIgnoreCase))
            {
                var identityUser = await _userManager.FindByIdAsync(usuario.IdentityUserId);

                if (identityUser is not null)
                {
                    var emailResult = await _userManager.SetEmailAsync(identityUser, dto.Email);
                    var userNameResult = await _userManager.SetUserNameAsync(identityUser, dto.Email);

                    if (!emailResult.Succeeded || !userNameResult.Succeeded)
                    {
                        var erros = emailResult.Errors.Concat(userNameResult.Errors).Select(e => e.Description);
                        throw new Exception(string.Join(" ", erros));
                    }
                }
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

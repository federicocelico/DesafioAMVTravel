using AMVTravelBusiness.Enums;
using AMVTravelBusiness.Interfaces;
using AMVTravelData.Interfaces;
using System;
using AMVTravelBusiness.Exceptions;
using AMVTravelBusiness.Helpers;
using AMVTravelData.Models;

namespace AMVTravelBusiness.Clases
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Result<Usuario> Login(string nombreUsuario, string contraseña)
        {
            var usuario = _usuarioRepository.GetByNombreUsuario(nombreUsuario);

            if (usuario == null)
            {
                return Result<Usuario>.Failure(AuthErrorCode.UsuarioNoExiste);
            }

            if (usuario.Contraseña != contraseña)
            {
                return Result<Usuario>.Failure(AuthErrorCode.ContraseñaIncorrecta);
            }

            return Result<Usuario>.Success(usuario);
        }
    }
}

using AMVTravelBusiness.DTO;
using AMVTravelBusiness.Helpers;
using AMVTravelBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AMVTravelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _authService.Login(request.NombreUsuario, request.Contraseña);

            if (result.IsSuccess)
            {
                return Ok(new { Message = "Login exitoso", Usuario = result.Data });
            }
            else
            {
                return Unauthorized(new { Error = result.ErrorCode, Message = result.ErrorCode.GetDescription() });
            }
        }
    }
}

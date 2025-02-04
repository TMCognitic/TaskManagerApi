using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Bll.Entities;
using TaskManagerApi.Bll.Repositories;
using TaskManagerApi.Dtos;
using TaskManagerApi.Dtos.Mappers;
using TaskManagerApi.Infrastructure;

namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserDto dto)
        {
            try
            {
                _authRepository.Register(new User(dto.Nom, dto.Prenom, dto.Email, dto.Passwd));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorType = ex.GetType() });
            }            
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserDto dto)
        {
            try
            {
                User? user = _authRepository.Login(dto.Email, dto.Passwd);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user.ToUserDto(_tokenRepository.CreateToken(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorType = ex.GetType() });
            }
        }
    }
}

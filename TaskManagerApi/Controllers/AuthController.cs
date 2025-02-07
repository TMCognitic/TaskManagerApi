using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;
using TaskManagerApi.Dtos.Mappers;
using TaskManagerApi.Dtos.Utilisateurs;
using TaskManagerApi.Infrastructure;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

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
        public IActionResult Register(RegisterDto dto)
        {
            CommandResult result = _authRepository.Execute(new RegisterCommand(dto.Nom, dto.Prenom, dto.Email, dto.Passwd));
            
            if(result.IsFailure)
            {
                return BadRequest(new { result.ErrorMessage });
            }
            
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            try
            {
                QueryResult<Utilisateur> result = _authRepository.Execute(new LoginQuery(dto.Email, dto.Passwd));

                if (result.IsFailure && result.ErrorMessage == "Email et mot de passe incorrecte")
                {
                    return NotFound(result);
                }

                if (result.IsFailure)
                {
                    return BadRequest(result);
                }

                UtilisateurDto utilisateurDto = result.Result.ToUserDto();
                _tokenRepository.ApplyToken(utilisateurDto);

                return Ok(utilisateurDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorType = ex.GetType() });
            }
        }
    }
}

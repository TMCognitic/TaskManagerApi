using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Domain.Commands;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Queries;
using TaskManagerApi.Domain.Repositories;
using TaskManagerApi.Dtos.Taches;
using TaskManagerApi.Dtos.Utilisateurs;
using TaskManagerApi.Infrastructure;
using Tools.CQS.Commands;

namespace TaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TacheController : ControllerBase
    {
        private readonly UtilisateurDto _utilisateurCourant;
        private readonly ITacheRepository _tacheRepository;

        public TacheController(ITokenRepository tokenRepository, ITacheRepository tacheRepository)
        {
            _utilisateurCourant = tokenRepository.Utilisateur!;
            _tacheRepository = tacheRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tacheRepository.Execute(new GetTachesQuery(_utilisateurCourant.Id)));
        }

        [HttpGet("{tacheId}")]
        public IActionResult Get(int tacheId)
        {
            Tache? tache = _tacheRepository.Execute(new GetTacheByIdQuery(tacheId, _utilisateurCourant.Id));

            if (tache is null)
                return NotFound();

            return Ok(tache);
        }

        [HttpPost]
        public IActionResult Post(CreateTacheDto dto)
        {
            CommandResult result = _tacheRepository.Execute(new AddTacheCommand(dto.Titre, _utilisateurCourant.Id));
            if (result.IsFailure)
            {
#if DEBUG
                return BadRequest(new { result });
#else
                return BadRequest(new { ErrorMessage = "Something Wrong!!" });
#endif

            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTacheDto dto)
        {
            try
            {
                _tacheRepository.Execute(new UpdateTacheCommand(id, dto.Titre, dto.Status, _utilisateurCourant.Id));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ChangeStatusDto dto)
        {
            try
            {
                _tacheRepository.Execute(new ChangeTacheStatusCommand(id, dto.Status, _utilisateurCourant.Id));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

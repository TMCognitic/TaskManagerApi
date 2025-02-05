using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Bll.Entities;
using TaskManagerApi.Bll.Repositories;
using TaskManagerApi.Dtos.Taches;
using TaskManagerApi.Dtos.Utilisateurs;
using TaskManagerApi.Infrastructure;

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
            return Ok(_tacheRepository.Get(_utilisateurCourant.Id));
        }

        [HttpGet("{tacheId}")]
        public IActionResult Get(int tacheId)
        {
            Tache? tache = _tacheRepository.Get(tacheId, _utilisateurCourant.Id);

            if (tache is null)
                return NotFound();

            return Ok(tache);
        }

        [HttpPost]
        public IActionResult Post(CreateTacheDto dto)
        {
            try
            {
                _tacheRepository.Insert(new Tache(dto.Titre, _utilisateurCourant.Id));
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTacheDto dto)
        {
            try
            {
                _tacheRepository.Update(id, new Tache(dto.Titre, _utilisateurCourant.Id) { Status = dto.Status });
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
                _tacheRepository.ChangeStatus(id, dto.Status, _utilisateurCourant.Id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

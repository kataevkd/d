using Microsoft.AspNetCore.Mvc;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.DTO;

namespace ManageInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PfrController : ControllerBase
    {
        private readonly PfrInterface _PfrRepository;

        public PfrController(PfrInterface PfrRepository)
        {
            _PfrRepository= PfrRepository;
        }

        [HttpGet]
        public ICollection<PFR> GetPFRs()
        {
            var Pfrs = _PfrRepository.GetPFRs();
            return Pfrs;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPfrById(int id)
        {
            var Pfr = _PfrRepository.GetPFRsById(id);

            if (Pfr == null)
            {
                // Если Pfr не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var PfrDto = PfrDtoMapper.ToDto(Pfr);
            return Ok(PfrDto);
        }

        [HttpGet("[action]/{snils}")]
        public IActionResult GetPfrBySNILS(int snils)
        {
            var Pfr = _PfrRepository.GetPFRsBySNILS(snils);

            if (Pfr == null)
            {
                // Если Pfr не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var PfrDto = PfrDtoMapper.ToDto(Pfr);
            return Ok(PfrDto);
        }

        [HttpPost]
        public IActionResult CreatePfr([FromBody] PfrDto createPfr)
        {
            if (createPfr == null)
            {
                return BadRequest(ModelState);
            }

            /*var Pfr = _PfrRepository.GetPfrs()
                .Where(c => c.Id == createPfr.)
                .FirstOrDefault();

            if (Pfr != null)
            {
                ModelState.AddModelError("", "Pfr with this id already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newPfr = PfrDtoMapper.ToPFR(createPfr);

            if (!_PfrRepository.CreatePFR(newPfr))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }
        [HttpPut("{PfrId}")]
        public IActionResult UpdatePfr(int PfrId, [FromBody] PFR updatePfr)
        {
            if (updatePfr == null)
            {
                return BadRequest(ModelState);
            }

            if (PfrId != updatePfr.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_PfrRepository.UpdatePFR(updatePfr))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            
                   
            return NoContent();
        }
        [HttpDelete("{PfrId}")]
        public IActionResult DeletePfr(int PfrId)
        {
            if (!_PfrRepository.PFRExists(PfrId))
            {
                return NotFound();
            }

            var removePfr = _PfrRepository.GetPFRsById(PfrId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_PfrRepository.DeletePFR(removePfr))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }
    }
}
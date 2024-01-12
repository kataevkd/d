using Microsoft.AspNetCore.Mvc;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.DTO;

namespace ManageInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GibddController : ControllerBase
    {
        private readonly GibddInterface _GibddRepository;

        public GibddController(GibddInterface GibddRepository)
        {
            _GibddRepository= GibddRepository;
        }

        [HttpGet]
        public ICollection<GIBDD> GetGIBDDs()
        {
            var Gibdds = _GibddRepository.GetGIBDDs();
            return Gibdds;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGibddById(int id)
        {
            var Gibdd = _GibddRepository.GetGIBDDsById(id);

            if (Gibdd == null)
            {
                // Если Gibdd не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var GibddDto = GibddDtoMapper.ToDto(Gibdd);
            return Ok(GibddDto);
        }

        [HttpGet("[action]/{license}")]
        public IActionResult GetGibddByLicense(int license)
        {
            var Gibdd = _GibddRepository.GetGIBDDsByLicense(license);

            if (Gibdd == null)
            {
                // Если Gibdd не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var GibddDto = GibddDtoMapper.ToDto(Gibdd);
            return Ok(GibddDto);
        }

        [HttpPost]
        public IActionResult CreateGibdd([FromBody] GibddDto createGibdd)
        {
            if (createGibdd == null)
            {
                return BadRequest(ModelState);
            }

            /*var Gibdd = _GibddRepository.GetGibdds()
                .Where(c => c.Id == createGibdd.)
                .FirstOrDefault();

            if (Gibdd != null)
            {
                ModelState.AddModelError("", "Gibdd with this id already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGibdd = GibddDtoMapper.ToGIBDD(createGibdd);

            if (!_GibddRepository.CreateGIBDD(newGibdd))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }
        [HttpPut("{GibddId}")]
        public IActionResult UpdateGibdd(int GibddId, [FromBody] GIBDD updateGibdd)
        {
            if (updateGibdd == null)
            {
                return BadRequest(ModelState);
            }

            if (GibddId != updateGibdd.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_GibddRepository.UpdateGIBDD(updateGibdd))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            
                   
            return NoContent();
        }
        [HttpDelete("{GibddId}")]
        public IActionResult DeleteGibdd(int GibddId)
        {
            if (!_GibddRepository.GIBDDExists(GibddId))
            {
                return NotFound();
            }

            var removeGibdd = _GibddRepository.GetGIBDDsById(GibddId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_GibddRepository.DeleteGIBDD(removeGibdd))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ManageInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MvdController : ControllerBase
    {
        private readonly MvdInterface _mvdRepository;

        public MvdController(MvdInterface mvdRepository)
        {
            _mvdRepository= mvdRepository;
        }

        [HttpGet]
        public ICollection<MVD> GetMVDs()
        {
            var mvds = _mvdRepository.GetMVDs();
            return mvds;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetMvdById(int id)
        {
            var mvd = _mvdRepository.GetMVDsById(id);

            if (mvd == null)
            {
                // Если MVD не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var mvdDto = MvdDtoMapper.ToDto(mvd);
            return Ok(mvdDto);
        }
        [HttpGet("GetMVDsByName/{name}")]
        public IActionResult GetMVDsByName(string name)
        {
            var mvds = _mvdRepository.GetMVDsByName(name);
            if (mvds == null)
            {
                // Если MVD не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }
            var mvdsDto = MvdDtoMapper.ToDtoList(mvds);
            return Ok(mvdsDto);
        }

        [HttpGet("[action]/{passport}")]
        public IActionResult GetPersonByPassport(int passport)
        {
            var persona = _mvdRepository.GetPersonByPassport(passport);
            if (persona == null)
            {
                // Если person не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }
            
            return Ok(persona);
        }

        [HttpGet("[action]/{passport}")]
        public IActionResult GetMVDByPassport(int passport)
        {
            var mvd = _mvdRepository.GetMVDByPassport(passport);
            if (mvd == null)
            {
                // Если person не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }
            var mvddto = MvdDtoMapper.ToDto(mvd); 
            return Ok(mvddto);
        }

        [HttpPost]
        public IActionResult CreateMvd([FromBody] MvdDto createmvd)
        {
            if (createmvd == null)
            {
                ModelState.AddModelError("", "mvd is null");
                return BadRequest(ModelState);
            }

            /*var mvd = _mvdRepository.GetMVDs()
                .Where(c => c.Id == createmvd.)
                .FirstOrDefault();

            if (mvd != null)
            {
                ModelState.AddModelError("", "mvd with this id already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "model not valid");
                return BadRequest(ModelState);
            }

            var newmvd = MvdDtoMapper.ToMVD(createmvd);

            if (!_mvdRepository.CreateMvd(newmvd))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }
        [HttpPut("{mvdId}")]
        public IActionResult Updatemvd(int mvdId, [FromBody] MvdDtoWithId updatemvd)
        {
            if (updatemvd == null)
            {
                return BadRequest(ModelState);
            }

            if (mvdId != updatemvd.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var changemvd = MvdDtoMapper.ToMVDWithId(updatemvd);

            if (!_mvdRepository.UpdateMvd(changemvd))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{mvdId}")]
        public IActionResult DeleteMvd(int mvdId)
        {
            if (!_mvdRepository.MvdExists(mvdId))
            {
                return NotFound();
            }

            var removemvd = _mvdRepository.GetMVDsById(mvdId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_mvdRepository.DeleteMvd(removemvd))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }
    }
}
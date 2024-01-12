using Microsoft.AspNetCore.Mvc;
using ManageInformation.Infrastructure.Interfaces;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.DTO;

namespace ManageInformation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NalogovayaController : ControllerBase
    {
        private readonly NalogovayaInterface _nalogovayaRepository;

        public NalogovayaController(NalogovayaInterface NalogovayaRepository)
        {
            _nalogovayaRepository= NalogovayaRepository;
        }

        [HttpGet]
        public ICollection<Nalogovaya> GetNalogovayas()
        {
            var nalogovayas = _nalogovayaRepository.GetNalogovayas();
            return nalogovayas;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetNalogovayaById(int id)
        {
            var Nalogovaya = _nalogovayaRepository.GetNalogovayasById(id);

            if (Nalogovaya == null)
            {
                // Если Nalogovaya не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var NalogovayaDto = NalogovayaDtoMapper.ToDto(Nalogovaya);
            return Ok(NalogovayaDto);
        }

        [HttpGet("[action]/{inn}")]
        public IActionResult GetNalogovayaByINN(int inn)
        {
            var Nalogovaya = _nalogovayaRepository.GetNalogovayasByINN(inn);

            if (Nalogovaya == null)
            {
                // Если Nalogovaya не найден, возвращаем статус 404 (Not Found)
                return NotFound();
            }

            var NalogovayaDto = NalogovayaDtoMapper.ToDto(Nalogovaya);
            return Ok(NalogovayaDto);
        }

        [HttpPost]
        public IActionResult CreateNalogovaya([FromBody] NalogovayaDto createNalogovaya)
        {
            if (createNalogovaya == null)
            {
                return BadRequest(ModelState);
            }

            /*var Nalogovaya = _NalogovayaRepository.GetNalogovayas()
                .Where(c => c.Id == createNalogovaya.)
                .FirstOrDefault();

            if (Nalogovaya != null)
            {
                ModelState.AddModelError("", "Nalogovaya with this id already exist");
                return StatusCode(442, ModelState);
            }*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newNalogovaya = NalogovayaDtoMapper.ToNalogovaya(createNalogovaya);

            if (!_nalogovayaRepository.CreateNalogovaya(newNalogovaya))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfull created");
        }
        [HttpPut("{NalogovayaId}")]
        public IActionResult UpdateNalogovaya(int NalogovayaId, [FromBody] Nalogovaya updateNalogovaya)
        {
            if (updateNalogovaya == null)
            {
                return BadRequest(ModelState);
            }

            if (NalogovayaId != updateNalogovaya.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_nalogovayaRepository.UpdateNalogovaya(updateNalogovaya))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            
                   
            return NoContent();
        }
        [HttpDelete("{NalogovayaId}")]
        public IActionResult DeleteNalogovaya(int NalogovayaId)
        {
            if (!_nalogovayaRepository.NalogovayaExists(NalogovayaId))
            {
                return NotFound();
            }

            var removeNalogovaya = _nalogovayaRepository.GetNalogovayasById(NalogovayaId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_nalogovayaRepository.DeleteNalogovaya(removeNalogovaya))
            {
                ModelState.AddModelError("", "Something went wrong");

            }

            return NoContent();
        }
    }
}
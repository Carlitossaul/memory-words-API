using memory_words.Models;
using memory_words_api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace memory_words.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet("{loginId}")]
        public IActionResult Get(int loginId)
        {
            return Ok(_sectionService.GetSections(loginId));
        }

        [HttpPost("create")]
        public IActionResult Post([FromBody] Section section)
        {
            if (section.Name == null)
            {
                return BadRequest();
            }

            var result = _sectionService.AddSection(section);
            if (result != null)
            {
                return Ok(result); 
            }
            else
            {
                return BadRequest("Error creating section"); // Otra respuesta de error apropiada
            }
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var section = _sectionService.GetSection(id);
        //    if (section == null)
        //    {
        //        return NotFound();
        //    }
        //    _sectionService.DeleteSection(section);
        //    return NoContent();
        //}

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.BLL.Manager;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VedioController : ControllerBase
    {
        private readonly IVedioManager _vedioManager;

        public VedioController(IVedioManager vedioManager)
        {
            _vedioManager = vedioManager;
        }

        [HttpGet]
        public IActionResult GetAllVedios()
        {
            return Ok(_vedioManager.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetVedio(int id)
        {
            return Ok(_vedioManager.GetById(id));
        }

        [HttpPost]
        public IActionResult AddVedio(VedioAddDto vedioAddDto)
        {
            _vedioManager.Add(vedioAddDto);
            return Created();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteVedio(int id)
        {
            _vedioManager.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateVedio (VedioUpdateDto vedioUpdate)
        {
            _vedioManager.Update(vedioUpdate);
            return Ok();
        }
    }
}

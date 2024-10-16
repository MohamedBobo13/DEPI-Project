using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEducationPlatform.BLL.Dto.VideoDto;
using OnlineEducationPlatform.BLL.Manager.VideoManager;

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
        //Insturctor and Student can be get All Vedios
        public ActionResult GetAllVedios()
        {
            var AllVedios=_vedioManager.GetAll();
            if (AllVedios != null)
            {
                return Ok(AllVedios);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        //Insturctor and Student can be get Vedio
        public ActionResult GetVedio(int id)
        {
            var vedio=_vedioManager.GetById(id);
            if (vedio != null)
            {
                return Ok(vedio);
            }
            return NotFound();
        }

        [HttpPost]
        //Instructor can only Add vedio
        public ActionResult AddVedio(VedioAddDto vedioAddDto)
        {
            _vedioManager.Add(vedioAddDto);
            return Created();
        }

        [HttpDelete("{id:int}")]
        //Instructor can only delete Vedio
        public ActionResult DeleteVedio(int id)
        {
            _vedioManager.Delete(id);
            return Ok();
        }

        [HttpPut]
        // Instructor can only update vedio
        public ActionResult UpdateVedio (VedioUpdateDto vedioUpdate)
        {
            _vedioManager.Update(vedioUpdate);
            return Ok();
        }
    }
}

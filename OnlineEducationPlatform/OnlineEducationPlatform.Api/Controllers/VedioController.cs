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
        //Instructor and Student can get all Vedios
        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await _vedioManager.GetAllAsync();
            if (videos != null)
            {
                return Ok(videos);
            }
            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetVideo(int id)
        {
            var video = await _vedioManager.GetByIdAsync(id);
            if (video != null)
            {
                return Ok(video);
            }
            return NotFound();
        }



        [HttpDelete("{id:int}")]
        //Instructor only can delete Video
        public async Task<ActionResult> RemoveVideo(int id)
        {
            var video = await _vedioManager.GetByIdAsync(id);
            if (video != null)
            {
                var IsDeleted = await _vedioManager.DeleteAsync(id);
                if (IsDeleted)
                {
                    return Ok("Video Deleted Successfully");
                }
                return StatusCode(500, "An error occurred while deleting the Video.");

            }
            return NotFound();
        }
        [HttpPost]
        //Instructor only can add Vidoe
        public async Task<ActionResult<VedioAddDto>> AddVideo(VedioAddDto vedioAddDto)
        {
            var video = _vedioManager.AddAsync(vedioAddDto);
            if (video != null)
            {
                return Ok("Addition Succeeded");

            }
            return BadRequest("Failed To Add Video");

        }
        [HttpPut("{id:int}")]
        //Insturctor only can update Video
        public async Task<ActionResult> UpdateVideo(int id, VedioUpdateDto vedioUpdateDto)
        {
            if (id != vedioUpdateDto.Id)
            {
                return BadRequest("Id is not Identical");
            }
            var pdf = await _vedioManager.UpdateAsync(vedioUpdateDto);
            return Ok("Video is Updaded");

        }
    }
}

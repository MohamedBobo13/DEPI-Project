using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Manager.AccountManager;
using OnlineEducationPlatform.BLL.Manger.Accounts;

namespace OnlineEducationPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManger AccountManger;
        private readonly IUrlHelperFactory _urlHelperFactory;
        public AccountsController(IAccountManger accountManger, IUrlHelperFactory urlHelperFactory)
        {
            AccountManger=accountManger;
            _urlHelperFactory=urlHelperFactory;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto logindto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await AccountManger.Login(logindto);
            if (result.IsAuthenticated==false)
            {
                return BadRequest(result.message);
            }
            return Ok(result);
        }
       //[Authorize(Roles ="Admin")]
         [HttpPost("RegisterAdmin")]
        //[HttpPost]
        public async Task<IActionResult> Register([FromBody] RegesterAdminDto regesterDto)
        {
            //model is good and correct 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var urlHelper = Url;
            var result = await AccountManger.AdminRegister(regesterDto,urlHelper);

            if(result.IsAuthenticated==false)
            {
                return BadRequest(result.message );
            }
            return Ok(result);
        }

        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegesterStudentDto regesterDto)
        {
            //model is good and correct 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var urlHelper = Url;

            var result = await AccountManger.StudentRegister(regesterDto,urlHelper);
            if (result.IsAuthenticated == false)
            {
                return BadRequest(result.message);
            }
            return Ok(result);
        }

    }
}

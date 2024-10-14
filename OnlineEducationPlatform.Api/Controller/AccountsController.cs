using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public AccountsController(IAccountManger accountManger)
        {
            AccountManger=accountManger;
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

            var result = await AccountManger.AdminRegister(regesterDto);

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

            var result = await AccountManger.StudentRegister(regesterDto);
            if (result.IsAuthenticated == false)
            {
                return BadRequest(result.message);
            }
            return Ok(result);
        }

    }
}

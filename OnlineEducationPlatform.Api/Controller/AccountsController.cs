using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Manager.AccountManager;
using OnlineEducationPlatform.BLL.Manger.Accounts;
using OnlineQuiz.BLL.Dtos.Accounts;

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
                return BadRequest(result.message = "  Email has not been confirmed. Please check your inbox !!\" :\r\n ");
                                                  
            }
            return Ok(result.message = "Login Successful");
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }
            var responce = await AccountManger.ConfirmEmail(userId, token);
            if (responce.successed)

            {
                return Ok(new { message = "Email confirmed successfully" });
            }
            return BadRequest(responce.Errors);
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
            var urlHelper = Url;

            var result = await AccountManger.StudentRegister(regesterDto,urlHelper);
            if (result.IsAuthenticated == false)
            {
                return BadRequest(result.message);
            }
            return Ok(result.message= "Student has been registered successfully");
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }

            var UrlHepler = Url;
            var result = await AccountManger.ForgotPassword(forgotPasswordDto, UrlHepler);
            if (result.successed)
            {
                return Ok(new { message = "Password reset email sent successfully. Please check your inbox." });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }

            var UrlHepler = Url;
            var result = await AccountManger.ResetPassword(resetPasswordDto);
            if (result.successed)
            {
                return Ok(new { message = "Your password has been reset successfully." });
            }
            return BadRequest(result.Errors);
        }
    }
}

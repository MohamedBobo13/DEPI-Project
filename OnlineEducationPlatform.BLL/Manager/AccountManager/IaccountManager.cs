using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineEducationPlatform.BLL.Dto.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using OnlineQuiz.BLL.Dtos.Accounts;

namespace OnlineEducationPlatform.BLL.Manager.AccountManager
{
    public interface IAccountManger
    {
        Task<AuthModel> Login(LoginDto loginDto);
        Task<GeneralRespnose> ConfirmEmail(string userId, string token);
        Task<AuthModel> AdminRegister(RegesterAdminDto regesterAdminDto, IUrlHelper urlHelper);
        Task<AuthModel> StudentRegister(RegesterStudentDto regesterStudentDto, IUrlHelper urlHelper);
    }
}

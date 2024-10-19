using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineEducationPlatform.BLL.Dto.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Dto.RoleModel;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using OnlineQuiz.BLL.Dtos.Accounts;

namespace OnlineEducationPlatform.BLL.Manager.AccountManager
{
    public interface IAccountManger
    {
        Task<AuthModel> Login(LoginDto loginDto);
        Task<GeneralRespnose> ConfirmEmail(string userId, string token);
        Task<GeneralRespnose> ForgotPassword(ForgotPasswordDto forgotPasswordDto, IUrlHelper urlHelper);
        Task<GeneralRespnose> ResetPassword(ResetPasswordDto resetPasswordDto);
        Task<AuthModel> AdminRegister(RegesterAdminDto regesterAdminDto);
        Task<AuthModel> StudentRegister(RegesterStudentDto regesterStudentDto, IUrlHelper urlHelper);
        Task<string> AddRoleModel(AddRoleDto addRoleDto);
        //Task<string> AddNewRole(CreateRole createRole);
        //Task<string> DeleteRole(CreateRole createRole);
        Task<IdentityResult> CreateRole(CreateRole createRole);
        Task<IdentityResult> DeleteRole(CreateRole createRole);
    }
}

using OnlineEducationPlatform.BLL.Dto.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.AccountManager
{
    public interface IAccountManger
    {
        Task<AuthModel> Login(LoginDto loginDto);
        Task<AuthModel> Register(RegesterDto regesterDto);
    }
}

﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineEducationPlatform.BLL.Dto.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto;
using OnlineEducationPlatform.BLL.Manager.AccountManager;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineQuiz.BLL.Dtos.Accounts;
using OnlineQuiz.BLL.Managers.Accounts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineEducationPlatform.BLL.Manger.Accounts
{
    public class AccountManger : IAccountManger
    {
        private readonly UserManager<ApplicationUser> UserManager;//make sure if user send in db or not
        private readonly IConfiguration configuration;
        private readonly IEmailService _emailService;

        public AccountManger(UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailService emailService)//inject =>to use it
        {
            UserManager = userManager;
            this.configuration = configuration;
            _emailService = emailService;

        }

        public async Task<AuthModel> AdminRegister(RegesterAdminDto regesterAdminDto,IUrlHelper urlHelper)
        {

            if (await UserManager.FindByEmailAsync(regesterAdminDto.Email) is not null)
            {
                return new AuthModel { message = "Email is already registered!" };
            }
            if (await UserManager.FindByNameAsync(regesterAdminDto.UserName) is not null)
            {
                return new AuthModel { message = "Name is already registered!" };
            }

            ApplicationUser user = null;

            if (regesterAdminDto.UserType == TypeUser.Student)
            {
                user = new Student();
            }
            else if (regesterAdminDto.UserType == TypeUser.Instructor)
            {
                user = new Instructor();
            }
            else if (regesterAdminDto.UserType == TypeUser.Admin)
            {

                user = new DAL.Data.Models.Admin();
            }
            else
            {
                return new AuthModel { message = "Please Enter Your Role Correct!" };
            }

            user.Email = regesterAdminDto.Email;
            user.UserName = regesterAdminDto.UserName;
            user.PhoneNumber = regesterAdminDto.PhoneNumber;
            user.UserType = regesterAdminDto.UserType;

            IdentityResult identityResult = await UserManager.CreateAsync(user, regesterAdminDto.Password);//save in db and hashing password
            if (identityResult.Succeeded)
            {
                //  #region VerifyEmail
                // Generate the email confirmation token
                var emailConfirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                //  Generate the email confirmation link using UrlHelper
                var confirmationLink = urlHelper.Action("ConfirmEmail", "Accounts",
                    new { userId = user.Id, token = emailConfirmationToken }, "https");

                // Send  confirmation link  
                var confirmationEmailBody = $"Hello {user.UserName},\n\n" +
                                            "Thank you for joining our community at [ Online Eduaction Platform ] !\n\n" +
                                            "To activate your account, please verify your email by clicking the link below :\n\n" +
                                           $"{confirmationLink}\n\n" +
                                            "If you did not sign up for this account, no action is required on your part.\n\n" +
                                            "We’re excited to have you with us!\n\n" +
                                            " Best wishes,\n" +
                                            " [Online Education Platform Team]\n" +
                                            " Contact us: +201015868707 \n ";

                var res = await _emailService.SendEmailAsync(user.Email, "Confirm Your Email Address", confirmationEmailBody);




            }

            if (!identityResult.Succeeded)
            {
                var Errors = string.Empty;
                foreach (var error in identityResult.Errors)
                {
                    Errors += $"{error.Description},";
                }
                return new AuthModel { message = Errors };
            }

            var JwtSecurityToken = await CreateJwtToken(user);
            if (regesterAdminDto.UserType == TypeUser.Student)
            {
                await UserManager.AddToRoleAsync(user, "STUDENT"); ;
            }
            else if (regesterAdminDto.UserType == TypeUser.Instructor)
            {
                await UserManager.AddToRoleAsync(user, "INSTRUCTOR"); ;
            }
            else
            {
                await UserManager.AddToRoleAsync(user, "ADMIN");
            }

            return new AuthModel
            {
                Email = user.Email,
                ExpairationDate = JwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
                UserName = user.UserName,
                Type=user.UserType.ToString(),

            };
        }
        public async Task<AuthModel> StudentRegister(RegesterStudentDto regesterStudentDto, IUrlHelper urlHelper)
        {
            if (await UserManager.FindByEmailAsync(regesterStudentDto.Email) is not null)
            {
                return new AuthModel { message = "Email is already registered!" };
            }
            if (await UserManager.FindByNameAsync(regesterStudentDto.UserName) is not null)
            {
                return new AuthModel { message = "Name is already registered!" };
            }
            //if (regesterDto.UserType==TypeUser.Admin)
            //{
            //    return new AuthModel { message="Action denied: The super admin has not authorized the creation of an admin account!" };
            //}
            //if (regesterDto.UserType == TypeUser.Instructor)
            //{
            //    return new AuthModel { message="Action denied: The super admin has not authorized the creation of an instructor account!" };
            //}



            ApplicationUser user = new Student();
            user.Email = regesterStudentDto.Email;
            user.UserName = regesterStudentDto.UserName;
            user.PhoneNumber = regesterStudentDto.PhoneNumber;
            //
            user.UserType = TypeUser.Student;
            IdentityResult identityResult = await UserManager.CreateAsync(user, regesterStudentDto.Password);//save in db and hashing password

            if (identityResult.Succeeded)
            {
                //  #region VerifyEmail
                // Generate the email confirmation token
                var emailConfirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(user);

                //  Generate the email confirmation link using UrlHelper
                var confirmationLink = urlHelper.Action("ConfirmEmail", "Accounts",
                    new { userId = user.Id, token = emailConfirmationToken }, "https");

                // Send  confirmation link  
                //var confirmationEmailBody = $"Hello {user.UserName},\n\n" +
                //                            "Thank you for joining our community at [ Online Eduaction Platform ] !\n\n" +
                //                            "To activate your account, please verify your email by clicking the link below :\n\n" +
                //                           $"{confirmationLink}\n\n" +
                //                            "If you did not sign up for this account, no action is required on your part.\n\n" +
                //                            "We’re excited to have you with us!\n\n" +
                //                            " Best wishes,\n" +
                //                            " [Online Education Platform Team]\n" +
                //                            " Contact us: +201015868707 \n ";

                var confirmationEmailBody = $"Dear {user.UserName},\n\n" +
                             "Thank you for registering with us!\n\n" +
                             "To complete your registration, please confirm your email address by clicking the link below:\n" +
                             $"{confirmationLink}\n\n" +
                             "If you did not create an account, please ignore this email.\n\n" +
                             "Best regards,\n" +
                             "[Online Educaton Platform]\n" +
                             "[+20 101 586 8707]";

                var res = await _emailService.SendEmailAsync(user.Email, "Confirm Your Email Address", confirmationEmailBody);




            }



            if (!identityResult.Succeeded)
            {
                var Errors = string.Empty;
                foreach (var error in identityResult.Errors)
                {
                    Errors += $"{error.Description},";
                }
                return new AuthModel { message = Errors };
            }

            var JwtSecurityToken = await CreateJwtToken(user);
            //if (regesterDto.UserType == TypeUser.Student)
            //{
            //    await UserManager.AddToRoleAsync(user, "STUDENT"); ;
            //}


            return new AuthModel
            {
                Email = user.Email,
                ExpairationDate = JwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
                UserName = user.UserName,
                Type=user.UserType.ToString(),
                
            };

        }


        public async Task<AuthModel> Login(LoginDto loginDto)
        {
            AuthModel auth = new AuthModel();

            var User = await UserManager.FindByEmailAsync(loginDto.Email);
            if (User == null || !await UserManager.IsEmailConfirmedAsync(User))
            {
                auth.Errors.Add(User == null ? "Email not found. Please make sure the email is correct." :
                                  "Email not confirmed. Please check your inbox.");
                return auth;

            }



                if (User == null || !await UserManager.CheckPasswordAsync(User, loginDto.Password))
            {
                auth.message = "Email or Password is incorrect";
                return auth;
            }


            var JwtSecurityToken = await CreateJwtToken(User);
            var rolelist = await UserManager.GetRolesAsync(User);

            auth.IsAuthenticated = true;
            auth.Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
            auth.Email = User.Email;
            auth.UserName = User.UserName;
            auth.ExpairationDate = JwtSecurityToken.ValidTo;
            auth.Roles = rolelist.ToList();

            return auth;

        }



        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var UserClaims = await UserManager.GetClaimsAsync(user);
            var Roles = await UserManager.GetRolesAsync(user);
            var RoleClaims = new List<Claim>();
            foreach (var Rolename in Roles)
            {
                RoleClaims.Add(new Claim(ClaimTypes.Role, Rolename));
            }
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)

            }.Union(UserClaims)
            .Union(RoleClaims);

            var SecretKeyString = configuration.GetSection("SecratKey").Value;
            var SecreteKeyBytes = Encoding.ASCII.GetBytes(SecretKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(SecreteKeyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);//(secrete key + hash algorithm)


            var Expiredate = DateTime.Now.AddDays(2);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: Claims,
                signingCredentials: signingCredentials,
                expires: Expiredate
                );

            return jwtSecurityToken;

        }

        public async Task<GeneralRespnose> ConfirmEmail(string userId, string token)
        {
            GeneralRespnose response = new GeneralRespnose();
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                response.Errors.Add("UserId and Token are required.");
                return response;
            }

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                response.Errors.Add("User not found.");
                return response;
            }

            var result = await UserManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                response.successed = true;
                return response;

            }
            response.Errors.Add("Email confirmation failed."); ;
            return response;

        }



    }
}
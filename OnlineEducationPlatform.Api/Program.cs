
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineEducationPlatform.BLL.Manager.AccountManager;
using OnlineEducationPlatform.BLL.Manger.Accounts;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using OnlineEducationPlatform.BLL.Manager.EnrollmentManager;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repositories;
using OnlineEducationPlatform.BLL.AutoMapper;
using OnlineQuiz.BLL.Managers.Accounts;
using Microsoft.AspNetCore.Identity;
using OnlineEducationPlatform.BLL.Manager.quizresultmanager;
using OnlineEducationPlatform.BLL.Manager.Answermanager;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.CourseManager;
using OnlineEducationPlatform.BLL.Manager.LectureManager;
using OnlineEducationPlatform.BLL.Manager.VideoManager;
using OnlineEducationPlatform.DAL.Repo.CourseRepo;
using OnlineEducationPlatform.DAL.Repo.LectureRepo;
using OnlineEducationPlatform.DAL.Repo.VideoRepo;
using OnlineEducationPlatform.BLL.AutoMapper.LectureAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.CourseAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.VideoAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuizResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuesionAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.EnrollmnentAutoMapper;

namespace OnlineEducationPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EducationPlatformContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            }
          );
            builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = true;
                // Options.Password.RequiredLength=15;


            }).AddEntityFrameworkStores<EducationPlatformContext>().AddDefaultTokenProviders();
            builder.Services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = "JWT";//make sure token is true
                Options.DefaultChallengeScheme = "JWT";
                Options.DefaultScheme = "JWT";//return 401 => unauthorized or 403 => forbeden
            }).AddJwtBearer("JWT", Options =>
            {
                //secrete key
                var SecretKeyString = builder.Configuration.GetValue<string>("SecratKey");
                var SecreteKeyBytes = Encoding.ASCII.GetBytes(SecretKeyString);
                SecurityKey securityKey = new SymmetricSecurityKey(SecreteKeyBytes);
                //--------------------------------------------------------------

                Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    //false mean anyone can send and eny one can take
                    ValidateIssuer = true,//take token(backend)//make token
                    ValidateAudience = true//send token(frontend)//use token
                };
            });

            builder.Services.AddHttpContextAccessor();

            //        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddDefaultTokenProviders()
            //.AddEntityFrameworkStores<EducationPlatformContext>();
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddDefaultTokenProviders()
            //.AddEntityFrameworkStores<EducationPlatformContext>();


            builder.Services.AddAutoMapper(map => map.AddProfile(new LectureMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new PdfFileMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new VedioMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new CourseMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuizResultMappingProfile()));

            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerResultMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuestionMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new EnrollmentMappingProfile()));

            builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
           builder.Services.AddScoped<IEnrollmentRepo,EnrollmentRepo>();
            builder.Services.AddScoped<IenrollmentManager, EnrollmentManager>();

            builder.Services.AddScoped<IQuizResultRepo, QuizResultRepo>();
            builder.Services.AddScoped<IQuizResultManager, QuizResultManager>();


            builder.Services.AddScoped<IAccountManger, AccountManger>();

            builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
            builder.Services.AddScoped<IAnswerManager, AnswerManager>();

            builder.Services.AddScoped<IAnswerResultRepo, AnswerResultRepo>();
            builder.Services.AddScoped<IAnswerResultManager, AnswerResultManager>();

            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ILectureRepo, LectureRepo>();
            builder.Services.AddScoped<ILectureManager, LectureManager>();
            builder.Services.AddScoped<IPdfFileRepo, PdfFileRepo>();
            builder.Services.AddScoped<IPdfFileManager, PdfFileManager>();
            builder.Services.AddScoped<IVedioRepo, VedioRepo>();
            builder.Services.AddScoped<IVedioManager, VedioManager>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ICourseManager, CourseManager>();
            // builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericClass<>) );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

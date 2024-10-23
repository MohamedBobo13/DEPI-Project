using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.AutoMapper.ExamMappingProfile;
using OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.DAL.Repo.AnswerRepo;
using OnlineEducationPlatform.DAL.Repo.ExamRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using OnlineEducationPlatform.BLL.Manager.Answermanager;
using OnlineEducationPlatform.DAL.Repo.AnswerResultRepo;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.BLL.Manager.EnrollmentManager;
using OnlineEducationPlatform.BLL.Manager.ExamResultmanager;
using OnlineEducationPlatform.BLL.Manager.InstructorManager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;
using OnlineEducationPlatform.BLL.Manager.QuizResultManager;
using OnlineEducationPlatform.BLL.Manager.StudentManager;
using OnlineEducationPlatform.DAL.Repositories;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using OnlineEducationPlatform.DAL.Repo.InstructorRepo;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repo.StudentRepo;

namespace OnlineEducationPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EducationPlatformContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            }
          );

			
			builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new ExamMappingProfile()));
    
			builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
            builder.Services.AddScoped<IAnswerManager, AnswerManager>();

            builder.Services.AddScoped<IAnswerResultRepo, AnswerResultRepo>();
			builder.Services.AddScoped<IAnswerResultManager, AnswerResultManager>();
            
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
			builder.Services.AddScoped<ICourseManager, CourseManager>();
            
            builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
			builder.Services.AddScoped<IEnrollmentManager, EnrollmentManager>();
            
            builder.Services.AddScoped<IExamResultRepo, ExamResultRepo>();
			builder.Services.AddScoped<IExamManager, ExamManager>();
            
            builder.Services.AddScoped<IExamRepo, ExamRepo>();
			builder.Services.AddScoped<IExamResultmanager, ExamResultManager>();
            
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
			builder.Services.AddScoped<IInstructorManager, InstructorManager>();
            
            builder.Services.AddScoped<ILectureRepo, LectureRepo>();
			builder.Services.AddScoped<ILectureManager, LectureManager>();
            
            builder.Services.AddScoped<IPdfFileRepo, PdfFileRepo>();
			builder.Services.AddScoped<IPdfFileManager, PdfFileManager>();
            
            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
			builder.Services.AddScoped<IQuestionManager, QuestionManager>();
            
            builder.Services.AddScoped<IQuizRepo, QuizRepo>();
			builder.Services.AddScoped<IQuizManager, QuizManager>();
            
			
			builder.Services.AddScoped<IQuizResultRepo, QuizResultRepo>();
			builder.Services.AddScoped<IQuizResultManager, QuizResultManager>();
            
			builder.Services.AddScoped<IStudentRepo, StudentRepo>();
			builder.Services.AddScoped<IStudentManager, StudentManager>();




		






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

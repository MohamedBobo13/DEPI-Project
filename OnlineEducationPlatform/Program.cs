using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.AnswerResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.CourseAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.EnrollmnentAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.ExamMappingProfile;
using OnlineEducationPlatform.BLL.AutoMapper.ExamResultMapper;
using OnlineEducationPlatform.BLL.AutoMapper.InstructorAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.LectureAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuesionAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.QuizResultAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.StudentAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper.VideoAutoMapper;
using OnlineEducationPlatform.BLL.AutoMapper;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.BLL.Manager.Answermanager;
using OnlineEducationPlatform.BLL.Manager.Answerresultmanager;
using OnlineEducationPlatform.BLL.Manager.EnrollmentManager;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.Manager.ExamResultmanager;
using OnlineEducationPlatform.BLL.Manager.InstructorManager;
using OnlineEducationPlatform.BLL.Manager.Questionmanager;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.BLL.Manager.quizresultmanager;
using OnlineEducationPlatform.BLL.Manager.StudentManager;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.DAL.Repo.AnswerRepo;
using OnlineEducationPlatform.DAL.Repo.AnswerResultRepo;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using OnlineEducationPlatform.DAL.Repo.Iexamrepo;
using OnlineEducationPlatform.DAL.Repo.InstructorRepo;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using OnlineEducationPlatform.DAL.Repo.StudentRepo;
using OnlineEducationPlatform.DAL.Repositories;

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

			builder.Services.AddAutoMapper(map => map.AddProfile(new Examresultmappingprofile()));

			builder.Services.AddAutoMapper(map => map.AddProfile(new LectureMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new PdfFileMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new VedioMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new CourseMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new QuizResultMappingProfile()));

			builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerResultMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new QuestionMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new EnrollmentMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new StudentMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new InstructorMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMappingProfile()));
			builder.Services.AddAutoMapper(map => map.AddProfile(new ExamMappingProfile()));

		
			builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
			builder.Services.AddScoped<IenrollmentManager, EnrollmentManager>();

			builder.Services.AddScoped<IQuizResultRepo, QuizResultRepo>();
			builder.Services.AddScoped<IQuizResultManager, QuizResultManager>();

			builder.Services.AddScoped<IExamResultRepo, ExamResultRepo>();
			builder.Services.AddScoped<IExamResultmanager, examresultmanager>();

			builder.Services.AddScoped<IStudentRepo, StudentRepo>();
			builder.Services.AddScoped<Istudentmanager, Stuentmanager>();
			builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
			builder.Services.AddScoped<IInstructorManager, instructorManager>();

			builder.Services.AddScoped<IQuizRepo, QuizRepo>();
			builder.Services.AddScoped<IQuizManager, QuizManager>();
			//builder.Services.AddScoped<IQuizManager, QuizManager>();
			builder.Services.AddScoped<Iexamrepo, examrepo>();
			builder.Services.AddScoped<IExamManager, ExamManager>();




		

			builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
			builder.Services.AddScoped<IAnswerManager, AnswerManager>();

			builder.Services.AddScoped<IAnswerResultRepo, AnswerResultRepo>();
			builder.Services.AddScoped<IAnswerResultManager, AnswerResultManager>();

			builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
			builder.Services.AddScoped<IQuestionManager, QuestionManager>();
			
			builder.Services.AddScoped<ILectureRepo, LectureRepo>();
			builder.Services.AddScoped<ILectureManager, LectureManager>();
			builder.Services.AddScoped<IPdfFileRepo, PdfFileRepo>();
			builder.Services.AddScoped<IPdfFileManager, PdfFileManager>();
			builder.Services.AddScoped<IVedioRepo, VedioRepo>();
			builder.Services.AddScoped<IVedioManager, VedioManager>();
			builder.Services.AddScoped<ICourseRepo, CourseRepo>();
			builder.Services.AddScoped<ICourseManager, CourseManager>();




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

using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.AutoMapper.ExamMappingProfile;
using OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.BLL.Manager.ExamManager;
using OnlineEducationPlatform.BLL.Manager.QuizManager;
using OnlineEducationPlatform.DAL.Repo.AnswerRepo;
using OnlineEducationPlatform.DAL.Repo.ExamRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;

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
    
            builder.Services.AddScoped<IQuizRepo, QuizRepo>();
			builder.Services.AddScoped<IQuizManager, QuizManager>();

			
			builder.Services.AddScoped<IExamRepo, ExamRepo>();
			builder.Services.AddScoped<IExamManager, ExamManager>();




		

			builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();/*
			builder.Services.AddScoped<IAnswerManager, AnswerManager>();*/
			




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

using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.Mapper;
using OnlineEducationPlatform.BLL.Services.ExamService;
using OnlineEducationPlatform.BLL.Services.QuizService;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Repositories.ExamRepo;
using OnlineEducationPlatform.DAL.Repositories.QuizRepo;

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

            //Registering DbContext
            builder.Services.AddDbContext<EducationPlatformContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            }
            );
            //Registering QuizRepo,Service
            builder.Services.AddScoped<IQuizRepo, QuizRepo>();
            builder.Services.AddScoped<IQuizService, QuizService>();
            
            
            

            //Registering ExamRepo,Service
            builder.Services.AddScoped<IExamRepo, ExamRepo>();
            builder.Services.AddScoped<IExamService, ExamService>();

            

            //Registering Auto-Mapper
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuizMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new ExamMappingProfile()));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

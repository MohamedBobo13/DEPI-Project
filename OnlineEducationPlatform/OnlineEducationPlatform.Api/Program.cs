using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.AutoMapper;
using OnlineEducationPlatform.BLL.Manager;
using OnlineEducationPlatform.DAL.Data.DbHelper;
using OnlineEducationPlatform.DAL.Repositories;

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
            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new AnswerResultMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new QuestionMappingProfile()));

            builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
            builder.Services.AddScoped<IAnswerResultRepo, AnswerResultRepo>();
            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
            builder.Services.AddScoped<IAnswerManager, AnswerManager>();
            builder.Services.AddScoped<IAnswerResultManager, AnswerResultManager>();
            builder.Services.AddScoped<IQuestionManager, QuestionManager>();


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

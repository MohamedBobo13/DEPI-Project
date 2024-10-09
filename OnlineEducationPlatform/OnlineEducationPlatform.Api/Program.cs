
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
            builder.Services.AddAutoMapper(map => map.AddProfile(new LectureMappingProfile()));
            builder.Services.AddAutoMapper(map => map.AddProfile(new PdfFileMappingProfile()));
            builder.Services.AddScoped<ILectureRepo, LectureRepo>();
            builder.Services.AddScoped<ILectureManager, LectureManager>();
            builder.Services.AddScoped<IPdfFileRepo, PdfFileRepo>();
            builder.Services.AddScoped<IPdfFileManager, PdfFileManager>();

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

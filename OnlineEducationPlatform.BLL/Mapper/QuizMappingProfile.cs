using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.BLL.Dto.TestResultDto;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.BLL.Mapper
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            //Quiz
            CreateMap<Quiz, QuizAddDto>().ReverseMap();
            CreateMap<Quiz, QuizReadDto>().ReverseMap();
            CreateMap<Quiz, QuizUpdateDto>().ReverseMap();

            /*//QuizResult
            CreateMap<QuizResult, QuizResultReadDto>().ReverseMap();*/

            /*//Exam
            CreateMap<Exam, ExamAddDto>().ReverseMap();
            CreateMap<Exam, ExamReadDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();
            CreateMap<Quiz, QuizUpdateDto>().ReverseMap();*/

            /*//ExamResult
            CreateMap<ExamResult, ExamResultReadDto>().ReverseMap();
            CreateMap<Exam, ExamUpdateDto>().ReverseMap();*/
        }
    }
}

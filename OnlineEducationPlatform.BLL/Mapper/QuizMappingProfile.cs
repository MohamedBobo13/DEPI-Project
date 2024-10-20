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
        }
    }
}

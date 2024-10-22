using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.QuesionAutoMapper
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionReadVm>().ReverseMap();
            CreateMap<Question, QuestionExamUpdateVm>().ReverseMap();
            CreateMap<Question, QuestionQuizUpdateVm>().ReverseMap();
            CreateMap<Question, QuestionQuizAddVm>().ReverseMap();
            CreateMap<Question, QuestionCourseQuizReadVm>().ReverseMap();
            CreateMap<Question, QuestionExamAddVm>().ReverseMap();
            CreateMap<Question, QuestionCourseExamReadVm>().ReverseMap();
            CreateMap<QuestionReadVm, QuestionQuizUpdateVm>().ReverseMap();
            CreateMap<QuestionReadVm, QuestionExamUpdateVm>().ReverseMap();


        }
    }
}

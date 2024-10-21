using AutoMapper;
using OnlineEducationPlatform.BLL.QuizVm;
using OnlineEducationPlatform.BLL.ViewModels.QuizVm;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.QuizAutoMapper
{
    public class QuizMappingProfile:Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Quiz, QuizAddVm>().ReverseMap();
            CreateMap<Quiz, QuizReadVm>().ReverseMap();
            CreateMap<Quiz, QuizUpdateVm>().ReverseMap();
        }
    }
}

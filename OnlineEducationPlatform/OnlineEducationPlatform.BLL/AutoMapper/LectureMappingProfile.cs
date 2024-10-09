using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper
{
    public class LectureMappingProfile:Profile
    {
        public LectureMappingProfile()
        {
            CreateMap<Lecture, LectureAddDto>().ReverseMap();
            CreateMap<Lecture, LectureReadDto>().ReverseMap();
            CreateMap<Lecture, LectureUpdateDto>().ReverseMap();
        }
    }
}

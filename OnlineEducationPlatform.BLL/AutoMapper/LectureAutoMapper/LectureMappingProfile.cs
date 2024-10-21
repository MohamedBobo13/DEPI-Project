using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.LectureAutoMapper
{
    public class LectureMappingProfile : Profile
    {
        public LectureMappingProfile()
        {
            CreateMap<Lecture, LectureAddVm>().ReverseMap();
            CreateMap<Lecture, LectureReadVm>().ReverseMap();
            CreateMap<Lecture, LectureUpdateVm>().ReverseMap();
        }
    }
}

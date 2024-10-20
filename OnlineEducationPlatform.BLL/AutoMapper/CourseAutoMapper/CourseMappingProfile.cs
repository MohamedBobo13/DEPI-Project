using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.CourseAutoMapper
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseAddVm>().ReverseMap();
            CreateMap<Course, CourseReadVm>().ReverseMap();
            CreateMap<Course, CourseUpdateVm>().ReverseMap();
        }
    }
}

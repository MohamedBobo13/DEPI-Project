using AutoMapper;
using OnlineEducationPlatform.BLL.ViewModels.StudentVm;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.StudentAutoMapper
{
    public class StudentMappingProfile:Profile
    {
        public StudentMappingProfile()
        {
                CreateMap<Student, StudentReadVm>().ReverseMap();

        }
    }
}

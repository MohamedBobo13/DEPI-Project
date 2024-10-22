using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.InstructorDto;
using OnlineEducationPlatform.BLL.ViewModels.InstructorVm;
using OnlineEducationPlatform.DAL.Data.Models;

namespace OnlineEducationPlatform.BLL.AutoMapper.InstructorAutoMapper
{
	public class InstructorMappingProfile :Profile
    {
        public InstructorMappingProfile()
        {
           
            
                CreateMap<Instructor, InstructorReadVm>().ReverseMap();

            
        }
    }
}

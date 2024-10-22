using AutoMapper;
using OnlineEducationPlatform.BLL.ViewModels.VideoVm;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.AutoMapper.VideoAutoMapper
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<Video, VideoAddVm>().ReverseMap();
            CreateMap<Video, VideoReadVm>().ReverseMap();
            CreateMap<Video, VideoUpdateVm>().ReverseMap();
        }
    }
}

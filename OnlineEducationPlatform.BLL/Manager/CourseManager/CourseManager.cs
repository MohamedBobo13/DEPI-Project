using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.CourseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.CourseManager
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;

        public CourseManager(ICourseRepo courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        public void Add(CourseAddDto courseAddDto)
        {
            _courseRepo.Add(_mapper.Map<Course>(courseAddDto));
            SaveChanges();
        }

        public void Delete(int id)
        {
            _courseRepo.Delete(id);
            SaveChanges();
        }

        public IEnumerable<CourseReadDto> GetAll()
        {
            return _mapper.Map<List<CourseReadDto>>(_courseRepo.GetAll());
        }

        public CourseReadDto GetById(int id)
        {
            return _mapper.Map<CourseReadDto>(_courseRepo.GetById(id));
        }

        public void SaveChanges()
        {
            _courseRepo.SaveChanges();
        }

        public void Update(CourseUpdateDto courseUpdateDto)
        {
            _mapper.Map(courseUpdateDto, _courseRepo.GetById(courseUpdateDto.Id));
            SaveChanges();
        }
    }
}

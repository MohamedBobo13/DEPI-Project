using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Manager.LectureManager;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.LectureRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.LectureManager
{
    public class LectureManager : ILectureManager
    {
        private readonly ILectureRepo _lectureRepo;
        private readonly IMapper _mapper;

        public LectureManager(ILectureRepo lectureRepo, IMapper mapper)
        {
            _lectureRepo = lectureRepo;
            _mapper = mapper;
        }
        public void Add(LectureAddDto lectureAddDto)
        {
            _lectureRepo.Add(_mapper.Map<Lecture>(lectureAddDto));
            SaveChanges();
        }

        public void Delete(int id)
        {
            _lectureRepo.Delete(id);
            SaveChanges();
        }
        public IEnumerable<LectureReadDto> GetAll()
        {
            return _mapper.Map<List<LectureReadDto>>(_lectureRepo.GetAll());
        }

        public LectureReadDto GetById(int id)
        {
            return _mapper.Map<LectureReadDto>(_lectureRepo.GetById(id));
        }

        public void SaveChanges()
        {
            _lectureRepo.SaveChange();
        }

        public void Update(LectureUpdateDto lectureUpdateDto)
        {
            _mapper.Map(lectureUpdateDto, _lectureRepo.GetById(lectureUpdateDto.Id));
            SaveChanges();
        }
    }
}

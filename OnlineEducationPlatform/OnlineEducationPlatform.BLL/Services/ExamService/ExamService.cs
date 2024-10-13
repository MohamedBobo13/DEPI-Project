using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestDto;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories.ExamRepo;

namespace OnlineEducationPlatform.BLL.Services.ExamService
{
    public class ExamService : IExamService
    {
        private readonly ExamRepo _examRepo;
        private readonly IMapper _mapper;

        public ExamService(ExamRepo examRepo, IMapper mapper)
        {
            _examRepo = examRepo;
            _mapper = mapper;
        }
        public IEnumerable<ExamReadDto> GetAll()
        {
            return _mapper.Map<List<ExamReadDto>>(_examRepo.GetAll());
        }

        public ExamReadDto GetById(int id)
        {
            return _mapper.Map<ExamReadDto>(_examRepo.GetById(id));
        }
        public void Add(ExamAddDto examAddDto)
        {
            _examRepo.Add(_mapper.Map<Exam>(examAddDto));
            _examRepo.SaveChange();
        }

        public void Update(ExamUpdateDto examUpdateDto)
        {
            var ExamModel = _examRepo.GetById(examUpdateDto.Id);
            _mapper.Map<ExamUpdateDto, Exam>(examUpdateDto, ExamModel);
        }
        public void Delete(int id)
        {
            var ExamModel = _examRepo.GetById(id);
            _examRepo.Delete(ExamModel);
        }


        public void SaveChanges()
        {
            _examRepo.SaveChange();
        }

    }
}

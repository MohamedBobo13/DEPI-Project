using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.TestResultDto;
using OnlineEducationPlatform.DAL.Repositories.ExamResultRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Services.ExamResultService
{
    public class ExamResultService : IExamResultService
    {
        private readonly ExamResultRepo _examResultRepo;
        private readonly IMapper _mapper;

        public ExamResultService(ExamResultRepo examResultRepo, IMapper mapper)
        {
            _examResultRepo = examResultRepo;
            _mapper = mapper;
        }
        public IEnumerable<ExamResultReadDto> GetAll()
        {
            return _mapper.Map<List<ExamResultReadDto>>(_examResultRepo.GetAll());
        }

        public ExamResultReadDto GetById(int id)
        {
            return _mapper.Map<ExamResultReadDto>(_examResultRepo.GetById(id));
        }
        public void Delete(int id)
        {
            var ExamResultModel = _examResultRepo.GetById(id);
            _examResultRepo.Delete(ExamResultModel);
        }
        public void SaveChanges()
        {
            _examResultRepo.SaveChange();
        }
    }
}

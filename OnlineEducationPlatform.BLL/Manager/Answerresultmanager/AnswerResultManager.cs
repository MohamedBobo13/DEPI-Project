using AutoMapper;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.Answerresultmanager
{
    public class AnswerResultManager : IAnswerResultManager
    {
        private readonly IAnswerResultRepo _answerResultRepo;
        private readonly IMapper _mapper;

        public AnswerResultManager(IAnswerResultRepo answerResultRepo, IMapper mapper)
        {
            _answerResultRepo = answerResultRepo;
            _mapper = mapper;
        }
        public IEnumerable<AnswerResultReadDto> GetAll()
        {
            return _mapper.Map<List<AnswerResultReadDto>>(_answerResultRepo.GetAll());
        }
        public AnswerResultReadDto GetById(int id)
        {
            return _mapper.Map<AnswerResultReadDto>(_answerResultRepo.GetById(id));
        }
        public void Add(AnswerResultAddDto answerResultAddDto)
        {
            _answerResultRepo.Add(_mapper.Map<AnswerResult>(answerResultAddDto));
            _answerResultRepo.SaveChange();
        }
        public void Update(AnswerResultUpdateDto answerResultUpdateDto)
        {
            _answerResultRepo.Update(_mapper.Map(answerResultUpdateDto, _answerResultRepo.GetById(answerResultUpdateDto.Id)));
            _answerResultRepo.SaveChange();
        }

        public void Delete(int id)
        {
            var AnswerResultModel = _answerResultRepo.GetById(id);
            if (AnswerResultModel != null)
            {
                _answerResultRepo.Delete(AnswerResultModel);
                _answerResultRepo.SaveChange();
            }
        }

        public void SaveChange()
        {
            _answerResultRepo.SaveChange();
        }
    }
}

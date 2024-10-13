using OnlineEducationPlatform.BLL.Dto.TestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Services.QuizService
{
    public interface IQuizService
    {
        IEnumerable<QuizReadDto> GetAll();
        QuizReadDto GetById(int id);
        void Add(QuizAddDto quizAddDto);
        void Update(QuizUpdateDto quizUpdateDto);
        void Delete(int id);
        void SaveChanges();
    }
}

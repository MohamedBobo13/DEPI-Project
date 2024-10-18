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
        Task<List<QuizReadDto>> GetAllAsync();
        Task<QuizReadDto> GetByIdAsync(int id);
        Task AddAsync(QuizAddDto quizAddDto);
        Task UpdateAsync(QuizUpdateDto quizUpdateDto);
        Task DeleteAsync(int id);
    }
}

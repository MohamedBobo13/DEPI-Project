using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IQuizResultManager
    {
        Task<ServiceResponse<QuizResult>> GetQuizResultAsync(string studentid, int quizid);

    }
}

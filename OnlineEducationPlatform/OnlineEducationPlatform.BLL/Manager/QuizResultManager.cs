using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public class QuizResultManager:IQuizResultManager
    {
        private readonly Irepo _quizresult;

        public QuizResultManager(Irepo irepo)
        {
            _quizresult = irepo;
        }

        public async Task<ServiceResponse<QuizResult>> GetQuizResultAsync( string studentid,int quizid)
        {

            var quizres = new QuizResult
            {
                StudentId = studentid,
                QuizId = quizid,

            };
            var response = new ServiceResponse<QuizResult>();
            var student = await _quizresult.StudentExistsAsync(quizres.StudentId);
            if (student == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Student Result because Student with ID {quizres.StudentId} not found..";
                response.Success = false;

                return response;
                //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
            }
            var Quiz = await _quizresult.quizExistsAsync(quizres.QuizId);
            if (Quiz == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Student Result because Quiz with ID {quizres.QuizId} not found..";
                response.Success = false;
                return response;
                //throw new KeyNotFoundException($"Student with ID {enrollment.CourseId} not found.");
            }
            var existingquizresult = await _quizresult.quizresultExistsAsync(quizres.StudentId, quizres.QuizId);
            if (existingquizresult == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Student Result because Student with ID {quizres.StudentId} in  Quiz with ID {quizres.QuizId} Is Not Existed.";
                response.Success = false;
                return response;
                // throw new InvalidOperationException($"Student {enrollment.StudentId} is already enrolled in course {enrollment.CourseId}.");
            }
            else
            {
                var quizresult = await _quizresult.GetQuizResultForStudentAsync(quizres.StudentId, quizres.QuizId);
                response.Data = new QuizResult
                {
                    Id = quizresult.Id,
                    StudentId = quizresult.StudentId,
                    QuizId = quizresult.QuizId,
                    Score = quizresult.Score,
                    TotalMarks = quizresult.TotalMarks,

                };
                response.Message = "Student Degree In Quiz.";

                response.Success = true;
                return response;
            }
            return response;
        }
    }
}

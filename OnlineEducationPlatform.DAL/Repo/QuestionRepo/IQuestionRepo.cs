﻿using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.QuestionRepo
{
    public interface IQuestionRepo
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<IEnumerable<Question>> GetAllExamAsync();
        Task<IEnumerable<Question>> GetAllQuizAsync();
        Task<Question> GetByIdAsync(int id);
        Task DeleteAsync(Question question);
        Task UpdateAsync(Question question);
        Task AddAsync(Question question);
        Task<bool> QuizIdExist(int quizId);
        Task<bool> ExamIdExist(int examId);
        Task SaveChangeAsync();
    }
}

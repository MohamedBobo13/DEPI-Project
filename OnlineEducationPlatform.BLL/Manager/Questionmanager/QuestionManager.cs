using AutoMapper;
using OnlineEducationPlatform.BLL.Dto.QuestionDto;
using OnlineEducationPlatform.BLL.Dtos;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.QuestionRepo;
using OnlineEducationPlatform.DAL.Repositories;

namespace OnlineEducationPlatform.BLL.Manager.Questionmanager
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepo _questionRepo;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionRepo questionRepo, IMapper mapper)
        {
            _questionRepo = questionRepo;
            _mapper = mapper;
        }
        public List<QuestionReadVm> GetAll()
        {
            var questions =  _questionRepo.GetAll().Select(a=>new QuestionReadVm
            {
                Id = a.Id,
                Content = a.Content,
            }).ToList();
            return questions;
        }

        public List<QuestionCourseExamReadVm> GetCourseExam(int courseId)
        {
            var questionsCourseExam =  _questionRepo.GetCourseExam(courseId);
            if (questionsCourseExam == null)
            {
                return null;
            }
            return _mapper.Map<List<QuestionCourseExamReadVm>>(questionsCourseExam);
        }

        public List<QuestionCourseQuizReadVm> GetCourseQuiz(int courseId)
        {
            var questionsCourseQuiz =  _questionRepo.GetCourseQuiz(courseId);
            if (questionsCourseQuiz == null)
            {
                return null;
            }
            return _mapper.Map<List<QuestionCourseQuizReadVm>>(questionsCourseQuiz);
        }


        public  QuestionReadVm GetById(int id)
        {
            var question =  _questionRepo.GetById(id);

            if (question == null)
                return null;

            return _mapper.Map<QuestionReadVm>(question);
        }
        public void AddExam(QuestionExamAddVm questionExamAddVm)
        {
             _questionRepo.Add(_mapper.Map<Question>(questionExamAddVm));
        }

        public void AddQuiz(QuestionQuizAddVm questionQuizAddVm)
        {
             _questionRepo.Add(_mapper.Map<Question>(questionQuizAddVm));
        }
        public void UpdateExam(QuestionExamUpdateVm questionExamUpdateVm)
        {
            var existingQuestionExam =  _questionRepo.GetById(questionExamUpdateVm.Id);
            if (existingQuestionExam == null)
            {
                return;
            }
            _questionRepo.Update(_mapper.Map(questionExamUpdateVm, existingQuestionExam));
        }

        public void UpdateQuiz(QuestionQuizUpdateVm questionQuizUpdateVm)
        {
            var existingQuestionQuiz =  _questionRepo.GetById(questionQuizUpdateVm.Id);
            if (existingQuestionQuiz == null)
            {
                return;
            }
            _questionRepo.Update(_mapper.Map(questionQuizUpdateVm, existingQuestionQuiz));
        }
        public void Delete(int id)
        {
            var questionModel =  _questionRepo.GetById(id);
            if (questionModel != null)
            {
                 _questionRepo.Delete(questionModel);
            }
        }

        
        //public   Task<bool> IdForExam(int questionId)
        //{
        //    bool idForExam = await _questionRepo.IdForExam(questionId);
        //    if (idForExam)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public   Task<bool> IdForQuiz(int questionId)
        //{

        //    bool idForQuiz = await _questionRepo.IdForQuiz(questionId);
        //    if (idForQuiz)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public   Task<bool> QuizIdExist(int quizId)
        //{
        //    bool quizExist = await _questionRepo.QuizIdExist(quizId);
        //    if (quizExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public   Task<bool> ExamIdExist(int examId)
        //{
        //    bool examExist = await _questionRepo.ExamIdExist(examId);
        //    if (examExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public   Task<bool> CourseIdExist(int courseId)
        //{
        //    bool courseExist = await _questionRepo.CourseIdExist(courseId);
        //    if (courseExist)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
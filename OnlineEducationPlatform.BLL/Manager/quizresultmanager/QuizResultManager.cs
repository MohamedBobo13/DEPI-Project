using AutoMapper;
using OnlineEducationPlatform.BLL.Dto;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using OnlineEducationPlatform.DAL.Repo.QuizRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.quizresultmanager
{
    public class QuizResultManager : IQuizResultManager
    {
        private readonly IQuizResultRepo _quizresult;

        private readonly IMapper _mapper; 

        public QuizResultManager(IQuizResultRepo irepo, IMapper mapper)
        {
            _quizresult = irepo;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<quizresultreaddto>>> GetAllQuizResults()
        {
            
            
                var response = new ServiceResponse<List<quizresultreaddto>>();
                try
                {
                    var QuizResults = await _quizresult.GetAllQuizResultsAsync();
                    if (QuizResults == null || QuizResults.Any() == false)
                    {
                        response.Message = "There Are No QuizResults yet !!";
                        response.Success = true;



                    }
                    else
                    {

                        // Map the domain entities to DTOs
                        response.Data = _mapper.Map<List<quizresultreaddto>>(QuizResults);
                        response.Message = "There Are Quiz Results : ";
                        response.Success = true;
                    }
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = $"Error fetching Quiz Results: {ex.Message}";

                }
                return response;

            
        }

        public async Task<ServiceResponse<QuizResult>> GetQuizResultAsync(string studentid, int quizid)
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
        public async Task<ServiceResponse<bool>> softdeletequizresult(string StudentId, int quizid)
        {
            //var enrollment = new Enrollment
            //{
            //    StudentId = enrollmentDto.StudentId,
            //    CourseId = enrollmentDto.CourseId,

            //};

            var enrollment = await _quizresult.GetQuizResultByStudentAndQuizAsyncwithnosoftdeleted(StudentId, quizid);

            var response = new ServiceResponse<bool>();
            try

            {

                var softdeletedenrollment = await _quizresult.IsQuizResultSoftDeletedAsync(StudentId, quizid);

                if (softdeletedenrollment == true)
                {

                    response.Message = $"Failed to soft delete Quiz Result because Quiz Result is already soft deleted ";
                    response.Success = false;
                    return response;


                }
                if (enrollment == null)
                {
                    response.Success = false;
                    response.Message = "Failed to delete Quiz REsult because it is not existed !!";
                    return response;
                }



                //var student = await _enrollmentRepository.StudentExistsAsync(enrollment.StudentId);
                //if (student == false)
                //{
                //    response.Data = false;
                //    response.Message = $"Failed to delete enrollment because Student with ID {enrollment.StudentId} not found..";
                //    response.Success = false;

                //    return response;
                //    //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
                //}
                //var Course = await _enrollmentRepository.CourseExistsAsync(enrollment.CourseId);
                //if (Course == false)
                //{
                //    response.Data = false;
                //    response.Message = $"Failed to delete enrollment because Course with ID {enrollment.CourseId} not found..";
                //    response.Success = false;
                //    return response;
                //    //throw new KeyNotFoundException($"Student with ID {enrollment.CourseId} not found.");
                //}
                //var existingEnrollments = await _enrollmentRepository.EnrollmentExistsAsync(enrollment.StudentId, enrollment.CourseId);
                //if (existingEnrollments == false)
                //{
                //    response.Data = false;
                //    response.Message = $"Failed to delete enrollment because it is not existed .";
                //    response.Success = false;
                //    return response;
                //    // throw new InvalidOperationException($"Student {enrollment.StudentId} is already enrolled in course {enrollment.CourseId}.");
                //}


                var saveresult = await _quizresult.RemoveAsync(enrollment.StudentId, enrollment.QuizId);

                // await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);


                if (saveresult)
                {
                    //  await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
                    response.Data = true;

                    response.Message = "Student Soft deleted successfully.";

                    response.Success = true;


                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";

            }
            return response;


        }
        public async Task<ServiceResponse<bool>> updatequizresultbyid(updatequizresultdto quizresultreaddto)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var getquizresult = await _quizresult.GetQuizResultsByIdIgnoreSoftDeleteAsync(quizresultreaddto.id);
                if (getquizresult == null)
                {
                    response.Success = false;
                    response.Message = $"Quiz result with Id {quizresultreaddto.id} not existed";
                    return response;
                }
                var softdeletedquizresult = await _quizresult.IsQuizResultSoftDeletedAsyncbyid(quizresultreaddto.id);
                if (softdeletedquizresult == true)
                {
                    response.Success = false;
                    response.Message = $"Quiz result with Id {quizresultreaddto.id} is soft deleted";
                    return response;
                }
              
                
                

                
                //var existingquizresult = await _quizresult.quizresultExistsAsyncbyid(quizresultreaddto.id);
                //if (existingquizresult == true)
                //{

                //    response.Message = $"Failed to save Quiz result because with ID {quizresultreaddto.id} already exist.";
                //    response.Success = false;
                //    return response;
                //    // throw new InvalidOperationException($"Student {enrollment.StudentId} is already enrolled in course {enrollment.CourseId}.");
                //}
                getquizresult.Id = quizresultreaddto.id;

              
            
                getquizresult.TotalMarks = quizresultreaddto.TotalMarks;
                getquizresult.Score = quizresultreaddto.Score;


                await _quizresult.UpdateQuizResultAsync(getquizresult);
                response.Success = true;
                response.Message = "Quiz result Updated Successfully";
                //if (saveresult == true)
                //{
                //    response.Success = true;
                //    response.Message = "Enrollment Updated Successfully";
                //    return response;
                //}
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }
            return response;
        }
        public async Task<ServiceResponse<List<quizresultwithoutiddto>>> GetAllSoftDeletedQuizresultsAsync()
        {
            var response = new ServiceResponse<List<quizresultwithoutiddto>>();
            try
            {
                var quizresults = await _quizresult.GetAllSoftDeletedQuizResultstsAsync();

                if (quizresults == null || quizresults.Any() == false)
                {
                    response.Message = "There Are No Soft Deleted Quiz results yet !!";
                    response.Success = true;



                }
                else
                {


                    
                    response.Data = _mapper.Map<List<quizresultwithoutiddto>>(quizresults);
                    response.Message = "There Are Soft Deleted Quiz Results : ";
                    response.Success = true;
                }



            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error fetching Quiz Results: {ex.Message}";

            }
            return response;


        }
        public async Task<ServiceResponse<bool>> HardDeleteEQuizresulttByStudentAndquizsync(string studentId, int quizid)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var quizResult = await _quizresult.GetQuizresultByStudentAndQuizAsync(studentId, quizid);

                if (quizResult == null)
                {
                    response.Success = false;
                    response.Message = "Failed to Hard Delete Quiz result because it is not existed !!";
                    return response;
                }

                if (quizResult.IsDeleted)
                {
                    await _quizresult.HardDeleteQuizResultAsync(quizResult);
                    response.Success = true;
                    response.Message = "Quiz result Hard Deleted Successfully.";


                }
                else
                {
                    response.Success = false;
                    response.Message = "Quiz result is not soft deleted. Please soft delete it before hard deletion.";

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";

            }
            return response;

        }
    }
}

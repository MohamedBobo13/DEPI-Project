using Azure;
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.BLL.Dto.EnrollmentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.EnrollmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.EnrollmentManager
{
    public class EnrollmentManager : IenrollmentManager
    {
        private readonly IEnrollmentRepo _enrollmentRepository;

        public EnrollmentManager(IEnrollmentRepo repo)
        {
            _enrollmentRepository = repo;
        }

        public async Task<ServiceResponse<EnrollmentDtowWithStatusanddDate>> CreateEnrollmentAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = new Enrollment
            {
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId,

            };

            var response = new ServiceResponse<EnrollmentDtowWithStatusanddDate>();

            var student = await _enrollmentRepository.StudentExistsAsync(enrollment.StudentId);
            if (student == false)
            {
                response.Data = null;
                response.Message = $"Failed to save enrollment because Student with ID {enrollment.StudentId} not found..";
                response.Success = false;

                return response;
                //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
            }
            var Course = await _enrollmentRepository.CourseExistsAsync(enrollment.CourseId);
            if (Course == false)
            {
                response.Data = null;
                response.Message = $"Failed to save enrollment because Course with ID {enrollment.CourseId} not found..";
                response.Success = false;
                return response;
                //throw new KeyNotFoundException($"Student with ID {enrollment.CourseId} not found.");
            }
            var existingEnrollments = await _enrollmentRepository.EnrollmentExistsAsync(enrollment.StudentId, enrollment.CourseId);
            if (existingEnrollments == true)
            {
                response.Data = null;
                response.Message = $"Failed to save enrollment because Student with ID {enrollment.StudentId} in  Course with ID {enrollment.CourseId} already enrolled.";
                response.Success = false;
                return response;
                // throw new InvalidOperationException($"Student {enrollment.StudentId} is already enrolled in course {enrollment.CourseId}.");
            }

            enrollment.EnrollmentDate = DateTime.Now;
            enrollment.Status = EnrollmentStatus.Enrolled;
            await _enrollmentRepository.AddAsync(enrollment);
            var saveresult = await _enrollmentRepository.CompleteAsync();
            if (saveresult)
            {
                response.Data = new EnrollmentDtowWithStatusanddDate
                {
                    StudentId = enrollment.StudentId,
                    CourseId = enrollment.CourseId,
                    EnrollmentDate = enrollment.EnrollmentDate,
                    Status = EnrollmentStatus.Enrolled.ToString(),
                };

                response.Message = "Enrollment added successfully.";

                response.Success = true;


            }
            return response;

        }

        public async Task<ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            var response = new ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>();
            try
            {
                var Courseexists = await _enrollmentRepository.CourseExistsAsync(courseId);
                if (Courseexists == false)
                {
                    response.Message = $"Course with ID {courseId} does not exist.";
                    response.Success = false;
                    response.Data = null;

                    return response;

                }
                var enrollments = await _enrollmentRepository.GetByCourseIdAsync(courseId);
                if (enrollments.Any() == false || enrollments == null)
                {
                    response.Message = $"Course with ID {courseId} does not have any students.";
                    response.Success = false;
                    response.Data = null;

                    return response;

                }
                else
                {

                    response.Data = enrollments.Select(e => new EnrollmentDtoForRetriveAllEnrollmentsInCourse
                    {
                        EnrollmentId = e.Id,
                        StudentId = e.StudentId,
                        CourseId = e.CourseId,
                        status = e.Status.ToString(),
                        EnrollmentDate = e.EnrollmentDate
                    }).ToList();
                    response.Message = $"There are enrollments in the course.";
                    response.Success = true;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";

            }
            return response;
        }

        public async Task<ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>> GetEnrollmentsByStudentIdAsync(string studentId)
        {
            var response = new ServiceResponse<List<EnrollmentDtoForRetriveAllEnrollmentsInCourse>>();
            try
            {
                var Studentexist = await _enrollmentRepository.StudentExistsAsync(studentId);
                if (Studentexist == false)
                {
                    response.Message = $"Student with ID {studentId} does not exist.";
                    response.Success = false;
                    response.Data = null;

                    return response;

                }
                var enrollments = await _enrollmentRepository.GetByStudentIdAsync(studentId);
                if (enrollments.Any() == false || enrollments == null)
                {
                    response.Message = $"Student with ID {studentId} does not have any Enrollments.";
                    response.Success = false;
                    response.Data = null;

                    return response;

                }
                else
                {

                    response.Data = enrollments.Select(e => new EnrollmentDtoForRetriveAllEnrollmentsInCourse
                    {
                        EnrollmentId = e.Id,
                        StudentId = e.StudentId,
                        CourseId = e.CourseId,
                        status = e.Status.ToString(),
                        EnrollmentDate = e.EnrollmentDate
                    }).ToList();
                    response.Message = $"There Are Enrollments For The Student.";
                    response.Success = true;
                    return response;

                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";

            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UnenrollFromCourseByStudentAndCourseIdAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = new Enrollment
            {
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId,

            };

            var response = new ServiceResponse<bool>();
            var student = await _enrollmentRepository.StudentExistsAsync(enrollment.StudentId);
            if (student == false)
            {
                response.Data = false;
                response.Message = $"Failed to delete enrollment because Student with ID {enrollment.StudentId} not found..";
                response.Success = false;

                return response;
                //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
            }
            var Course = await _enrollmentRepository.CourseExistsAsync(enrollment.CourseId);
            if (Course == false)
            {
                response.Data = false;
                response.Message = $"Failed to delete enrollment because Course with ID {enrollment.CourseId} not found..";
                response.Success = false;
                return response;
                //throw new KeyNotFoundException($"Student with ID {enrollment.CourseId} not found.");
            }
            var existingEnrollments = await _enrollmentRepository.EnrollmentExistsAsync(enrollment.StudentId, enrollment.CourseId);
            if (existingEnrollments == false)
            {
                response.Data = false;
                response.Message = $"Failed to delete enrollment because it is not existed .";
                response.Success = false;
                return response;
                // throw new InvalidOperationException($"Student {enrollment.StudentId} is already enrolled in course {enrollment.CourseId}.");
            }

            var saveresult = await _enrollmentRepository.RemoveAsync(enrollment.StudentId, enrollment.CourseId);

            if (saveresult)
            {
                response.Data = true;

                response.Message = "Student UnEnrolled successfully.";

                response.Success = true;


            }
            return response;


        }







    }
}

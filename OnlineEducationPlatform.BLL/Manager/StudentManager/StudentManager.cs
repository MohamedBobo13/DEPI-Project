using AutoMapper;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.StudentVm;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.StudentRepo;

namespace OnlineEducationPlatform.BLL.Manager.StudentManager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepo _studentrepo;
        private readonly IMapper _mapper;

        public StudentManager(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentrepo = studentRepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<StudentReadVm>>> GetAllStudentsAsync()
        {
            var response = new ServiceResponse<List<StudentReadVm>>();
            try
            {
                var Students = await _studentrepo.GetAllStudents();
                if (Students == null || Students.Any() == false)
                {
                    response.Message = "There Are No Students yet or all Students are soft deleted !!";
                    response.Success = false;
                    return response;


                }
               
              
               
                else
                {

                    // Map the domain entities to DTOs
                    response.Data = _mapper.Map<List<StudentReadVm>>(Students);
                    response.Message = "There Are Students : ";
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error fetching Studens: {ex.Message}";

            }
            return response;
        }
        public async Task<ServiceResponse<StudentReadVm>> Getstudentbyid(string studentid)
        {
            var student = new Student
            {
                Id = studentid,
              

            };
            var response = new ServiceResponse<StudentReadVm>();
            var studentexist = await _studentrepo.StudentExistsAsync(studentid);
            if (studentexist == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Student  because Student with ID {studentid} not found..";
                response.Success = false;

                return response;
                //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
            }
            var softdeletedstudent = await _studentrepo.IsStudentSoftDeletedAsync(studentid);
            if (softdeletedstudent == true)
            {

                response.Data = null;
                response.Message = $"Failed to Get Student because Student with  Id {studentid} already exist but it is soft deleted.";
                response.Success = false;
                return response;
            }
            
           

         
           
            else
            {
                var getstudent = await _studentrepo.GetStudentByIdAsync(studentid);
                response.Data = new StudentReadVm
                {
                    Id = getstudent.Id,
                    Username = getstudent.UserName,
                    Email = getstudent.Email,
                    phone = getstudent.PhoneNumber,
                   

                };
                response.Message = "Student Information :.";

                response.Success = true;
                return response;
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> softdeleteStudent(string studentId)
        {

            var student = await _studentrepo.GetStudentByIdAsyncsoftornot(studentId);

            var response = new ServiceResponse<bool>();
            try

            {

                var softdeletedstudent = await _studentrepo.IsStudentSoftDeletedAsync(studentId);

                if (softdeletedstudent == true)
                {

                    response.Message = $"Failed to soft delete Student because Student is already soft deleted ";
                    response.Success = false;
                    return response;


                }
                if (student == null)
                {
                    response.Success = false;
                    response.Message = "Failed to delete Student because it is not existed !!";
                    return response;
                }






                var saveresult = await _studentrepo.RemoveAsync(student);




                if (saveresult)
                {

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

    }
}

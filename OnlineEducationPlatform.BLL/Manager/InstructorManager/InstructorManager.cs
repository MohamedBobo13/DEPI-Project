using AutoMapper;
using OnlineEducationPlatform.BLL.handleresponse;
using OnlineEducationPlatform.BLL.ViewModels.InstructorVm;
using OnlineEducationPlatform.DAL.Data.Models;
using OnlineEducationPlatform.DAL.Repo.InstructorRepo;

namespace OnlineEducationPlatform.BLL.Manager.InstructorManager
{
    public class InstructorManager : IInstructorManager
    {

        private readonly IInstructorRepo _instructorrepo;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepo instructorrepo, IMapper mapper)
        {
            _instructorrepo = instructorrepo;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<InstructorReadVm>>> GetAllInstructorsAsync()
        {
            var response = new ServiceResponse<List<InstructorReadVm>>();
            try
            {
                var instructors = await _instructorrepo.GetAllInstructors();
                if (instructors == null || instructors.Any() == false)
                {
                    response.Message = "There Are No Instructors yet or all Instructors are soft deleted!!";
                    response.Success = false;
                    return response;


                }
                
               
             
                else
                {

                    // Map the domain entities to DTOs
                    response.Data = _mapper.Map<List<InstructorReadVm>>(instructors);
                    response.Message = "There Are Instructors : ";
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

        public async Task<ServiceResponse<InstructorReadVm>> GetInstructorbyid(string InstructorId)
        {
            var instructor = new Instructor
            {
                Id = InstructorId,


            };
            var response = new ServiceResponse<InstructorReadVm>();
            var instructorexist = await _instructorrepo.InstructorExistsAsync(InstructorId);
            if (instructorexist == false)
            {
                response.Data = null;
                response.Message = $"Failed to Get Instructor because Instructor with ID {InstructorId} not found..";
                response.Success = false;

                return response;
                //  throw new KeyNotFoundException($"Student with ID {enrollment.StudentId} not found.");
            }
            var softdeletedinstructor = await _instructorrepo.IsInstructorSoftDeletedAsync(InstructorId);
            if (softdeletedinstructor == true)
            {

                response.Data = null;
                response.Message = $"Failed to Get Instructor because Instructor with  Id {InstructorId} already exist but it is soft deleted.";
                response.Success = false;
                return response;
            }





            else
            {
                var getstudent = await _instructorrepo.GetInstructorByIdAsync(InstructorId);
                response.Data = new InstructorReadVm
                {
                    Id = getstudent.Id,
                    Username = getstudent.UserName,
                    Email = getstudent.Email,
                    phone = getstudent.PhoneNumber,


                };
                response.Message = "Instructor Information :.";

                response.Success = true;
                return response;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> softdeleteInstructor(string InstructorId)
        {
            var instructor = await _instructorrepo.GetInstructorByIdAsyncsoftornot(InstructorId);

            var response = new ServiceResponse<bool>();
            try

            {

                var softdeletedstudent = await _instructorrepo.IsInstructorSoftDeletedAsync(InstructorId);

                if (softdeletedstudent == true)
                {

                    response.Message = $"Failed to soft delete Instructor because Instructor is already soft deleted ";
                    response.Success = false;
                    return response;


                }
                if (instructor == null)
                {
                    response.Success = false;
                    response.Message = "Failed to delete Instructor because it is not existed !!";
                    return response;
                }






                var saveresult = await _instructorrepo.RemoveAsync(instructor);




                if (saveresult)
                {

                    response.Data = true;

                    response.Message = "Instructor Soft deleted successfully.";

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

using OnlineEducationPlatform.BLL.Dto.Quizresultsdto;
using OnlineEducationPlatform.BLL.Dto.StudentDto;
using OnlineEducationPlatform.BLL.handleresponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.StudentManager
{
    public interface Istudentmanager
    {
        Task<ServiceResponse<List<studentreadVm>>> GetAllStudentsAsync();

        Task<ServiceResponse<studentreadVm>> Getstudentbyid(string studentid);
        Task<ServiceResponse<bool>> softdeleteStudent(string studentId);
        bool IdExist(string studentId);
    }
}

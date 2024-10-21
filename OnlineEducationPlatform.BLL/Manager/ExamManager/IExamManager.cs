using OnlineEducationPlatform.BLL.ViewModels.ExamReadVm;
using OnlineEducationPlatform.BLL.ViewModels.ExamVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.ExamManager
{
    public interface IExamManager
    {
        Task<List<ExamReadVm>> GetAllAsync();
        Task<ExamReadVm> GetByIdAsync(int id);
        Task<ExamAddVm> AddAsync(ExamAddVm examAddDto);
        Task <ExamUpdateVm> Update(ExamUpdateVm examUpdateDto);
        Task DeleteAsync(int id);
    }
}

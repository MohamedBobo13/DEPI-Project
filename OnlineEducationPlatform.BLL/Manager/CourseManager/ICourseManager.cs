using OnlineEducationPlatform.BLL.Dto.CourseDto;
using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ICourseManager
    {
        Task AddAsync(CourseAddVm courseAddVm);
        Task<IEnumerable<CourseReadVm>> GetAllAsync();
        Task<CourseReadVm> GetByIdAsync(int id);
        Task<CourseUpdateVm> UpdateAsync(CourseUpdateVm courseUpdateVm);
        Task<bool> DeleteAsync(int id);
        
    }
}

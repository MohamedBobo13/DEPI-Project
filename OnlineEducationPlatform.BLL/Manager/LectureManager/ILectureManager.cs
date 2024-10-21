using OnlineEducationPlatform.BLL.Dto.LectureDto;
using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ILectureManager
    {
        Task AddAsync(LectureAddVm lectureAddDto);
        Task<IEnumerable<LectureReadVm>> GetAllAsync();
        Task<LectureReadVm> GetByIdAsync(int id);
        Task<LectureUpdateVm> UpdateAsync(LectureUpdateVm lectureUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}

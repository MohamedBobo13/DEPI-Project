using OnlineEducationPlatform.BLL.ViewModels.VideoDto;
using OnlineEducationPlatform.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface IVedioManager
    {
        Task AddAsync(VedioAddVm vedioAddDto);
        Task<IEnumerable<VedioReadVm>> GetAllAsync();
        Task<VedioReadVm> GetByIdAsync(int id);
        Task<VedioUpdateVm> UpdateAsync(VedioUpdateVm vedioUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}

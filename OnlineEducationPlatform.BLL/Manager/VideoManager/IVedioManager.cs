using OnlineEducationPlatform.BLL.Dto.VideoDto;
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
        Task AddAsync(VedioAddDto vedioAddDto);
        Task<IEnumerable<VedioReadDto>> GetAllAsync();
        Task<VedioReadDto> GetByIdAsync(int id);
        Task<VedioUpdateDto> UpdateAsync(VedioUpdateDto vedioUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}

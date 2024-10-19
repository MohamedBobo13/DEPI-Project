using OnlineEducationPlatform.BLL.Dto.VideoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager.VideoManager
{
    public interface IVedioManager
    {
        void Add(VedioAddDto vedioAddDto);
        IEnumerable<VedioReadDto> GetAll();

        VedioReadDto GetById(int id);

        void Update(VedioUpdateDto vedioUpdateDto);

        void Delete(int id);

        void SaveChanges();
    }
}

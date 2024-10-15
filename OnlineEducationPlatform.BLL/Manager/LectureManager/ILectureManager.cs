using OnlineEducationPlatform.BLL.Dto.LectureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Manager
{
    public interface ILectureManager
    {
        void Add(LectureAddDto lectureAddDto);
        IEnumerable<LectureReadDto> GetAll();

        LectureReadDto GetById(int id);

        void Update(LectureUpdateDto lectureUpdateDto);

        void Delete(int id);

        void SaveChanges();

    }
}

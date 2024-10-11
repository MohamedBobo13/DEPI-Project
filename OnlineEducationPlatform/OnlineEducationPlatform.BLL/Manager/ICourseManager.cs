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
        void Add(CourseAddDto courseAddDto);
        IEnumerable<CourseReadDto> GetAll();

        CourseReadDto GetById(int id);

        void Update(CourseUpdateDto courseUpdateDto);

        void Delete(int id);

        void SaveChanges();
    }
}

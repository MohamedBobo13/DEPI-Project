using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.TestDto
{
    public class TestAddDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalMarks { get; set; }
    }
    public partial class ExamAddDto : TestAddDto
    {
        public int DurationMinutes { get; set; }
        public int PassingMarks { get; set; }

    }
    public partial class QuizAddDto : TestAddDto
    {
        public int LectureId { get; set; }
        
    }
}

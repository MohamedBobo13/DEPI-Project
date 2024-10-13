using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.TestDto
{
    public class TestUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalQuestions { get; set; }
        public int LectureId { get; set; }
        public int CourseId { get; set; }
    }
    public partial class ExamUpdateDto : TestUpdateDto
    {
        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }
        public int PassingMarks { get; set; }
    }
    public partial class QuizUpdateDto : TestUpdateDto
    {
        public int TotalMarks { get; set; }
    }
}

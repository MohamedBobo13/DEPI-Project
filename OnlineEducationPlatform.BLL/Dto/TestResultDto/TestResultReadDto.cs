using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.TestResultDto
{
    public class TestResultReadDto
    {
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
    }
    public partial class ExamResultReadDto : TestResultReadDto
    {
        public bool IsPassed { get; set; }
     
    }
    public partial class QuizResultReadDto : TestResultReadDto
    {
        
    }
}

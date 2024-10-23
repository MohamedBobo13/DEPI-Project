using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.ViewModels.QuestionVm
{
    public class QuestionExamAddVm
    {
        public int CourseId { get; set; }
        public string Content { get; set; }
        public int Marks { get; set; }
        public QuestionType QuestionType { get; set; }
        public int ExamId { get; set; }
    }
}

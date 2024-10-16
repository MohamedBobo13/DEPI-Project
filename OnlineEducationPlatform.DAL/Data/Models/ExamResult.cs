using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
<<<<<<< HEAD
        public bool IsPassed { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
=======
        public bool IsDeleted { get; set; }
        public bool IsPassed { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("Student")]

        public string StudentId { get; set; }

        public Exam Exam { get; set; }
        public Student student { get; set; }
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411

    }
}
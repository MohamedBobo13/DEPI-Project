using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
<<<<<<< HEAD
=======
        public bool IsDeleted { get; set; }
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        public decimal Score { get; set; }
        public decimal TotalMarks { get; set; }
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
<<<<<<< HEAD
        [ForeignKey("StudentProgress")]
        public int StudentProgressId { get; set; }
        public StudentProgress StudentProgress { get; set; }
=======
        [ForeignKey("Student")]

        public string StudentId { get; set; }

        public Student student { get; set; }

>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        public Quiz Quiz { get; set; }
    }
}
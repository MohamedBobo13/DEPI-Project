using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalHours { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public User Instructor { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Quiz> Quizzes { get; set; }

        public Exam Exam { get; set; }

    }
}

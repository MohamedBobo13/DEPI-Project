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
<<<<<<< HEAD
        public int TotalHours { get; set; }

=======
        public bool IsDeleted { get; set; }
        public int TotalHours { get; set; }
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();
<<<<<<< HEAD
=======

>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();

    }
}

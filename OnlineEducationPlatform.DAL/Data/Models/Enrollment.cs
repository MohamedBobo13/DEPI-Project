using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public StudentProgress StudentProgress { get; set; }
=======
        public bool IsDeleted { get; set; }=new bool();
        public DateTime EnrollmentDate { get; set; }= DateTime.Now;
        public EnrollmentStatus Status { get; set; }
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
    }
}
public enum EnrollmentStatus
{
<<<<<<< HEAD
    Active,
    Completed,
    Withdrawn
=======
    Enrolled,
    Inprogress,
    Completed,
    removed
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
}

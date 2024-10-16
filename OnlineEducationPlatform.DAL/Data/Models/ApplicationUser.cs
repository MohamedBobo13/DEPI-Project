using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineEducationPlatform.DAL.Data.Models
{
   
    public class ApplicationUser : IdentityUser
    {
        public TypeUser UserType { get; set; }
        
        public DateTime CreatedDate { get; set; }


    }
=======

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class ApplicationUser :IdentityUser
    {


        public bool IsDeleted { get; set; }
        public TypeUser UserType { get; set; }
        public DateTime CreatedDate { get; set; }
       
     
    }

>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
    public class Student : ApplicationUser
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<AnswerResult> AnswerResults { get; set; } = new HashSet<AnswerResult>();

<<<<<<< HEAD
    }
    public class Instructor : ApplicationUser
    {
      
       public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
    public class Admin : ApplicationUser { }
}
public enum TypeUser
{
    Student=1,
    Instructor=2,
    Admin=3
=======
        public ICollection<QuizResult> quizResults { get; set; } = new HashSet<QuizResult>();
        public ICollection<ExamResult> examResults { get; set; } = new HashSet<ExamResult>();




    }
    public class Instructor : ApplicationUser
    {
       
            
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
     

    }
    public class Admin : ApplicationUser {  }

}

public enum TypeUser
{
    Admin=1,
    Instructor=2,
    Student=3
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
}

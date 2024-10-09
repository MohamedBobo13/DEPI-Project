using Microsoft.AspNetCore.Identity;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class User :IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType Type { get; set; }
        public DateTime CreatedDate { get; set; }
       
     
    }

    public class Student : User
    {
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<AnswerResult> AnswerResults { get; set; } = new HashSet<AnswerResult>();





    }
    public class Instructor : User
    {
        public bool isapproved { get; set; } = false; 
            
            
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


    }


}

public enum UserType
{
    Admin=1,
    Instructor=2,
    Student=3
}

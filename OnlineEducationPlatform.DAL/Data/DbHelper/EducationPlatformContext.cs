using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Data.DbHelper
{
    public class EducationPlatformContext : IdentityDbContext<ApplicationUser>
    {
        public EducationPlatformContext(DbContextOptions<EducationPlatformContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answer>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<AnswerResult>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Question>()
                        .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Enrollment>()
                    .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<ApplicationUser>()
                  .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Course>()
                  .HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Enrollment>()
        .HasIndex(e => new { e.StudentId, e.CourseId })
        .IsUnique();
            //            modelBuilder.Entity<ApplicationUser>().HasData(
            //           new ApplicationUser
            //           {
            //               Id = "5",
            //               UserName = "Instructor John",
            //               Email = "john@platform.com",
            //               PasswordHash = "hashedpassword456",
            //               IsDeleted = false,
            //               UserType = TypeUser.Instructor,
            //               CreatedDate = DateTime.Now
            //           },
            //           new ApplicationUser
            //           {
            //               Id = "6",
            //               UserName = "student John",
            //               Email = "john@platform.com",
            //               PasswordHash = "hashedpassword478",
            //               IsDeleted = false,
            //               UserType = TypeUser.Student,
            //               CreatedDate = DateTime.Now
            //           },
            //           new ApplicationUser
            //           {
            //               Id = "8",
            //               UserName = "student Sarah",
            //               Email = "sarah@platform.com",
            //               PasswordHash = "hashedpassword123",
            //               IsDeleted = false,
            //               UserType = TypeUser.Student,
            //               CreatedDate = DateTime.Now
            //           },
            //           new ApplicationUser
            //           {




            //                Id = "9",
            //               UserName = "Instructor Sarah",
            //               Email = "sarah@platform.com",
            //               PasswordHash = "hashedpassword321",
            //               IsDeleted = false,
            //               UserType = TypeUser.Student,
            //               CreatedDate = DateTime.Now
            //           }
            //       );
            //            modelBuilder.Entity<Course>().HasData(
            //    new Course
            //    {
            //        Id = 3,
            //        Title = "Introduction to Programming",
            //        Description = "A beginner-level course on programming",
            //        InstructorId = "5", // Instructor John
            //        IsDeleted = false,
            //        CreatedDate = DateTime.Now,
            //        TotalHours = 40
            //    }
            //);
            //            modelBuilder.Entity<Lecture>().HasData(
            //    new Lecture
            //    {
            //        Id = 2,
            //        CourseId = 3, // Introduction to Programming
            //        Title = "Introduction to Variables",
            //        IsDeleted = false,
            //        Order = 1
            //    }
            //);
            //            modelBuilder.Entity<Enrollment>().HasData(
            //    new Enrollment
            //    {
            //        Id = 6,
            //        StudentId = "8", // Student Jane
            //        CourseId = 3, // Introduction to Programming
            //        EnrollmentDate = DateTime.Now,
            //        IsDeleted = false,
            //        Status = EnrollmentStatus.Enrolled
            //    }
            //);
            //            modelBuilder.Entity<Quiz>().HasData(
            //    new Quiz
            //    {
            //        Id = 3,
            //        LectureId = 2, // Introduction to Variables
            //        Title = "Quiz 1 - Variables",
            //        TotalMarks = 10,
            //        TotalQuestions = 5,
            //        CourseId = 3, // Introduction to Programming
            //        IsDeleted = false
            //    }
            //);
            //            modelBuilder.Entity<QuizResult>().HasData(
            //    new QuizResult
            //    {
            //        Id = 1,
            //        QuizId = 3, // Quiz 1 - Variables
            //        StudentId = "8", // Student Jane
            //        Score = 8,
            //        TotalMarks = 10,
            //        IsDeleted = false
            //    }
            //);
            //            modelBuilder.Entity<Exam>().HasData(
            //    new Exam
            //    {
            //        Id = 2,
            //        CourseId = 3, // Introduction to Programming
            //        Title = "Final Exam - Introduction to Programming",
            //        DurationMinutes = 120,
            //        TotalMarks = 100,
            //        PassingMarks = 50,
            //        IsDeleted = false,
            //        TotalQuestions = 20
            //    }
            //);
            //            modelBuilder.Entity<ExamResult>().HasData(
            //    new ExamResult
            //    {
            //        Id = 1,
            //        StudentId = "8", // Student Jane
            //        ExamId = 1, // Final Exam - Introduction to Programming
            //        Score = 85,
            //        TotalMarks = 100,
            //        IsPassed = true,
            //        IsDeleted = false
            //    }

            //);
            //            modelBuilder.Entity<Question>().HasData(
            //    new Question
            //    {
            //        Id = 1,
            //        QuizId = 2, // Quiz 1 - Variables
            //        Content = "What is a variable?",
            //        QuestionType = QuestionType.Multiple_Choice,
            //        Marks = 2,
            //        IsDeleted = false
            //    },
            //    new Question
            //    {
            //        Id = 2,
            //        ExamId = 2, // Final Exam
            //        Content = "Explain the concept of loops in programming.",
            //        QuestionType = QuestionType.Multiple_Choice,
            //        Marks = 5,
            //        IsDeleted = false
            //    }
            //);
            //            modelBuilder.Entity<Answer>().HasData(
            //    new Answer
            //    {
            //        Id = 1,
            //        QuestionId = 1, // What is a variable?
            //        AnswerText = "A variable is a container for storing data values.",
            //        IsCorrect = true,
            //        IsDeleted = false
            //    },
            //    new Answer
            //    {
            //        Id = 2,
            //        QuestionId = 2,
            //        AnswerText = "A variable is a type of function.",
            //        IsCorrect = false,
            //        IsDeleted = false
            //    }
            //);
            //            modelBuilder.Entity<AnswerResult>().HasData(
            //                new AnswerResult
            //                {
            //                    Id = 1,
            //                    StudentAnswer = "A variable is a container for storing data values.",
            //                    StudentId = "8", // Student Jane
            //                    QuestionId = 1, // What is a variable?
            //                    AnswerId = 1, // Correct answer
            //                    MarksAwarded = 2,
            //                    IsDeleted = false
            //                }
            //            );

            //            modelBuilder.Entity<PdfFile>().HasData(
            //    new PdfFile
            //    {
            //        Id = 1,
            //        LectureId = 2, // Introduction to Variables
            //        Url = "http://example.com/intro-to-variables.pdf",
            //        Title = "Introduction to Variables",
            //        IsDeleted = false
            //    }
            //);
            //            modelBuilder.Entity<Video>().HasData(
            //    new Video
            //    {
            //        Id = 1,
            //        LectureId = 2, // Introduction to Variables
            //        Url = "http://example.com/intro-to-variables.mp4",
            //        Title = "Introduction to Variables",
            //        IsDeleted = false
            //    }
            //);


            // Add seed data for other entities (Courses, Lectures, etc.) similarly



        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AnswerResult> AnswerResult { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<PdfFile> PdfFile { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Instructor> Instructor { get; set; }





        public DbSet<Video> Video { get; set; }
        public DbSet<QuizResult> QuizResult { get; set; }


    }
} 

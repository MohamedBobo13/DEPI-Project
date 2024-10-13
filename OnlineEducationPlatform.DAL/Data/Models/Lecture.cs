using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
<<<<<<< HEAD:OnlineEducationPlatform/OnlineEducationPlatform.DAL/Data/Models/Lecture.cs
        public List<Quiz> Quizzes { get; set; }
        public List<PdfFile> PdfFiles { get; set; }
        public List<Video> Videos { get; set; }
=======
        public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();
        public ICollection<StudentProgress> StudentProgresses { get; set; } = new HashSet<StudentProgress>();
        public ICollection<PdfFile> PdfFiles { get; set; } = new HashSet<PdfFile>();
        public ICollection<Video> Videos { get; set; } = new HashSet<Video>();
>>>>>>> e75ab0b57a683d1f7861dd5ef37cdafbcd727ccb:OnlineEducationPlatform.DAL/Data/Models/Lecture.cs


    }
}
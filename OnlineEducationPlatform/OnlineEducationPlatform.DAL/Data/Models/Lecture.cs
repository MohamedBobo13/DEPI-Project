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
        public List<Quiz> Quizzes { get; set; }
        public List<PdfFile> PdfFiles { get; set; }
        public List<Video> Videos { get; set; }


    }
}
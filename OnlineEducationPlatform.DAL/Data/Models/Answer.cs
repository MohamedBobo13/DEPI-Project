using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
<<<<<<< HEAD
=======
        public bool IsDeleted { get; set; }=false;
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        public bool IsCorrect { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerResult> AnswerResults { get; set; } = new HashSet<AnswerResult>();
    }
}


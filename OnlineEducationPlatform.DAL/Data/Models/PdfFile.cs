﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnlineEducationPlatform.DAL.Data.Models
{
    public class PdfFile
    {
        public int Id { get; set; }
        public string Url { get; set; }
<<<<<<< HEAD
=======
        public bool IsDeleted { get; set; }
>>>>>>> 0e394ca711bfc60f522495046b571e4960f4b411
        public string Title { get; set; }
        [ForeignKey("Lecture")]
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

    }
}

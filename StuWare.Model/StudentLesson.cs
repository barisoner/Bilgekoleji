using System;
using System.Collections.Generic;
using System.Text;

namespace StuWare.Model
{
   public class StudentLesson
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int LessonID { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<StudentLessonGrade> StudentLessonGrade { get; set; }
    }
}

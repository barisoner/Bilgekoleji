using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StuWare.Model
{
    public class Lesson
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Lütfen Kaçıncı Sınıf Dersi Olduğunu Giriniz")]
        [Range(1,12,ErrorMessage ="Lütfen Sınıfı Doğru Aralıklarda Giriniz")]
        public int Class { get; set; }

        [Required(ErrorMessage = "Lütfen Ders Adı Giriniz")]
        [StringLength(35, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 35 karakter girin"))]
        public string Name { get; set; }
        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentLesson> StudentLessons { get; set; }

    }
}

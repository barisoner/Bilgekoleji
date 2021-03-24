using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StuWare.Model
{
    public class StudentLessonGrade
    {
        public int ID { get; set; }
        public int StudentLessonID { get; set; }

        [Required(ErrorMessage ="Lütfen Not Tipini Giriniz")]
        [StringLength(30,MinimumLength =2 , ErrorMessage ="Not tipi karakter uzunluğu en az 2 en fazla 30 olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Not Giriniz")]
        [Range(0,100,ErrorMessage ="Notu 0,100 veya aralığında girmelisiniz")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Lütfen Dönem Giriniz")]
        [Range(1, 2, ErrorMessage = "1. veya 2. dönem olmalı")]
        public int Period { get; set; }

        public virtual StudentLesson StudentLesson { get; set; }

    }
}

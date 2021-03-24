using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StuWare.Model
{
    public class Teacher
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Lütfen İsminizi Girin")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 20 karakter girin"))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 20 karakter girin"))]
        public string LastName { get; set; }
        public int Sex { get; set; }

        [Required(ErrorMessage = "Lütfen Branşınızı Girin")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 20 karakter girin"))]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Lütfen Şubenizi Girin")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 20 karakter girin"))]
        public string Task { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}

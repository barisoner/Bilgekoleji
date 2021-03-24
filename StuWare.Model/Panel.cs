using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StuWare.Model
{
    public class Panel
    {
        public int ID { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Başlık Ekleyiniz")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = ("Başlık en fazla 40 en az 2 karakterli olmalı"))]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama Ekleyiniz")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = ("Açıklama en fazla 255 karakterli olmalı"))]
        public string Description { get; set; }
    }
}

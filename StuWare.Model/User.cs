using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StuWare.Model
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Lütfen İsminizi Girin")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ("Lütfen en az 2 en fazla 30 karakter girin"))]
        public string Username { get; set; }

        [Required(ErrorMessage ="Lütfen Şifre Girin")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = ("Şifre en az 5 karakter en fazla 20 karakter olmalı"))]
        public string Password { get; set; }

        [Required(ErrorMessage ="Lütfen Mail girin")]
        [EmailAddress(ErrorMessage ="Mail i doğru biçimce giriniz")]
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; }        
    }
}

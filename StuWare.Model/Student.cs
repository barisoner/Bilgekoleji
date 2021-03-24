using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StuWare.Model
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Lütfen Boş Bırakmayınız")]
        [StringLength(30,MinimumLength =2,ErrorMessage =("İsiminiz en az 2 , en fazla 30 karaktere Sahip olabilir"))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ("Soyadınız en az 2 , en fazla 30 karaktere Sahip olabilir"))]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen Cinsiyet Seçiniz")]
        public bool Sex { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız / Eğer Önceki Okulunuz Yok ise (YOK) Yazınız")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ("Okul İsmi en az 2 , en fazla 40 karaktere Sahip olabilir"))]
        public string LastSchool { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [Range(0,5,ErrorMessage =("Not ortalamanız 0 , 5 veya aralığında olmalı"))]
        public double GradeAverage { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [Range(1, 12, ErrorMessage = ("Sıfınızı yılınız 1 , 12 aralığında olmalı"))]
        public int ClassYear { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ("Veli Adı en az 2 , en fazla 30 karaktere Sahip olabilir"))]
        public string GuardianName { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = ("Veli SoyAdı en az 2 , en fazla 30 karaktere Sahip olabilir"))]
        public string GuardianLastName { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [Phone(ErrorMessage ="Lütfen düzgün şekilde Ev Tel. numaranızı giriniz.")]
        public string GuardianPhone { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [Phone(ErrorMessage = "Lütfen düzgün şekilde tel. numaranızı giriniz.")]
        public string GuardianCellPhone { get; set; }

        [Required(ErrorMessage = "Lütfen Boş Bırakmayınız")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = ("Adres tarifi en az 4 , en fazla 150 karaktere Sahip olabilir"))]
        public string GuardianAddress { get; set; }


        public int DistrictID { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<StudentLesson> StudentLessons { get; set; }


    }
}

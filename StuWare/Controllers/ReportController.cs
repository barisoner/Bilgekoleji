using Microsoft.AspNetCore.Mvc;
using StuWare.Data.Repository;
using StuWare.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class ReportController : StuwareController
    {
        private IStudentLessonRepository _studentLessonRepository;
        private IStudentRepository _studentRepository;
        private ILessonRepository _lessonRepository;

        public ReportController(IStudentLessonRepository studentLessonRepository, IStudentRepository studentRepository, ILessonRepository lessonRepository)
        {
            _studentLessonRepository = studentLessonRepository;
            _studentRepository = studentRepository;
            _lessonRepository = lessonRepository;
        }

        private static int selectedStudentId = 0;
        public IActionResult Index(int id)
        {
            selectedStudentId = id;
            ViewBag.selectedStudentId = selectedStudentId;

            var studentLessonsList = _studentLessonRepository.StudentLessons.Where(x => x.StudentID.Equals(selectedStudentId));

            double totalGrade = 0, count = 0;
         
            foreach (var item in studentLessonsList)
            {
                if (item.StudentLessonGrade.Count > 0)
                {
                    double avg = item.StudentLessonGrade.Average(x => x.Grade);
                    totalGrade += CalculateGrade(avg);
                    count++;
                }
            }

            ViewBag.Grade = Math.Round((totalGrade / count),2);

            return View(studentLessonsList);
        }

        private double CalculateGrade(double avg)
        {
            double grade = 0;
            if (avg > 85)
            {
                grade = 5;
            }
            else if (avg > 70)
            {
                grade = 4;
            }
            else if (avg > 55)
            {
                grade = 3;
            }
            else if (avg > 45)
            {
                grade = 2;
            }
            else
            {
                grade = 1;
            }
            return grade;
        }
    }
}

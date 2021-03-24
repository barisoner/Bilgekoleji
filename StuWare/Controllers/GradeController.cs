using Microsoft.AspNetCore.Mvc;
using StuWare.Data.Repository;
using StuWare.Helpers;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class GradeController : StuwareController
    {

        private IStudentLessonGradeRepository _studentLessonGradeRepository;
        private static int selectedStudentLessonId;

        public GradeController(IStudentLessonGradeRepository studentLessonGradeRepository)
        {
            _studentLessonGradeRepository = studentLessonGradeRepository;
        }

        public IActionResult Index(int id)
        {
            selectedStudentLessonId = id;
            return View(_studentLessonGradeRepository.studentLessongrades.Where(x => x.StudentLessonID.Equals(id)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentLessonGrade entity)
        {
            entity.StudentLessonID = selectedStudentLessonId;

            if (ModelState.IsValid)
            {
                _studentLessonGradeRepository.CreateStudentLessonGrade(entity);
                return RedirectToAction("Index", new { id = selectedStudentLessonId });
            }
            else
            {
                return View(entity);
            }
        }

        public IActionResult Delete(int id)
        {
            _studentLessonGradeRepository.DeleteStudentLessonGrade(id);
            return RedirectToAction("Index", new { id = selectedStudentLessonId });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_studentLessonGradeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Details(StudentLessonGrade entity)
        {
            if (ModelState.IsValid)
            {
                entity.StudentLessonID = selectedStudentLessonId;
                _studentLessonGradeRepository.UpdateStudentLessonGrade(entity);
                return RedirectToAction("Index", new { id = selectedStudentLessonId });
            }
            else
            {
                return View(entity);
            }
        }

    }
}

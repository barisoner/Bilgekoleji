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
    public class LessonController : StuwareController
    {
        private ILessonRepository _lessonRepository;
        private ITeacherRepository _teacherRepository;

        public LessonController(ILessonRepository lessonrepository, ITeacherRepository teacherRepository)
        {
            _lessonRepository = lessonrepository;
            _teacherRepository = teacherRepository;
        }

        public IActionResult Index()
        {
            return View(_lessonRepository.Lessons);
        }

        [HttpGet]
        public IActionResult Create()
        {

            List<Teacher> teacherList = _teacherRepository.Teachers.ToList<Teacher>();
            ViewBag.ListOfTeachers = teacherList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Lesson entity)
        {
            if (ModelState.IsValid)
            {
                _lessonRepository.CreateLesson(entity);
                return RedirectToAction("Index");
            }
            else
            {
                List<Teacher> teacherList = _teacherRepository.Teachers.ToList<Teacher>();
                ViewBag.ListOfTeachers = teacherList;
                return View(entity);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            List<Teacher> teacherList = _teacherRepository.Teachers.ToList<Teacher>();
            ViewBag.ListOfTeachers = teacherList;

            return View(_lessonRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Details(Lesson entity)
        {

            if (ModelState.IsValid)
            {
                _lessonRepository.UpdateLesson(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }

        }


        public IActionResult Delete(int id)
        {
            _lessonRepository.DeleteLesson(id);
            return RedirectToAction("Index");
        }

    }
}

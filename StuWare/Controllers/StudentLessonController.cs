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
    public class StudentLessonController : StuwareController
    {
        private IStudentLessonRepository _studentLessonRepository;
        private IStudentRepository _studentRepository;
        private ILessonRepository _lessonRepository;

        public StudentLessonController(IStudentLessonRepository studentLessonRepository,IStudentRepository studentRepository,ILessonRepository lessonRepository)
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

            List<int> selectedClassList = new List<int>();
            var student = _studentRepository.GetById(selectedStudentId);
            var studentlessonsForSpecificYearList = _lessonRepository.Lessons.Where(x => x.Class.Equals(student.ClassYear));

            foreach (var item in studentlessonsForSpecificYearList.ToList())
            {
                if (_studentLessonRepository.StudentLessons.Where(x => x.StudentID.Equals(selectedStudentId) && x.LessonID.Equals(item.ID)).Count() > 0)
                    selectedClassList.Add(item.ID);

            }

            ViewBag.SelectedClassLists = selectedClassList;

            return View(studentlessonsForSpecificYearList);
        }


        public IActionResult Create(int id)
        {
            if (_studentLessonRepository.StudentLessons.Where(x => x.StudentID.Equals(selectedStudentId) && x.LessonID.Equals(id)).Count() > 0)
                throw new Exception("Duplicated");

            _studentLessonRepository.CreateStudentLesson(new StudentLesson
            {
                LessonID = id,
                StudentID = selectedStudentId
            });

            return RedirectToAction("Index", new { id = selectedStudentId });
        }

        public IActionResult Delete(int id)
        {
            int lessonId = id;
            var studentLesson = _studentLessonRepository.StudentLessons.Where(x => x.StudentID.Equals(selectedStudentId) && x.LessonID.Equals(lessonId)).FirstOrDefault();
            _studentLessonRepository.DeleteStudentLesson(studentLesson.ID);
            return RedirectToAction("Index", new { id = selectedStudentId });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StuWare.Data.Migrations;
using StuWare.Data.Repository;
using StuWare.Helpers;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class HomeController : StuwareController
    {

        private readonly IPanelRepository _panelRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ILessonRepository _lessonRepository;

        public HomeController(
            IPanelRepository panelRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            ILessonRepository lessonRepository)
        {
            _panelRepository = panelRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _lessonRepository = lessonRepository;
        }

        public IActionResult Index()
        {
            ViewBag.StudentCount = _studentRepository.Students.Count();
            ViewBag.TeacherCount = _teacherRepository.Teachers.Count();
            ViewBag.CourseCount = _lessonRepository.Lessons.Count();

            return View(_panelRepository.Panels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Panel entity, IFormFile file)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            entity.Image = file.FileName;
            entity.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _panelRepository.CreatePanel(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var panel = _panelRepository.GetById(id);
            if (panel != null)
            {
                if (!string.IsNullOrWhiteSpace(panel.Image))
                {
                    var safeFileName = Path.GetFileName(panel.Image);
                    if (!string.IsNullOrEmpty(safeFileName))
                    {
                        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", safeFileName);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                }

                _panelRepository.DeletePanel(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_panelRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Details(Panel entity, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            entity.Image = file.FileName;
            entity.UpdatedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _panelRepository.UptadePanel(entity);

                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }


    }
}

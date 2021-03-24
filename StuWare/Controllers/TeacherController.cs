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
    public class TeacherController : StuwareController
    {

        private ITeacherRepository _teacherrepository;

        public TeacherController(ITeacherRepository teacherrepository)
        {
            _teacherrepository = teacherrepository;
        }

        public IActionResult Index()
        {
            return View(_teacherrepository.Teachers);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher entity)
        {

            if (ModelState.IsValid)
            {
                _teacherrepository.CreateTeacher(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }

        public IActionResult Delete(int id)
        {
            _teacherrepository.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_teacherrepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Details(Teacher entity)
        {
            if (ModelState.IsValid)
            {
                _teacherrepository.UpdateTeacher(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }
    }
}

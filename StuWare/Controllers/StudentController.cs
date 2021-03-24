using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StuWare.Data.Repository;
using StuWare.Helpers;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace StuWare.Controllers
{
    public class StudentController : StuwareController
    {
        private IStudentRepository _studentRepository;
        private ICityRepository _cityRepository;
        private IDistrictRepository _districtRepository;
        private ILessonRepository _lessonRepository;

        public StudentController(IStudentRepository studentRepository, ICityRepository cityRepository, IDistrictRepository districtRepository, ILessonRepository lessonRepository)
        {
            _studentRepository = studentRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _lessonRepository = lessonRepository;
        }
        public IActionResult Index()
        {

            return View(_studentRepository.Students);
        }

        [HttpGet]
        public IActionResult Create()
        {

            List<City> cityList = _cityRepository.Cities.ToList<City>();
            ViewBag.ListOfCities = cityList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student entity)
        {

            if (ModelState.IsValid)
            {
                _studentRepository.CreateStudent(entity);
                return RedirectToAction("Index");
            }
            else
            {
                List<City> cityList = _cityRepository.Cities.ToList<City>();
                ViewBag.ListOfCities = cityList;
                return View(entity);
              
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            List<City> cityList = _cityRepository.Cities.ToList<City>();
            ViewBag.ListOfCities = cityList;

            return View(_studentRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Details(Student entity)
        {
            if (ModelState.IsValid )
            {
                _studentRepository.UpdateStudent(entity);
                return RedirectToAction("Index");
            }
            else
            {
                List<City> cityList = _cityRepository.Cities.ToList<City>();
                ViewBag.ListOfCities = cityList;
                return View(entity);
            }
        }

        public IActionResult Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }


        public JsonResult GetDistricts(int cityId)
        {
            var districtList = _districtRepository.GetByCityId(cityId);
            return Json(new SelectList(districtList, "ID", "Name"));
        }

    }
}
